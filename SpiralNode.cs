namespace BFSSpiralTree
{
    public readonly record struct FlPoint(float X, float Y)
    {
        public readonly Point ToPoint() { return new Point((int)Math.Round(X), (int)Math.Round(Y)); }
        public readonly PointF ToPointF() { return new PointF(X, Y); }
    };


    public class SpiralNode
    {
        public int PrntIdx { get; }
        public FlPoint Ctr { get; set; }
        public float Rad { get; set; }
        public float StrtAngl { get; set; }
        public float EndAngl { get; set; }
        public int Clock { get; }
        public bool Full { get; set; }
        public bool TooSmall => Math.Round(Rad) <= Configs.minRadius;
        public bool Blocked { get; set; }
        public bool CanGrow => !Full && !Blocked && !TooSmall;
        public bool HasLeaves => LeafCount() > 0;
        public bool IsTwin { get; }
        public bool IsRoot => PrntIdx == -1;
        public FlPoint SprlCtr { get; set; }
        public FlPoint StrtPt { get; set; }
        public int Slot { get; set; }
        public float Lift { get; set; }
        public List<int> LeafIdxs { get; set; } = new List<int>();
        public List<float> LeafAngls { get; set; } = new List<float>();
        public List<int> NhbrIdxs { get; set; } = new List<int>();
        public List<float> NhbrDists { get; set; } = new List<float>();

        //public List<int> TmpNhbrIdxs { get; set; } = new List<int>();     //for testing fit check only
        //public List<float> TmpNhbrDists { get; set; } = new List<float>();    //for testing fit check only
        public List<float> EdgeDists { get; set; } = new List<float>();
        public List<FlPoint> EdgePoints { get; set; } = new List<FlPoint>();

        public int LeafCount()
        {
            return LeafAngls.Count;
        }

        public int LastLeafIdx()
        {
            return LeafIdxs.Count > 0 ? LeafIdxs[^1] : -1;
        }

        public float LastLeafAngle()    //return first open instead of "invalid"?
        {
            return LeafAngls.Count > 0 ? LeafAngls[^1] : ToAbsoluteAngle(Configs.startAt + Configs.shiftFactor);
        }


        //for root node(s) only
        public SpiralNode(FlPoint ctr, float radius, float angle, bool isTwin = false)
        {
            PrntIdx = -1;
            Ctr = ctr;
            Rad = radius;
            StrtAngl = angle;
            Clock = 1;
            Slot = 0;
            Lift = Configs.rootLift;
            Full = false;
            Blocked = false;
            IsTwin = isTwin;
            EndAngl = Trig.Mod2PI(StrtAngl + (Clock * Configs.endAt));
            SprlCtr = InitSprlCtr();
            StrtPt = InitRootStrtPt();
        }


        public SpiralNode(int prntIdx, int prntClock, float ctrX, float ctrY, float radius, float angle, int slot = 0, float lift = 0)
        {
            PrntIdx = prntIdx;
            Ctr = new FlPoint(ctrX, ctrY);
            Rad = radius;
            StrtAngl = angle;
            Clock = prntIdx == -1 ? 1 : -1 * prntClock;
            Slot = prntIdx == -1 ? 0 : slot;
            Lift = prntIdx == -1 ? Configs.rootLift : lift;
            Full = false;
            Blocked = false;
            IsTwin = false;
            EndAngl = Trig.Mod2PI(StrtAngl + (Clock * Configs.endAt));
            SprlCtr = InitSprlCtr();
            if (prntIdx == -1) { StrtPt = InitRootStrtPt(); }
        }


        public SpiralNode(SpiralNode orig) //creates a copy of the original
        {
            PrntIdx = orig.PrntIdx;
            Ctr = new FlPoint(orig.Ctr.X, orig.Ctr.Y);
            Rad = orig.Rad;
            StrtAngl = orig.StrtAngl;
            Clock = orig.Clock;
            Slot = orig.Slot;
            Lift = orig.Lift;
            Full = false;
            Blocked = false;
            IsTwin = false;
            EndAngl = orig.EndAngl;
            SprlCtr = new FlPoint(orig.SprlCtr.X, orig.SprlCtr.Y);
            StrtPt = new FlPoint(orig.StrtPt.X, orig.StrtPt.Y);
            //no leaves yet, skip

            NhbrIdxs = new List<int>();
            NhbrDists = new List<float>();
            NhbrIdxs.AddRange(orig.NhbrIdxs);
            NhbrDists.AddRange(orig.NhbrDists);

            EdgeDists = new List<float>();
            EdgePoints = new List<FlPoint>();
            EdgeDists.AddRange(orig.EdgeDists);
            EdgePoints.AddRange(orig.EdgePoints);
        }


        public string PrintNode(char[] flags)
        {
            string nodePrint = "";

            if (flags.Contains('B'))
            {
                nodePrint += $"NODE parent idx: {PrntIdx}; ctr: ({Ctr.X:F3}, {Ctr.Y:F3}); " +
                        $"rad: {Rad:F3}; start angle: {StrtAngl:F3}; end angle: {EndAngl:F3}; " +
                        $"slot: {Slot}; clock: {Clock}\n";
            }
            if (flags.Contains('E')) { nodePrint += PrintNodeEdgeData(); }
            if (flags.Contains('L')) { nodePrint += PrintNodeLeafData(); }
            if (flags.Contains('N')) { nodePrint += PrintNodeNhbrData(); }

            return nodePrint;
        }


        public string PrintNodeEdgeData(bool conflictOnly = false)
        {
            string nodePrint = "";

            for (int idx = 0; idx < EdgeDists.Count; idx++)
            {
                if (conflictOnly && EdgeDists[idx] != 0) { continue; };
                nodePrint += $"edge idx#{idx} distance: {EdgeDists[idx]}; point: {EdgePoints[idx]:F3}\n";
            }

            return nodePrint;
        }


        public string PrintNodeLeafData()
        {
            string nodePrint = "";

            for (int idx = 0; idx < LeafCount(); idx++)
            {
                nodePrint += $"leaf idx: {LeafIdxs[idx]}, angle: {LeafAngls[idx]:F3}\n";
            }

            return nodePrint;
        }


        public string PrintNodeNhbrData()
        {
            string nodePrint = "";

            for (int idx = 0; idx < NhbrIdxs.Count; idx++)
            {
                nodePrint += $"neighbor idx: {NhbrIdxs[idx]}, surface dist:  {NhbrDists[idx]:F3}\n";
            }

            return nodePrint;
        }


        public FlPoint InitSprlCtr()
        {
            float shiftAng = Clock * 3 * (float)Math.PI / 4;
            float newAng = Trig.Mod2PI(StrtAngl + shiftAng);

            float shiftX = Ctr.X + ((float)Math.Cos(newAng) * (Rad / (float)Math.Tau));
            float shiftY = Ctr.Y + ((float)Math.Sin(newAng) * (Rad / (float)Math.Tau));

            return new FlPoint(shiftX, shiftY);
        }


        public FlPoint InitRootStrtPt()
        {
            float scl = 0.099f;
            float angl = (2 * (float)Math.Tau) - 0.1f;
            float sclRad = Rad * scl;

            float x = SprlCtr.X + (sclRad * angl * (float)Math.Cos(angl + StrtAngl));
            float y = SprlCtr.Y + (sclRad * angl * (float)Math.Sin(angl + StrtAngl));

            return new FlPoint(x, y);
        }

        private void Recenter(FlPoint prntCtr, float prntRad, float newAngleFromPrnt = -100f, float newRad = 0f)
        {
            if (newRad > 0)
            {
                Rad = newRad;
                Full = false;
                Blocked = false;
            }
            if (newAngleFromPrnt != -100)
            {
                StrtAngl = Trig.ComplementAngle(newAngleFromPrnt);
                EndAngl = Trig.Mod2PI(StrtAngl + (Clock * Configs.endAt));
            }

            float ctrX = prntCtr.X + ((float)Math.Cos(newAngleFromPrnt) * (prntRad + Rad + Lift));
            float ctrY = prntCtr.Y + ((float)Math.Sin(newAngleFromPrnt) * (prntRad + Rad + Lift));
            Ctr = new FlPoint(ctrX, ctrY);

            SprlCtr = InitSprlCtr();
        }


        //from experimental observation: spiral drawing has slight discrepancy from leaf angle
        //discrepancy at min at maxTheta-5*Math.PI/4 and maxTheta-Math.PI/4
        //discrepancy increases from maxTheta-5*Math.PI/4 to maxTheta-3*Math.PI/4 - peak at maxTheta-3*Math.PI/4?
        //discrepancy decreases between maxTheta-3*Math.PI/4 and maxTheta-Math.PI/4
        //discrepancy in opposite direction slowly increases from maxTheta-5*Math.PI/4 to maxTheta-3*Math.PI/2
        //and more steeply increases from there toward center (maxTheta-2*Math.PI)
        //maxTheta=4*Math.PI
        public void CreateLeafPt(SpiralNode leafNode)
        {
            float maxSprlAngl = 2f * (float)Math.Tau;
            float scl = 0.099f * Rad;

            float anglToLeaf = Trig.ComplementAngle(leafNode.StrtAngl);
            float angl = maxSprlAngl - Trig.Mod2PI(-1 * ToRelativeAngle(anglToLeaf)); //clearer derivation
            float angleRatio = 0f;
            float baseDistRate = 0.2f;

            float prntInitRatio = Rad / Configs.initRadius;    //large when parent is close to or larger than initRadius
            float leafInitRatio = leafNode.Rad / Configs.initRadius;   //large when leafNode is close to or larger than initRadius
            float initLeafRatio = Configs.initRadius / leafNode.Rad;   //large when leafNode is small, inverse of leafInitRatio

            //adjustment should be larger for very large leaves, esp. of very large parents
            float radRatio = Math.Max(leafInitRatio, prntInitRatio);
            if (radRatio < 1) { radRatio = (float)Math.Max(Math.Min(leafInitRatio, prntInitRatio) + 0.65f, 1.2f); }

            if (maxSprlAngl - (5 * (float)Math.PI / 4) <= angl && angl <= maxSprlAngl - ((float)Math.PI / 4)) //two mins
            {
                float peakDelta = Math.Min(angl - (maxSprlAngl - (5 * (float)Math.PI / 4)), maxSprlAngl - ((float)Math.PI / 4) - angl);
                angleRatio = 0.1f + (peakDelta / ((float)Math.PI / 2f)); //smaller when closer to a min
            }
            else
            {
                if (angl < maxSprlAngl - (5 * (float)Math.PI / 4))
                {
                    baseDistRate = angl < maxSprlAngl - (3 * (float)Math.PI / 2) ? 0.02f : 0.01f;
                    angleRatio = -1 * (maxSprlAngl - (5 * (float)Math.PI / 4) - angl) / ((float)Math.PI / 2);
                    radRatio = initLeafRatio;
                }
                //few leaves can fit closer than Math.PI/4, assume no distortion after this min
            }

            float adj = angleRatio * baseDistRate * radRatio;
            float x = SprlCtr.X + (scl * (angl + adj) * (float)Math.Cos((Clock * angl) + (Clock * adj) + StrtAngl));
            float y = SprlCtr.Y + (scl * (angl + adj) * (float)Math.Sin((Clock * angl) + (Clock * adj) + StrtAngl));

            leafNode.StrtPt = new FlPoint(x, y);
        }


        public float ToRelativeAngle(float angle)
        {
            float relativeArc = Trig.Mod2PI((Clock * angle) - (Clock * StrtAngl));
            return relativeArc;
        }


        public float ToAbsoluteAngle(float angle)
        {
            float absoluteArc = Trig.Mod2PI(StrtAngl + (Clock * angle));
            return absoluteArc;
        }


        public float BaseAngle(float prntRad)
        {
            if (!IsRoot)
            {
                float parentArc = (float)Math.Asin(prntRad / (prntRad + Rad)); //half of parent projection onto node
                return StrtAngl - (Clock * parentArc);
            }
            else { return -100; }
        }


        public float RootBaseAngle(int rootIdx, float rootDist)
        {
            float rootBase = Configs.TWIN ? Configs.RootBaseArc(rootIdx, rootDist) : Configs.startAt + Configs.shiftFactor;
            return Trig.Mod2PI(StrtAngl - (Clock * rootBase));
        }


        public float RemainingArcAfter(float Angl)
        {
            float remainingArc = ToRelativeAngle(Angl) - Configs.endAt;
            return remainingArc;
        }


        public bool HasRoomFor(float leafArc)
        {
            if (!CanGrow) { return false; }
            if (LeafCount() == 0) { return true; }

            float remainingArc = RemainingArcAfter(LastLeafAngle());
            return remainingArc >= leafArc;
        }


        //tiny leaves grown on the portion of the spiral curling below outer circle radius
        //need double padding, or they look too crowded
        public bool DoubleTheGap()
        {
            float remainingArc = RemainingArcAfter(LastLeafAngle());
            return remainingArc <= (2f / 7f) * (float)Math.PI;
        }


        //fairly rough approximation, not like calcNodeLift
        public float RadAtAngle(float approachAngl)
        {
            //range (experimentally determined) where the spiral "protrudes" above the edge of
            //the base circle used by BFSTree to pack leaves
            float[] liftUseRange = new float[2] { 17f / 24f * (float)Math.PI, 5f / 4f * (float)Math.PI };
            if (AngleInArc(approachAngl, liftUseRange[0], liftUseRange[1]))
            {
                //for smaller nodes, using Math.Ceiling will make a proportionally larger difference
                //which is the goal, as they will generate a smaller correction and get too close 
                return (float)Math.Ceiling(Rad * 1.08f);
            } //1.08f is experimentally determined

            //range (experimentally determined) where the spiral "curls in" and outer radius grows
            //much smaller than the base circle used by BFSTree to pack leaves
            float[] closerFitRange = new float[2] { 1f / 8f * (float)Math.PI, 5f / 8f * (float)Math.PI };
            if (AngleInArc(approachAngl, closerFitRange[0], closerFitRange[1]))
            {
                float _x = SprlCtr.X + ((float)Math.Cos(approachAngl) * (8f / 10f * Rad));
                float _y = SprlCtr.Y + ((float)Math.Sin(approachAngl) * (8f / 10f * Rad));
                return Trig.PointDist(Ctr.X, Ctr.Y, _x, _y);
            }
            //else
            return Rad;

            bool AngleInArc(float testAngl, float scanFrom, float scanTo)
            {
                //provided range is already relative, no need to convert that
                //except for orienting to clock direction
                float newTest = ToRelativeAngle(testAngl);

                if (Clock > 0)
                {
                    return scanFrom < newTest && newTest < scanTo;
                }
                else
                {
                    scanFrom = Trig.Mod2PI(-scanFrom);
                    scanTo = Trig.Mod2PI(-scanTo);
                    newTest = Trig.Mod2PI(-newTest);
                    return scanFrom > newTest && newTest > scanTo;
                }
            }
        }

        public static float GetSkinDistToPt(SpiralNode newLeaf, FlPoint edgePt)
        {
            float distBetween = Trig.PointDist(newLeaf.Ctr, edgePt);
            float anglToLeaf = Trig.AngleToPoint(newLeaf.Ctr, edgePt);
            float leafSurfc = newLeaf.RadAtAngle(anglToLeaf);

            return distBetween - leafSurfc;
        }

        public static float GetSurfaceDist(SpiralNode newLeaf, SpiralNode idxNode)
        {
            float distBetween = Trig.PointDist(newLeaf.Ctr, idxNode.Ctr);
            float anglToLeaf = Trig.AngleToPoint(newLeaf.Ctr, idxNode.Ctr);
            float anglToNode = Trig.ComplementAngle(anglToLeaf);
            float leafSurfc = newLeaf.RadAtAngle(anglToLeaf);
            float nodeSurfc = idxNode.RadAtAngle(anglToNode);

            return distBetween - (nodeSurfc + leafSurfc);
        }


        //parent node has a sibling right next to it, restricting leaf growth
        public int ObstructingSibIdx(int idx)
        {
            int lastSibIdx = idx + 1;
            return LeafIdxs.Count > 0 &&
                LeafIdxs.Contains(idx) &&
                LeafIdxs.Contains(lastSibIdx)
                ? lastSibIdx
                : -1;
        }


        public void MarkParent(SpiralNode newLeaf, int leafIdx)
        {
            float leafAngl = Trig.ComplementAngle(newLeaf.StrtAngl);

            LeafIdxs.Add(leafIdx);
            LeafAngls.Add(leafAngl);
            CreateLeafPt(newLeaf);  //node is attached, good time to do this
        }


        public float CalcNodeLift(float leafRad, float anglToLeaf)
        {
            float scl = 0.099f;
            float sclRad = Rad * scl;
            float maxSprlAngl = 2f * (float)Math.Tau;
            int prntClock = Clock;

            float angl = maxSprlAngl - Trig.Mod2PI(-1 * ToRelativeAngle(anglToLeaf));

            float mult = angl > maxSprlAngl - (Math.PI / 3) ? 0.05f : 0.05f * Math.Max((angl / ((float)Math.PI / 2)) - 2f, 0f);
            float radRatio = Math.Max((Rad / Configs.initRadius) - (leafRad / Rad), Configs.initRadius / Rad);
            float adj = prntClock * mult * radRatio * angl / maxSprlAngl;

            float x = SprlCtr.X + (sclRad * (angl + adj) * (float)Math.Cos((prntClock * angl) + (prntClock * adj) + StrtAngl));
            float y = SprlCtr.Y + (sclRad * (angl + adj) * (float)Math.Sin((prntClock * angl) + (prntClock * adj) + StrtAngl));

            float prntLift = Trig.PointDist(Ctr.X, Ctr.Y, x, y) - Rad;
            float leafLift = leafRad * 0.123f;
            if (Rad < Configs.minRadius) { leafLift *= 1.1f; }

            return prntLift + leafLift;
        }

        public bool AngleInSproutRange(float testAngl)
        {
            float scanFrom = Configs.sproutAngle;
            float limitAngl = Configs.sproutMaxAngle;
            float newTest = Trig.Mod2PI(testAngl - StrtAngl);
            int direction = -1 * Clock;

            return scanFrom * direction < newTest * direction && newTest * direction < limitAngl * direction;
        }

        public bool AngleInGrowthRange(float scanFrom, float testAngl)
        {
            float newScanFrom = Trig.Mod2PI(scanFrom - StrtAngl);
            float newTest = Trig.Mod2PI(testAngl - StrtAngl);
            float newEnd = Trig.Mod2PI(EndAngl - StrtAngl);
            int direction = -1 * Clock;

            return newScanFrom * direction < newTest * direction && newTest * direction < newEnd * direction;
        }


        public float NextLeafAngle(float leafRad, float baseAngl, int inSlot = -1)
        {

            if ((Configs.maxLeaves < Configs.slotSizes.Count || Configs.RANDNUM)
                || (Configs.shiftFactor != 0 && !HasLeaves))
            {
                if (inSlot < 0) { inSlot = 0; }
                float newBase = AngleFromSlotList(baseAngl, inSlot);
                if (newBase != -100) { baseAngl = newBase; }
            }

            float leafArc = Trig.CalcLeafArcSpan(Rad, leafRad); //minimum arc necessary to fit leaf

            if (Configs.GRAD && !Configs.SMTOLG && DoubleTheGap())
            { leafArc = (2 * Configs.nodeHalo) + leafArc; }

            if (!HasRoomFor(leafArc * 1.75f)) { return -100; } //.Full check is included

            if (LeafCount() == 0)
            {
                if (!IsRoot) { leafArc = Configs.nodeHalo + leafArc; }
                else if (Configs.CanDecreaseLeafArc(IsTwin)) { leafArc = 0.9f * leafArc; }
            }

            float nextLeafAngl = Trig.Mod2PI(baseAngl - (Clock * leafArc));
            return nextLeafAngl;
        }


        private float AngleFromSlotList(float baseAngl, int currSlot)
        {
            if (currSlot < 0) { return -100; }

            float baseSlotAngl = Configs.slotAngles[currSlot] + (0.5f * Configs.slotSizes[currSlot]);
            if (Configs.SMTOLG)
            {
                baseSlotAngl += 0.5f * Configs.slotSizes.Min();
            }
            float slotAngl = Trig.Mod2PI((Clock * baseSlotAngl) + StrtAngl);

            return AngleInGrowthRange(baseAngl, slotAngl) ? slotAngl : -100;
        }


        public int CorrectedSlot(float atAngl, float leafRad)
        {
            float leafArc = Trig.CalcLeafArcSpan(Rad, leafRad);
            float tstAngl = ToRelativeAngle(atAngl) + (Clock * leafArc);
            int leafSlot = Configs.FindNextSlot(tstAngl);
            return leafSlot;
        }


        public int NextLeafSlot(float atAngl = -100, int maxNumLeaves = 0)
        {
            if (atAngl == -100) { return Configs.slotSizes.Count - 1; }

            if (Configs.RANDNUM)
            {
                return PickSlotFromList(maxNumLeaves, Configs.slotSizes.Count);
            }
            if (Configs.maxLeaves < Configs.slotSizes.Count)
            {
                return Configs.useSlots.Max();
            }

            float tstAngl = Trig.Mod2PI((Clock * atAngl) - (Clock * StrtAngl));
            int nextSlot = Configs.FindNextSlot(tstAngl);
            return nextSlot;
        }


        public int NextLeafSlot(int currSlot, int maxNumLeaves = 0)
        {
            if (Configs.maxLeaves < Configs.slotSizes.Count || Configs.RANDNUM)
            {
                return PickSlotFromList(maxNumLeaves, currSlot);
            }

            int nextSlot = 0;
            if (currSlot > 0) { nextSlot = currSlot - 1; }
            return nextSlot;
        }


        private int PickSlotFromList(int maxNumLeaves, int currSlot)
        {
            if (LeafCount() == 0 && !Configs.RANDNUM) { return Configs.useSlots.Max(); } //good even for RANDNUM
            if (currSlot == 0) { return 0; } //it's not getting any smaller!
            if (maxNumLeaves == 0) { maxNumLeaves = Configs.slotSizes.Count; }

            List<int> slotLst;
            if (!Configs.RANDNUM) { slotLst = Configs.useSlots; }
            else
            {
                slotLst = Configs.GetSlotList(maxNumLeaves);
                slotLst.Reverse();
            }

            int nxtSlotIdx = slotLst.FindIndex(x => x < currSlot);
            return nxtSlotIdx == -1 ? currSlot - 1 : slotLst[nxtSlotIdx];
        }


        public float ReslotAngl(int currSlot, bool decrement = true)
        {
            if (!decrement && currSlot >= 0)
            {
                float slotAngl = Configs.slotAngles[currSlot];
                return Trig.Mod2PI((Clock * slotAngl) + StrtAngl);
            }
            if (decrement && currSlot > 0)
            {
                float slotAngl = Configs.slotAngles[currSlot - 1];
                return Trig.Mod2PI((Clock * slotAngl) + StrtAngl);
            }
            else { return -100; }
        }


        public void AdjustLeaf(SpiralNode prntNode, float tryAngleFromParent, int newSlot, Random? rnd = null)//this. is leaf
        {
            if (Configs.GRAD) //radius usually changes based on slot#
            {
                float updatedRad = Rad;
                if (Slot != newSlot)  //not trying to keep radius from changing based on slot#
                {
                    updatedRad = Configs.NextLeafRad(prntNode.Rad, newSlot, rnd!);
                    Slot = newSlot;
                }
                Lift = prntNode.CalcNodeLift(updatedRad, tryAngleFromParent);
                Recenter(prntNode.Ctr, prntNode.Rad, tryAngleFromParent, updatedRad);
            }
            else
            {   //radius stays the same, but the following angles may be affected
                if (Slot != newSlot) { Slot = newSlot; }
                Lift = prntNode.CalcNodeLift(Rad, tryAngleFromParent);
                Recenter(prntNode.Ctr, prntNode.Rad, tryAngleFromParent);
            }

            //existing values are no longer valid for new center: 
            NhbrIdxs = new List<int>();
            NhbrDists = new List<float>();
            EdgeDists = new List<float>();
            EdgePoints = new List<FlPoint>();
            EdgeDists.AddRange(prntNode.EdgeDists);
            EdgePoints.AddRange(prntNode.EdgePoints);
        }


        public static float SibConflictAngle(SpiralNode idxNode, SpiralNode problemSib)
        {
            float sibDist = Trig.PointDist(idxNode.Ctr, problemSib.Ctr);
            float anglToSib = Trig.AngleToPoint(idxNode.Ctr, problemSib.Ctr);

            //must account for case of big gap after last sib (like due to edge proximity)
            if (sibDist < (2.5 * idxNode.Rad) + problemSib.Rad) //sibling close enough to matter
            {
                float lastSibArc = Configs.nodeHalo + (float)Math.Asin(problemSib.Rad / sibDist); //sibling projection onto node
                float firstOpen = anglToSib - (idxNode.Clock * lastSibArc);
                return firstOpen;
            }
            else
            {
                return -100;
            }
        }


        public FlPoint[] PlotSpiralFlPoints()
        {
            float x;
            float y;
            float theta = 0f;
            float maxTheta = (2f * (float)Math.Tau) - 0.1f;
            float incr = 0.1f;
            float scl = 0.099f * Rad;
            FlPoint anchr = StrtPt;

            List<FlPoint> spiralPoints = new();
            while (theta < maxTheta)
            {
                x = SprlCtr.X + (scl * theta * (float)Math.Cos((Clock * theta) + StrtAngl));
                y = SprlCtr.Y + (scl * theta * (float)Math.Sin((Clock * theta) + StrtAngl));

                theta += incr;
                spiralPoints.Add(new FlPoint(x, y));
            }
            spiralPoints.Add(new FlPoint(anchr.X, anchr.Y));
            return spiralPoints.ToArray();
        }
    }
}