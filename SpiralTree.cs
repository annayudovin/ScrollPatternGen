namespace BFSSpiralTree
{
    public class SpiralTree
    {
        private List<SpiralNode> Nodes { get; set; } = new List<SpiralNode>();
        private readonly Polygon _container;
        private readonly Random _rnd;
        private string _treeLog = "";

        public SpiralNode this[int i]
        {
            get => Nodes[i];
            set => Nodes[i] = value;
        }

        public int Count => Nodes.Count;


        public SpiralTree(Polygon container, float initRad = 0)
        {
            _rnd = new Random();
            Configs.InitAll(_rnd);
            _container = container;

            initRad = initRad == 0f ? Configs.initRadius : initRad;

            if (Configs.RANDANG) { Configs.rootAngle = Configs.Random(0f, (float)Math.Tau, _rnd); }
            float initAngl = Configs.rootAngle;

            if (Configs.TWIN)
            {
                GrowTwins(_container.Centroid, initRad, initAngl, Configs.twinRatio);
            }
            else
            {
                SpiralNode root = new(_container.Centroid, initRad, initAngl);
                Nodes.Add(root);
                _ = CheckEdgeFit(root); //initialize edge data

                float angl = 2f * (float)Math.Tau;
                float x = root.SprlCtr.X + (root.Rad * 0.099f * angl * (float)Math.Cos(angl + root.StrtAngl));
                float y = root.SprlCtr.Y + (root.Rad * 0.099f * angl * (float)Math.Sin(angl + root.StrtAngl));
                root.StrtPt = new FlPoint(x, y);
            }
        }


        public void CreateLog()
        {
            if (!Configs.LOG) { return; }

            string dName = AppDirectoryPath();
            if (dName == "") { return; }

            string fName = "treeLog.txt";
            string fPath = Path.Combine(dName, fName);

            if (!File.Exists(fPath))
            {
                // Create a file to write to.
                using StreamWriter sw = File.CreateText(fPath);
                sw.Write(Configs.LogProperties());
                sw.Write(_container.PrintPolygon());
            }
            else
            {
                using StreamWriter sw = new(fPath, true);
                sw.Write(Configs.LogProperties());
                sw.Write(_container.PrintPolygon());
            }
        }


        public void AddToLog(string lgString)
        {
            _treeLog += lgString;
        }


        public void WriteLog()
        {
            if (!Configs.LOG) { return; }

            string dName = AppDirectoryPath();
            if (dName == "") { return; }

            string fName = "treeLog.txt";
            string fPath = Path.Combine(dName, fName);

            if (!File.Exists(fPath))
            {
                // Create a file to write to.
                using StreamWriter sw = File.CreateText(fPath);
                sw.Write(_treeLog);
            }
            else
            {
                using StreamWriter sw = new(fPath, true);
                sw.Write(_treeLog);
            }
        }


        public List<FlPoint[]> PlotSpiralTreePoints()
        {
            List<FlPoint[]> spiralFlPtsLst = new();
            foreach (SpiralNode node in Nodes)
            {
                FlPoint[] spiralFlPts = node.PlotSpiralFlPoints();
                spiralFlPtsLst.Add(spiralFlPts);
            }

            return spiralFlPtsLst;
        }


        //let the app make sure we have/can create a MyDocuments
        //directory to put files into - and produce appropriate error messages
        public static string AppDirectoryPath()
        {
            string myDocsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string appFolderName = "ScrollGenerator";
            string dirPath = Path.Combine(myDocsPath, appFolderName);

            return !Directory.Exists(dirPath) ? "" : dirPath;
        }


        //this overload uses cached points list to avoid recalculating everything again 
        public static void WriteSVG(List<FlPoint[]> spiralPtsLst, int boxWidth, int boxHeight, string scrollColor, int strokeWidth)
        {
            string dName = AppDirectoryPath();
            if (dName == "") { return; }

            string timeStmp = DateTime.Now.ToString("s").Replace(':', '-').Replace('T', '-');
            string fName = $"scroll-{timeStmp}.svg";
            string fPath = Path.Combine(dName, fName);

            if (!File.Exists(fPath))
            {
                using StreamWriter sw = File.CreateText(fPath);
                sw.Write(buildSVG(spiralPtsLst, boxWidth, boxHeight, scrollColor, strokeWidth));
            }

            static string buildSVG(List<FlPoint[]> spiralPtsLst, int boxWidth, int boxHeight, string scrollColor, int strokeWidth)
            {
                string svgFileString = $"<svg width=\"{boxWidth}\" height=\"{boxHeight}\" " +
                                        $"viewBox=\"0 0 {boxWidth} {boxHeight}\">\n";
                string sprlStrtString = $"  <path style=\"fill:none; stroke:{scrollColor}; stroke-width:{strokeWidth}\"\n    d=\"";
                string sprlEndString = $"\">\n  </path>\n";
                string sprlPtsString = "";

                foreach (FlPoint[] arry in spiralPtsLst)
                {
                    sprlPtsString += sprlStrtString;
                    sprlPtsString += $"M {arry[0].X},{arry[0].Y} ";
                    sprlPtsString += $"C {arry[0].X},{arry[0].Y}";

                    foreach (FlPoint pt in arry[1..]) { sprlPtsString += $" {pt.X},{pt.Y}"; }
                    sprlPtsString += sprlEndString;
                }
                svgFileString += sprlPtsString;
                svgFileString += "</svg>";

                return svgFileString;
            }
        }


        public void WriteSVG(int boxWidth, int boxHeight, string scrollColor, int strokeWidth)
        {
            string dName = AppDirectoryPath();
            if (dName == "") { return; }

            string timeStmp = DateTime.Now.ToString("s").Replace(':', '-').Replace('T', '-');
            string fName = $"scroll-{timeStmp}.svg";
            string fPath = Path.Combine(dName, fName);

            if (!File.Exists(fPath))
            {
                using StreamWriter sw = File.CreateText(fPath);
                sw.Write(buildSVG(boxWidth, boxHeight, scrollColor, strokeWidth));
            }

            string buildSVG(int boxWidth, int boxHeight, string scrollColor, int strokeWidth)
            {
                string svgFileString = $"<svg width=\"{boxWidth}\" height=\"{boxHeight}\" " +
                                        $"viewBox=\"0 0 {boxWidth} {boxHeight}\">\n";
                string sprlStrtString = $"  <path style=\"fill:none; stroke:{scrollColor}; stroke-width:{strokeWidth}\"\n    d=\"";
                string sprlEndString = $"\">\n  </path>\n";
                string sprlPtsString = "";

                foreach (SpiralNode node in Nodes)
                {
                    FlPoint[] spiralPts = node.PlotSpiralFlPoints();

                    sprlPtsString += sprlStrtString;
                    sprlPtsString += $"M {spiralPts[0].X},{spiralPts[0].Y} ";
                    sprlPtsString += $"C {spiralPts[0].X},{spiralPts[0].Y}";

                    foreach (FlPoint pt in spiralPts[1..]) { sprlPtsString += $" {pt.X},{pt.Y}"; }
                    sprlPtsString += sprlEndString;
                }
                svgFileString += sprlPtsString;
                svgFileString += "</svg>";

                return svgFileString;
            }
        }


        private static List<FlPoint> CenterPair(FlPoint initCtr, float strtAngl, float rad1, float rad2)
        {
            float ctr1X = initCtr.X + ((float)Math.Cos(strtAngl) * rad1);
            float ctr1Y = initCtr.Y + ((float)Math.Sin(strtAngl) * rad1);
            float shiftAngl = 0.05f;
            float ctr2X = initCtr.X + ((float)Math.Cos(Trig.ComplementAngle(strtAngl + shiftAngl)) *
                          (rad2 + Configs.rootBuffer));
            float ctr2Y = initCtr.Y + ((float)Math.Sin(Trig.ComplementAngle(strtAngl + shiftAngl)) *
                          (rad2 + Configs.rootBuffer));

            return new List<FlPoint>() { new FlPoint(ctr1X, ctr1Y), new FlPoint(ctr2X, ctr2Y) };
        }


        public void GrowTwins(FlPoint initCtr, float rad, float strtAngl, float twinScale = 1)
        {
            if (!Configs.TWIN) { return; }

            if (twinScale > 1) { twinScale = 1f; }
            if (twinScale < 0.6) { twinScale = 0.6f; }

            List<FlPoint> ctrLst = CenterPair(initCtr, strtAngl, rad, rad * twinScale);
            FlPoint ctr1 = ctrLst[1];
            FlPoint ctr2 = ctrLst[0];

            SpiralNode root = new(ctr1, rad, strtAngl);
            Nodes.Add(root);
            _ = CheckEdgeFit(root);
            SpiralNode twin = new(ctr2, rad * twinScale, Trig.ComplementAngle(strtAngl), true);
            if (CheckEdgeFit(twin)) { Nodes.Add(twin); }

            //average the two roots' start points, for smoother transition
            float avgX = (root.StrtPt.X + twin.StrtPt.X) / 2;
            float avgY = (root.StrtPt.Y + twin.StrtPt.Y) / 2;

            root.StrtPt = new FlPoint(avgX, avgY);
            twin.StrtPt = new FlPoint(avgX, avgY);
        }


        public float FirstOpenAngl(int idx)
        {
            SpiralNode idxNode = Nodes[idx];

            //first leaf on a root node
            if (!idxNode.HasLeaves && idxNode.PrntIdx == -1)
            {
                float rootDist = 0;
                if (Configs.TWIN)
                { rootDist = Trig.PointDist(Nodes[0].Ctr, Nodes[1].Ctr); }
                return idxNode.RootBaseAngle(idx, rootDist);
            }

            float firstOpen;
            if (!idxNode.HasLeaves) //first leaf on index node 
            {
                SpiralNode prntNode = Nodes[idxNode.PrntIdx];
                int problemSibIdx = prntNode.ObstructingSibIdx(idx);
                if (problemSibIdx != -1)
                { //index node's parent has an obstructing sibling
                    SpiralNode problemSibNode = Nodes[problemSibIdx];
                    float problemSibAngle = SpiralNode.SibConflictAngle(idxNode, problemSibNode);
                    return problemSibAngle != -100 ? problemSibAngle : idxNode.BaseAngle(prntNode.Rad);//sibling too far away to obstruct leaves
                }
                else //index node has no obstructing siblings
                { return idxNode.BaseAngle(prntNode.Rad); }
            }
            else
            {
                int prevLeafIdx = idxNode.LastLeafIdx();
                float prevLeafAngl = idxNode.LastLeafAngle();
                float prevLeafRad = Nodes[prevLeafIdx].Rad;
                float prevLeafArc = Trig.CalcLeafArcSpan(idxNode.Rad, prevLeafRad);

                firstOpen = prevLeafAngl - (idxNode.Clock * (Configs.nodeHalo + prevLeafArc));
            }
            return Trig.Mod2PI(firstOpen);
        }


        public bool CheckFit(SpiralNode newLeaf)
        {

            bool fitsNhbrs = CheckNhbrFit(newLeaf);
            bool fitsEdges = CheckEdgeFit(newLeaf);

            return fitsNhbrs && fitsEdges;
        }


        public bool CheckNhbrFit(SpiralNode newLeaf)
        {
            int leafPrntIdx = newLeaf.PrntIdx;

            //for testing fit check:
            //newLeaf.TmpNhbrIdxs.Clear();
            //newLeaf.TmpNhbrDists.Clear();

            //scan for nodes that collide with leaf
            for (int idx = 0; idx < Nodes.Count; idx++)
            {
                if (leafPrntIdx == idx) { continue; }//parent isn't a neighbor

                SpiralNode curr = Nodes[idx];
                float skinDistToLeaf = SpiralNode.GetSurfaceDist(newLeaf, curr);
                float cutoff = 0.75f * Configs.nodeBuffer;

                //collision cutoff is smaller for sibling 
                if (leafPrntIdx == curr.PrntIdx) { cutoff = 0.5f * Configs.nodeBuffer; }

                //if (skinDistToLeaf < 10) //for testing fit check
                //{
                //    newLeaf.TmpNhbrIdxs.Add(idx);
                //    newLeaf.TmpNhbrDists.Add(skinDistToLeaf);
                //}

                if (skinDistToLeaf < cutoff) //collision check
                {
                    newLeaf.NhbrIdxs.Add(idx);
                    newLeaf.NhbrDists.Add(skinDistToLeaf);
                }
            }

            //leaf won't fit as is, needs further adjustment
            return newLeaf.NhbrIdxs.Count <= 0;
        }


        public bool CheckEdgeFit(SpiralNode newLeaf)
        {
            FlPoint closestPt;

            List<float> edgeDists = new();
            List<FlPoint> edgePoints = new();

            List<float> prntEdgeDists = new();
            FlPoint prntCtr = new(0, 0);
            float maxLeafFitDist = 0f;
            if (newLeaf.PrntIdx != -1)
            {
                SpiralNode prntNode = Nodes[newLeaf.PrntIdx];
                float prntRad = prntNode.Rad;
                prntCtr = prntNode.Ctr;
                prntEdgeDists.AddRange(prntNode.EdgeDists);
                maxLeafFitDist = prntRad + (2 * newLeaf.Rad) + newLeaf.Lift + Configs.nodeBuffer;
            }

            for (int idx = 0; idx < _container.Edges.Count; idx++)
            {
                Polygon.FlEdge edge = _container.Edges[idx];
                bool jumpedEdge = false;
                if (newLeaf.PrntIdx != -1) //root nodes have no parent: can't do this check
                {
                    if (Math.Abs(prntEdgeDists[idx]) < maxLeafFitDist) //parent is close enough to edge to warrant checking
                    {
                        jumpedEdge = edge.CrossEdge(prntCtr, newLeaf.Ctr);
                    }
                }

                Tuple<float, FlPoint> result = edge.DistanceToEdge(newLeaf.Ctr);
                float edgeDist = result.Item1;
                closestPt = result.Item2;
                float skinEdgeDist = SpiralNode.GetSkinDistToPt(newLeaf, closestPt);
                //found a deal breaker
                if (jumpedEdge || skinEdgeDist < Configs.nodeBuffer / 2) { edgeDist = 0; }
                edgeDists.Add(Math.Abs(edgeDist));
                edgePoints.Add(closestPt);
            }
            //at this point edgeDists/edgePoints contains [corrected] copy of leaf's parent's data
            //overwrite existing [inherited] data from leaf with updated data
            newLeaf.EdgeDists = edgeDists;
            newLeaf.EdgePoints = edgePoints;

            return !newLeaf.EdgeDists.Contains(0);
        }


        public List<float> GetEdgeFitAngles(SpiralNode newLeaf, SpiralNode prntNode, bool limited = false)
        {
            List<float> edgeFitAngls = new();
            float initStartAngl = FirstOpenAngl(newLeaf.PrntIdx);

            int edgeIdx = 0;
            int problemEdgeCount = newLeaf.EdgeDists.Count(x => x == 0);

            //get idx of either the closest (to leaf) edge or, most likely case: the only one with conflict
            if (problemEdgeCount == 1) { edgeIdx = newLeaf.EdgeDists.FindIndex(x => x == 0); }
            if (problemEdgeCount > 1)   //case of multiple conflicting edges
            {
                IEnumerable<(int idx, float dist)> edgePtDistFltr =
                    newLeaf.EdgePoints.Select((x, i) => (i, Trig.PointDist(x, newLeaf.Ctr)));
                List<(int idx, float dist)> edgePtDists = edgePtDistFltr.ToList();
                edgePtDists.Sort((a, b) => a.dist > b.dist ? 1 : a.dist < b.dist ? -1 : 0);    //ascending by dist

                (int idx, float dist) = edgePtDists[0];
                edgeIdx = idx;  //index of edge closest to leaf
            }

            float edgeArc = Trig.EdgeFitArc(prntNode.EdgePoints[edgeIdx], prntNode.Ctr, prntNode.Rad, newLeaf.Rad, newLeaf.Lift);
            if (edgeArc == -100) { return edgeFitAngls; }

            float anglFromPrnt = Trig.AngleToPoint(prntNode.Ctr, prntNode.EdgePoints[edgeIdx]);
            //check BOTH possible angles around leaf tangent
            //Clock multiplier should ensure that the option going in the direction of leaf growth
            //(decreasing angles for positive Clock) will be first in list. If both options are valid
            //(and both work potentially fit), second option in the list is tried first and kept if works
            //therefore, *this* leaf will fit before the edge, and the next one (if any), AFTER it
            float angleToFit1 = Trig.Mod2PI(anglFromPrnt + prntNode.Clock * edgeArc);
            float angleToFit2 = Trig.Mod2PI(anglFromPrnt - prntNode.Clock * edgeArc);
            (int idx, float pAng, float arc) edgeInfo = Configs.LOG ? (edgeIdx, anglFromPrnt, edgeArc) : (-1, -100, -100);

            bool inRange = limited ? prntNode.AngleInSproutRange(angleToFit1) : prntNode.AngleInGrowthRange(initStartAngl, angleToFit1);
            if (inRange) { edgeFitAngls.Add(angleToFit1); }
            (float angl, bool ok) fitAngl1Info = Configs.LOG ? (angleToFit1, inRange) : (-100, false);

            inRange = limited ? prntNode.AngleInSproutRange(angleToFit2) : prntNode.AngleInGrowthRange(initStartAngl, angleToFit2);
            if (inRange) { edgeFitAngls.Add(angleToFit2); }
            (float angl, bool ok) fitAngl2Info = Configs.LOG ? (angleToFit2, inRange) : (-100, false);

            if (Configs.LOG) { LogEdgeAdjst(edgeInfo, fitAngl1Info, fitAngl2Info); }
            return edgeFitAngls;
        }


        public bool TryAdjustToEdges(ref SpiralNode newLeaf, SpiralNode prntNode, bool limited = false)
        {
            bool fitsAll;
            int newSlot;
            List<float> edgeFitAngls = GetEdgeFitAngles(newLeaf, prntNode, limited);
            if (edgeFitAngls.Count > 0)
            {
                if (edgeFitAngls.Count == 2) //if there are two, try second to start
                {
                    float trySecond = edgeFitAngls[1];

                    newSlot = prntNode.CorrectedSlot(trySecond, newLeaf.Rad);
                    if (Configs.GRAD && Configs.SMTOLG) { newLeaf.Slot = newSlot; }

                    newLeaf.AdjustLeaf(prntNode, trySecond, newSlot, _rnd);
                    fitsAll = CheckFit(newLeaf);
                    if (Configs.LOG) { LogEdgeAdjst((-1, -100, -100), (trySecond, fitsAll), (-100, false)); }
                    if (fitsAll) { return true; }

                }
                //now try either the one remaining or the only one we had
                float tryAngle = edgeFitAngls[0];
                newSlot = prntNode.CorrectedSlot(tryAngle, newLeaf.Rad);
                if (Configs.GRAD && Configs.SMTOLG) { newLeaf.Slot = newSlot; }

                newLeaf.AdjustLeaf(prntNode, tryAngle, newSlot, _rnd);
                fitsAll = CheckFit(newLeaf);  //caller will check neighbors on this one
                if (Configs.LOG) { LogEdgeAdjst((-1, -100, -100), (tryAngle, fitsAll), (-100, false)); }
                return fitsAll;  //caller will check neighbors on this one
            }
            else { return false; }  //no valid resolutions exist, bail
        }


        public void LogEdgeAdjst((int idx, float pAng, float arc) edgeInfo,
                                  (float angl, bool ok) fitAngl1Info,
                                  (float angl, bool ok) fitAngl2Info)
        {
            if (!Configs.LOG) { return; }
            bool firstPass = false;
            string prntLg = "";
            string ft1Lg = "";
            string ft2Lg = "";

            if (edgeInfo.idx != -1)
            {
                firstPass = true;
                prntLg = $"angle from leaf's parent to edge#{edgeInfo.idx}: {edgeInfo.pAng:F3}, " +
                        $"edge fit arc: {edgeInfo.arc:F3} produced fit angles: ";
            }

            if (fitAngl1Info.angl != -100)
            {
                if (firstPass)
                {
                    ft1Lg = $"{fitAngl1Info.angl:F3} ";
                    if (!fitAngl1Info.ok) { ft1Lg += "(out of range) "; }
                }
                else
                {
                    ft1Lg = $"adjusting leaf's start angle to {fitAngl1Info.angl:F3} ";
                    if (fitAngl1Info.ok) { ft1Lg += "resolved all existing conflicts"; }
                    else { ft1Lg += "did not resolve all existing conflicts"; }
                }
            }

            if (fitAngl2Info.angl != -100)
            {
                ft2Lg = $"and {fitAngl2Info.angl:F3} ";
                if (!fitAngl2Info.ok) { ft2Lg += "(out of range)"; }
            }

            AddToLog(prntLg + ft1Lg + ft2Lg + "\n");
        }


        public bool TryAdjustToNhbrs(ref SpiralNode newLeaf, SpiralNode prntNode, bool aftrRslt = false, bool limited = false)
        {
            int maxTries = Configs.useSlots.Count;
            int prevConflictCount = newLeaf.NhbrIdxs.Count;
            List<float> alreadyTried = new();
            bool startFits = false;     //that's why we are here 

            while (!startFits && newLeaf.NhbrIdxs.Count > 0 && maxTries > 0)
            {
                maxTries--; //convenient limit counter

                //only edge conflicts
                if (newLeaf.NhbrIdxs.Count == 0 && newLeaf.EdgeDists.Contains(0)) { return false; }

                float prevDistSum = newLeaf.NhbrDists.Sum();
                float minNhbrDist = newLeaf.NhbrDists.Min();
                if (minNhbrDist > Configs.nodeBuffer * 0.2)    //a VERY small problem
                {
                    float initStartAngl = Trig.ComplementAngle(newLeaf.StrtAngl);
                    float tryAngle = Trig.Mod2PI(initStartAngl + (prntNode.Clock * 1.5f * Configs.nodeHalo));
                    if (Configs.LOG)
                    {
                        int lowestDistIdx = newLeaf.NhbrDists.FindIndex(x => x == minNhbrDist);
                        int nhbrIdx = newLeaf.NhbrIdxs[lowestDistIdx];
                        AddToLog($"attempt minimal adjustment to neighbor {nhbrIdx} (minNhbrDist={minNhbrDist:F3})\n");
                    }
                    newLeaf.AdjustLeaf(prntNode, tryAngle, newLeaf.Slot, _rnd);
                    startFits = CheckFit(newLeaf);
                    if (startFits)
                    {
                        if (Configs.LOG) { AddToLog($"minimal adjustment worked for idx: {Nodes.Count}\n"); }
                        return true;
                    }
                    else if (newLeaf.NhbrIdxs.Count == 0) { return false; } //it's no longer neighbor problems
                }

                float nhbrFitAngl = GetNeighborFitAngle(newLeaf, prntNode, aftrRslt);
                if (limited && !aftrRslt)
                {
                    if (!prntNode.AngleInSproutRange(nhbrFitAngl))
                    {
                        if (Configs.LOG) { AddToLog($"maximum adjustment for resprouted leaf exceeded. Gave up.\n"); }
                        return false;
                    }
                }

                //no [new] resolutions offered, bail
                if (nhbrFitAngl != -100)
                {
                    if (alreadyTried.Contains(nhbrFitAngl))
                    {
                        if (Configs.LOG) { AddToLog($"no new solutions found, giving up.\n"); }
                        return false;
                    }
                }
                else
                {
                    if (Configs.LOG) { AddToLog($"no good alternatives found, giving up.\n"); }
                    return false;
                }

                int newSlot = prntNode.CorrectedSlot(nhbrFitAngl, newLeaf.Rad);
                if (Math.Abs(newLeaf.Slot - newSlot) > 2)
                {
                    if (Configs.LOG)
                    {
                        string sltLog = $"at this angle, leaf slot should be {newSlot}, current slot {newLeaf.Slot}\n";
                        sltLog += "unsuitable adjustment scale, giving up. ";
                        AddToLog(sltLog);
                    }
                    return false;
                }

                alreadyTried.Add(nhbrFitAngl);
                if (!aftrRslt)
                {
                    if (Configs.GRAD && Configs.SMTOLG) { newLeaf.Slot = newSlot; }
                    newLeaf.AdjustLeaf(prntNode, nhbrFitAngl, newSlot, _rnd);
                    startFits = CheckFit(newLeaf);  //leaf has been re-centered, check fit again
                }
                else
                {//this is where we can try backing up, but if this doesn't work, ditch the copy and
                 //start over like it never happened
                    aftrRslt = false; //after the first pass, this will become a problem if true
                    SpiralNode copy1 = new(newLeaf);
                    if (Configs.GRAD && !Configs.SMTOLG) { copy1.Slot = newSlot; }
                    copy1.AdjustLeaf(prntNode, nhbrFitAngl, newSlot, _rnd);
                    startFits = CheckFit(copy1);  //leaf has been re-centered, check fit again
                    if (startFits)
                    {
                        newLeaf = copy1;
                        if (Configs.LOG) { AddToLog($"adjustment worked for idx: {Nodes.Count}\n"); }
                        return true;
                    }
                }

                if (startFits)
                {
                    if (Configs.LOG) { AddToLog($"adjustment worked for idx: {Nodes.Count}\n"); }
                    return true;
                }
                else if (alreadyTried.Count > 3 && newLeaf.NhbrDists.Sum() < prevDistSum &&
                        prevConflictCount > newLeaf.NhbrIdxs.Count)
                {
                    if (Configs.LOG) { AddToLog($"adjustment attempts causing more problems, giving up.\n"); }
                    return false;
                } //attempts are making things worse
            }
            if (Configs.LOG) { AddToLog($"after exhausting maximum attempts, giving up.\n"); }
            return false;
        }



        public float GetNeighborFitAngle(SpiralNode newLeaf, SpiralNode prntNode, bool aftrRslt = false)
        {
            float firstOpenAngl = FirstOpenAngl(newLeaf.PrntIdx); //in case there are no leaves yet

            int nhbrIdx;
            float leafArc = Trig.CalcLeafArcSpan(prntNode.Rad, newLeaf.Rad);
            if (newLeaf.NhbrIdxs.Count == 1) { nhbrIdx = newLeaf.NhbrIdxs[0]; }
            else
            {
                //adjust to worst conflict first
                float minNhbrDist = newLeaf.NhbrDists.Min();
                int lowestDistIdx = newLeaf.NhbrDists.FindIndex(x => x == minNhbrDist);
                nhbrIdx = newLeaf.NhbrIdxs[lowestDistIdx];
            }

            SpiralNode nhbrNode = Nodes[nhbrIdx];
            if (Configs.LOG)
            {
                string confLog = "conflicting neighbors:\n";
                confLog += newLeaf.PrintNodeNhbrData();
                confLog += $"adjust to neighbor idx: {nhbrIdx}\n";
                AddToLog(confLog);
            }

            float fitArc = Trig.ClosestFitAngle(prntNode, newLeaf, nhbrNode);
            if (fitArc == -100f) { return -100f; }
            else
            {
                bool inRange;
                //float nhbrToPrntAngl = Trig.AngleToPoint(nhbrNode.Ctr, prntNode.Ctr);             
                float prntToNhbrAngl = Trig.AngleToPoint(prntNode.Ctr, nhbrNode.Ctr);
                if (aftrRslt)
                {
                    //first try backing up the leaf rather than moving it forward as usual
                    float angl0 = Trig.Mod2PI(prntToNhbrAngl + (prntNode.Clock * fitArc));
                    inRange = prntNode.AngleInGrowthRange(firstOpenAngl, angl0);
                    if (inRange)
                    {
                        if (Configs.LOG) { AddToLog($"attempt backing up to start angle: {angl0:F3}\n"); }
                        return angl0;
                    }
                }
                //proceed as usual
                float angl1 = Trig.Mod2PI(prntToNhbrAngl - (prntNode.Clock * fitArc));
                float remainingArc = Trig.Mod2PI(prntNode.Clock * (fitArc - prntNode.EndAngl));
                inRange = prntNode.AngleInGrowthRange(firstOpenAngl, angl1);

                if (inRange && remainingArc >= 0.5 * leafArc)
                {
                    if (Configs.LOG) { AddToLog($"attempt new start angle: {angl1:F3}\n"); }
                    return angl1;
                }
            }
            return -100;
        }


        public bool TryAdjust(ref SpiralNode newLeaf, SpiralNode prntNode, bool canBackUp, bool limited = false)
        {
            bool adjustSuccess;
            //first see if there's an edge problem
            if (newLeaf.EdgeDists.Contains(0) && newLeaf.NhbrIdxs.Count == 0)
            {
                adjustSuccess = TryAdjustToEdges(ref newLeaf, prntNode, limited);
                if (adjustSuccess) { return true; }
                if (!adjustSuccess && newLeaf.EdgeDists.Contains(0)) { return false; }
                //else: still doesn't fit, but edge problems solved - neighbors
                //may be pacified by the next block
            }

            if (newLeaf.NhbrIdxs.Count > 0)
            {
                adjustSuccess = TryAdjustToNhbrs(ref newLeaf, prntNode, canBackUp, limited);
                if (adjustSuccess) { return true; }
            }
            return false;
        }


        // make a copy, try adjusting copy - if doesn't work, discard copy, 
        // make a fresh copy, reslot copy, if still problems, make second copy - adjust second copy (of reslotted copy), if doesn't work, discard second copy, 
        // reslot first copy,  if still problems, make second copy  - adjust second copy, if doesn't work, discard
        public bool TryToFit(ref SpiralNode newLeaf, SpiralNode prntNode, bool noRslt = false)
        {
            //try going up a slot (at a new slot angle) a few times to see if it fixes the problem
            SpiralNode copy1 = new(newLeaf);
            (int slt, float rad, float angl) oldConditions = (newLeaf.Slot, newLeaf.Rad, newLeaf.StrtAngl);
            (int slt, float rad, float angl) newConditions = (0, 0f, -100f);
            float initStartAngl = Trig.ComplementAngle(newLeaf.StrtAngl);

            //ADJUST HERE
            bool canBackUp = Configs.maxLeaves <= 3;
            bool adjustSuccess = TryAdjust(ref copy1, prntNode, canBackUp, noRslt);
            if (adjustSuccess)
            {
                newLeaf = copy1;
                return true;
            }
            else
            {
                copy1 = new SpiralNode(newLeaf);
                if (noRslt) { return false; }
            }

            float newStart = initStartAngl;
            List<int> slotLst = Configs.useSlots;
            int sltIdx = slotLst.FindIndex(x => x == copy1.Slot);
            for (int i = sltIdx + 1; i < slotLst.Count; i++)
            {
                int slt = slotLst[i];

                newStart = prntNode.ReslotAngl(slt, false);  //stops reslotAngl decrementing by one
                if (newStart == -100)   //can't reslot, bail
                {
                    newConditions = (slt, 0f, -100f);
                    LogReslot(false, 2, oldConditions, newConditions);
                    return false;
                }

                //RESLOT HERE
                if (prntNode.AngleInGrowthRange(initStartAngl, newStart))
                {
                    copy1.AdjustLeaf(prntNode, newStart, slt, _rnd);
                    if (Configs.GRAD && !Configs.SMTOLG &&
                         Configs.RadTooSmall(copy1.Rad)) { return false; }

                    bool reslotSuccess = CheckFit(copy1);

                    newConditions = (copy1.Slot, copy1.Rad, copy1.StrtAngl);
                    LogReslot(reslotSuccess, 2, oldConditions, newConditions);

                    if (reslotSuccess)
                    {
                        newLeaf = copy1;
                        return true;
                    }
                    else //opt for minor adjustments over reslotting if possible
                    {
                        SpiralNode copy2 = new(copy1);
                        //ADJUST HERE
                        adjustSuccess = TryAdjust(ref copy2, prntNode, true);
                        newConditions = (copy2.Slot, copy2.Rad, copy2.StrtAngl);
                        if (!adjustSuccess) { copy2 = new SpiralNode(copy1); }
                        else
                        {
                            newLeaf = copy2;
                            return true;
                        }
                    }
                }
            }

            return false;
        }


        public void LogReslot(bool startFits, int rsltCause,
                                    (int slt, float rad, float angl) oldConditions,
                                    (int slt, float rad, float angl) newConditions)
        {
            if (!Configs.LOG) { return; }
            string lg = "";
            int oldSlot = oldConditions.slt;
            float oldRad = oldConditions.rad;
            float oldAngle = oldConditions.angl;

            int newSlot = newConditions.slt;
            float newRad = newConditions.rad;
            float newAngle = newConditions.angl;

            if (rsltCause == 2) //TryToFit
            {
                lg += $"Having failed to resolve conflicts by adjusting leaf angle, trying to fix " +
                      $"problem(s) by changing leaf slot from {oldSlot} to {newSlot};\n";
                if (startFits)
                {
                    lg += $"reslot effort successful, producing leaf radius {newRad:F3} at (new) angle {newAngle:F3}\n";
                }
                else
                {
                    lg += $"reslot effort failed";
                    if (newAngle != -100)
                    {
                        lg += $", producing leaf radius {newRad:F3} at (new) angle {newAngle:F3}";
                    }
                    lg += ".\n";
                }
            }
            if (rsltCause == 3) //attempt to increase leafRad to sufficient size for growing
            {
                lg += $"Leaf radius {oldRad:F3} too small; changed leaf slot " +
                    $"from {oldSlot} to {newSlot} to get radius={newRad:F3} " +
                    $"(start angle also changed from {oldAngle:F3} to {newAngle:F3})\n";
            }
            AddToLog(lg);
        }


        public bool GrowLeaf(SpiralNode prntNode, int prntIdx, float leafRad, float startAngle, int leafSlot, bool noRslt = false)
        {
            //if leaves get progressively smaller and the current leaf is already too small, don't bother growing any
            if (!Configs.BigEnoughToGrow(leafRad))
            {
                prntNode.Full = true;
                return false;
            }

            float lift = prntNode.CalcNodeLift(leafRad, startAngle);
            float leafCtrX = prntNode.Ctr.X + ((float)Math.Cos(startAngle) * (prntNode.Rad + leafRad + lift));
            float leafCtrY = prntNode.Ctr.Y + ((float)Math.Sin(startAngle) * (prntNode.Rad + leafRad + lift));
            SpiralNode newLeaf = new(prntIdx, prntNode.Clock, leafCtrX, leafCtrY,
                                        leafRad, Trig.ComplementAngle(startAngle), leafSlot, lift);

            //inherit parent's edge data                    
            newLeaf.EdgeDists.AddRange(prntNode.EdgeDists);
            newLeaf.EdgePoints.AddRange(prntNode.EdgePoints);

            bool startFits = CheckFit(newLeaf);
            if (!startFits) //result 1 - failed, retrying
            {
                LogLeaf(newLeaf, prntNode, 1, noRslt);
                startFits = noRslt ? TryToFit(ref newLeaf, prntNode, true) : TryToFit(ref newLeaf, prntNode);
            }

            if (startFits && !Configs.RadTooSmall(newLeaf.Rad))  //result 2, worked - either immediately, or after retry
            {
                Nodes.Add(newLeaf);
                int lastIdx = Nodes.Count - 1;
                prntNode.MarkParent(newLeaf, lastIdx);

                LogLeaf(newLeaf, prntNode, 2, noRslt);
                return true;
            }
            else //result 3, failed after retry
            {
                LogLeaf(newLeaf, prntNode, 3, noRslt);
                return false;
            }
        }


        public void LogLeaf(SpiralNode newLeaf, SpiralNode prntNode, int result, bool resprouted = false)
        {
            if (!Configs.LOG) { return; }
            string lfLog = "";
            string mod = resprouted ? "resprouted " : "";
            if (result == 1)
            {
                lfLog += $"\ngrowLeaf had a problem fitting {mod}leaf idx {Nodes.Count} (rad={newLeaf.Rad:F3}" +
                        $", slot={newLeaf.Slot}) at angle: {Trig.ComplementAngle(newLeaf.StrtAngl):F3} " +
                        $"on parent idx {newLeaf.PrntIdx}, (clock: {prntNode.Clock}, strtAngl: {prntNode.StrtAngl:F3})\n";
                if (newLeaf.NhbrIdxs.Count > 0)
                {
                    lfLog += "found neighbor conflicts:\n";
                    lfLog += newLeaf.PrintNodeNhbrData();
                }
                if (newLeaf.EdgeDists.Contains(0))
                {
                    lfLog += "found edge conflicts: ";
                    lfLog += newLeaf.PrintNodeEdgeData(true);
                }
            }
            if (result == 2)
            {
                float prntToLeafAngl = Trig.AngleToPoint(newLeaf.Ctr, prntNode.Ctr);
                lfLog += $"\ngrowLeaf added {mod}leaf idx {Nodes.Count - 1} (rad={newLeaf.Rad:F3}, " +
                        $"slot={newLeaf.Slot}) to parent idx {newLeaf.PrntIdx} (clock: {prntNode.Clock}, " +
                        $"strtAngl: {prntNode.StrtAngl:F3}, rad={prntNode.Rad:F3}) " +
                        $"at angle: {Trig.ComplementAngle(newLeaf.StrtAngl):F3} " +
                        $"angleToPoint(lf,prnt): {prntToLeafAngl:F3}\n";
            }
            if (result == 3)
            {
                lfLog += $"\ngrowLeaf gave up on adding {mod}leaf idx {Nodes.Count}, " +
                        $"slot={newLeaf.Slot}, to parent idx {newLeaf.PrntIdx}\n";
            }
            AddToLog(lfLog);
        }


        public bool TryPromotingTinyLeaf(SpiralNode current, ref int leafSlot, ref float leafRad, ref float leafAngl)
        {
            (int slt, float rad, float angl) oldConditions = (leafSlot, leafRad, leafAngl);

            while (Configs.RadTooSmall(leafRad) && leafSlot > 0)
            {
                leafSlot--;
                leafRad = Configs.NextLeafRad(current.Rad, leafSlot, _rnd);
            }

            if (!Configs.RadTooSmall(leafRad))
            {
                leafAngl = current.ReslotAngl(leafSlot);
                (int slt, float rad, float angl) newConditions = (leafSlot, leafRad, leafAngl);
                if (Configs.LOG) { LogReslot(true, 3, oldConditions, newConditions); }
                return true;
            }
            //else 
            return false;
        }



        public void SproutStumps()
        {
            int nodesLeft = Configs.maxNodes - Nodes.Count;
            if (nodesLeft == 0) { return; } //nothing left to grow

            List<(int idx, float rad)> stumpList = new();
            int targetSlot = 0;
            int minSlot = Configs.useSlots.Min();
            int maxSlot = Configs.useSlots.Max();
            targetSlot = minSlot;
            int growSlot = targetSlot;

            IEnumerable<(int i, float rad, int slot, bool tooSmall, bool hasLeaves, bool blocked)> nodeAttributes =
                Nodes.Select((x, i) => (i, x.Rad, x.Slot, x.TooSmall, x.HasLeaves, x.Blocked));
            List<(int idx, float rad, int slt, bool sm, bool hl, bool blkd)> attrList = nodeAttributes.ToList();

            IEnumerable<(int idx, float rad, int slt, bool sm, bool hl, bool blkd)> goodStumps =
                attrList.Where(x => x.sm && !x.hl && !x.blkd);

            IEnumerable<(int idx, float rad, int slt)> goodStumpLst = goodStumps.Select(x => (x.idx, x.rad, x.slt));

            for (int loop = minSlot; loop <= maxSlot; loop++)
            {
                IEnumerable<(int idx, float rad, int slt)> slotFltr = goodStumpLst.Where(x => x.slt == targetSlot);
                IEnumerable<(int idx, float rad)> frmtFltr = slotFltr.Select(x => (x.idx, x.rad));
                stumpList = frmtFltr.ToList();
                if (stumpList.Count > 0) { break; }
                targetSlot++;
            }

            //sort in descending order
            stumpList.Sort((a, b) => a.rad > b.rad ? -1 : a.rad < b.rad ? 1 : 0);
            foreach ((int idx, float rad) in stumpList)
            {
                float mult = Configs.childProportion;
                if (rad < Configs.minRadius / 2) { mult += 0.05f; }
                float lfRad = mult * (rad * Configs.initRadius) / Configs.minRadius;
                SpiralNode stump = Nodes[idx];

                float strtAngl = stump.ToAbsoluteAngle(Configs.sproutAngle + (0.1f * growSlot));
                bool success = GrowLeaf(stump, idx, lfRad, strtAngl, growSlot, true);
                if (success)
                {
                    nodesLeft--;
                    if (nodesLeft == 0) { return; }

                    int leafIdx = Nodes.Count - 1;
                    if (Nodes[leafIdx].CanGrow) { Develop(leafIdx, true); }
                    else { continue; }

                    nodesLeft = Configs.maxNodes - Nodes.Count;
                    if (nodesLeft == 0) { return; }
                }
                else { stump.Blocked = true; }
            }
        }


        public void Develop(int idx, bool resprouted = false)
        {
            int maxNumLeaves = Configs.maxLeaves;
            int nodesLeft = Configs.maxNodes - Nodes.Count;
            SpiralNode current = Nodes[idx];

            if (Configs.RANDNUM) { maxNumLeaves = Configs.NumLeaves(_rnd); }
            float baseAngl = FirstOpenAngl(idx);
            int leafSlot = current.NextLeafSlot(baseAngl, maxNumLeaves);
            float leafRad = Configs.NextLeafRad(current.Rad, leafSlot, _rnd);
            float leafAngl = current.NextLeafAngle(leafRad, baseAngl, leafSlot);

            for (int lf = 0; lf < maxNumLeaves; lf++)
            {   //bad start angle, can't grow a new leaf here
                if (leafAngl == -100) { current.Blocked = true && !resprouted; break; }

                bool success;
                if (Configs.RadTooSmall(leafRad))
                {
                    if (Configs.GRAD && Configs.SMTOLG) //leaves get larger from here
                    {
                        success = TryPromotingTinyLeaf(current, ref leafSlot, ref leafRad, ref leafAngl);
                        if (!success) { current.Full = true; break; }
                    }
                    //leaves get smaller from here, and this one is already too small
                    else { current.Full = true; break; }
                }

                //try to grow new leaf
                success = GrowLeaf(current, idx, leafRad, leafAngl, leafSlot);
                if (!success) { current.Blocked = true && !resprouted; break; }

                nodesLeft--;
                if (nodesLeft == 0) { return; }

                baseAngl = FirstOpenAngl(idx);
                // leafSlot = current.nextLeafSlot(baseAngl, maxNumLeaves);  //use overload to test slot allocation
                leafSlot = Nodes[^1].Slot; //get actual value in case adjusted
                if (leafSlot == -1) { break; }
                leafSlot = current.NextLeafSlot(leafSlot, maxNumLeaves); //simple decrementing overload

                leafRad = Configs.NextLeafRad(current.Rad, leafSlot, _rnd);
                leafAngl = current.NextLeafAngle(leafRad, baseAngl, leafSlot);
                if (current.HasLeaves && current.LeafIdxs.Count == maxNumLeaves) { current.Full = true; return; }

            }
            if (current.HasLeaves) { current.Full = true; }
        }


        public void Grow()
        {
            CreateLog();
            int loopCount = 0;
            int sterileCount = 0;
            int nodesLeft = Configs.maxNodes - Nodes.Count;
            int prevNodeCount = 0;

            if (Configs.LOG)
            { foreach (SpiralNode rootNode in Nodes) { AddToLog(rootNode.PrintNode(new char[] { 'B', 'E' })); } }

            while (nodesLeft > 0 && loopCount < 100)
            {
                loopCount++;
                if (Configs.LOG)
                { AddToLog($"\nTree loop #{loopCount} full nodes: {sterileCount} tree length: {Nodes.Count}\n"); }

                if (sterileCount >= Nodes.Count - 1 && Configs.GROWTINY)
                {
                    SproutStumps();
                    nodesLeft = Configs.maxNodes - Nodes.Count;
                    if (nodesLeft == 0) { break; }
                }
                sterileCount = 0;

                if (prevNodeCount == Nodes.Count)
                {
                    if (Configs.GROWTINY)
                    {
                        if (!Nodes.Any(x => x.TooSmall && !x.HasLeaves && !x.Blocked)) { break; }
                    }
                    else { break; }
                }
                else { prevNodeCount = Nodes.Count; }

                for (int idx = 0; idx < Nodes.Count; idx++)
                {
                    //reset to number of remaining nodes after subtracting current tree length
                    nodesLeft = Configs.maxNodes - Nodes.Count;
                    SpiralNode current = Nodes[idx];

                    if (current.CanGrow)
                    {
                        Develop(idx);
                        nodesLeft = Configs.maxNodes - Nodes.Count;
                        if (nodesLeft == 0) { WriteLog(); return; }
                    }
                    else { sterileCount++; }
                }
                nodesLeft = Configs.maxNodes - Nodes.Count;
            }

            WriteLog();
            return;
        }
    }
}