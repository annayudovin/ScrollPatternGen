namespace BFSSpiralTree
{
    internal static class Configs
    {

        public static readonly float rootLift = 12f;
        public static readonly float childProportion = 0.75f;
        public static readonly float unscaledMinRadius = 20f;
        public static readonly float unscaledInitRadius = 50f;
        public static readonly int unscaledNodeBuffer = 5;  //pixel distance separating tree nodes
        public static readonly int unscaledRootBuffer = 12;      //distance between twin root node radii
        public static readonly float unchangedSproutAngle = 5f / 4f * (float)Math.PI;
        public static readonly float unchangedSproutMaxAngle = 11f / 12f * (float)Math.PI;

        public static int maxNodes = 200;
        public static float twinRatio = 1f;
        public static float scale = 1f;
        public static float minRadius = 20f;
        public static float initRadius = 50f;
        public static float nodeBuffer = 5;  //pixel distance separating tree nodes
        public static float rootBuffer = 12;      //distance between twin root node radii
        public static float nodeHalo = 0.05f; //angle distance separating tree nodes, similar function to nodeBuffer    
        public static int maxLeaves = 7;
        public static float startAt = 0.785f; //more precise values initialized later
        public static float endAt = 0.785f; //more precise values initialized later
        public static float rootAngle = 0f;
        //used by DIVOPTION=2 to create a smooth/gradual growth pattern
        public static readonly int upperLim = 100;
        public static readonly int lowerLim = 20;

        private static int availSlotSpaces = 6;     //number of option fractions adjusted to fit, either 5 or 6
        public static float sproutAngle = 5f / 4f * (float)Math.PI;
        public static float sproutMaxAngle = 11f / 12f * (float)Math.PI;

        public static float sproutAdjustment = 0;
        public static float spreadFactor = 0;
        public static float shiftFactor = 0;

        public static bool LGMAX = false;     //LargerMax interface option, controls availSlotSpaces
        public static int DIVOPTION = 1;    //fraction collection
        public static bool TWIN = true;     //root curl
        public static bool RANDANG = false; //root curl angle
        public static bool RANDLRG = false; //random large curl
        public static bool MORERND = false; //extra guess for large curl
        public static bool RANDSZ = false;  //randomize all node sizes
        public static bool RANDNUM = false; //number of leaves per node
        public static bool GRAD = true;     //graduated sizes
        public static bool SMTOLG = true;      //small-to-large
        public static bool GROWTINY = false;    //grow large leaves on too-small nodes

        //mainly for graduated radius functionality
        //also helps spacing "sparce" leaf configurations
        public static List<int> useSlots = new();
        public static List<float> slotSizes = new();
        public static List<float> slotAngles = new();
        public static List<float> slotRadMults = new();

        public static bool LOG = false;


        public static bool BigEnoughToGrow(float rad)
        {
            return rad >= 2 / 5 * minRadius || (GRAD && SMTOLG);
        }


        public static bool RadTooSmall(float rad)
        {
            return rad <= minRadius / 3;
        }


        public static bool CanDecreaseLeafArc(bool isTwin)
        {
            return (!isTwin || twinRatio == 1) && !RANDSZ && GRAD && SMTOLG && slotRadMults.Min() < 0.3;
        }


        public static List<float> CreateFractions(List<int> nums, List<int> denoms, float numAdd = 0f)
        {
            List<float> floatNums = nums.Select(x => (float)x).ToList();
            return CreateFractions(floatNums, denoms, numAdd);
        }


        public static List<float> CreateFractions(List<float> nums, List<int> denoms, float numAdd = 0f)
        {
            if (nums.Count != denoms.Count || nums.Count < 2) { return new List<float> { }; }

            int fractCnt = availSlotSpaces;
            if (DIVOPTION == 1) { fractCnt = availSlotSpaces + 1; }

            if (numAdd >= nums.Min()) { numAdd = 0; }

            List<float> fracts = new();

            for (int idx = 0; idx < fractCnt; idx++)
            {
                float adjNum = nums[idx] - numAdd;
                float adjFract = adjNum / denoms[idx];
                fracts.Add(adjFract);
            }
            return fracts;
        }


        public static Tuple<List<float>, List<float>, List<float>> EvenSplit()
        {
            float baseFract = ((float)Math.Tau - endAt - ((float)Math.PI / 8f) + spreadFactor) / availSlotSpaces;
            float radMult = (float)Math.Sin(baseFract / 2f) / (1 - (float)Math.Sin(baseFract / 2f));

            //maximum number of these that can fit at !LGMAX is 5
            //and 4 at LGMAX. Reducing the size looks worse 
            //adjusting slot start angles instead
            List<float> radMults = Enumerable.Repeat(radMult, availSlotSpaces - 1).ToList();
            List<float> slotAngls;
            List<float> slotSizes;
            if (LGMAX)
            {//initially used:1.919, 2.840, 3.661, 4.382
                float slotSize = 1.071f;    //experimentally determined
                slotSizes = Enumerable.Repeat(slotSize, 4).ToList();
                slotAngls = new List<float> { 1.262f, 2.333f, 3.404f, 4.475f }; //experimentally determined
            }
            else
            {//initially used 1.748, 2.499, 3.150, 3.701, 4.152
                float slotSize = 0.90075f;  //experimentally determined
                slotSizes = Enumerable.Repeat(slotSize, 5).ToList();
                slotAngls = new List<float> { 1.157f, 2.058f, 2.958f, 3.859f, 4.760f }; //experimentally determined
            }

            if (spreadFactor != 0)
            {
                float sltTotl = slotAngls.Sum();
                float desiredTotl = sltTotl + spreadFactor;
                float adjustment = desiredTotl / sltTotl;

                List<float> adjustedSlotAngls = slotAngls.Select(x => x * adjustment).ToList();
                slotAngls = adjustedSlotAngls;

                List<float> adjustedSlotSizes = slotSizes.Select(x => x * adjustment).ToList();
                slotSizes = adjustedSlotSizes;
            }

            return Tuple.Create(radMults, slotSizes, slotAngls);
        }


        public static int FindNextSlot(float tstAngl)
        {
            int leafSlot = 0;
            for (int idx = slotAngles.Count - 1; idx > 0; idx--)
            {
                float slotAngl = slotAngles[idx];

                if (tstAngl > slotAngl)
                {
                    leafSlot = idx;
                    break;
                }
            }
            return leafSlot;
        }


        public static float GetGoodRandomRad(float parentRad, Random? rnd = null)
        {
            rnd ??= new Random();

            int localMax = Math.Max(maxLeaves, 3);

            float rad = 0;
            float max = slotRadMults.Max();
            float min = slotRadMults.Min();
            for (int tr = 0; tr < localMax; tr++)
            {
                rad = parentRad * Random(min, max, rnd);
                if (Math.Round(rad) > minRadius / 2) { break; }
            }
            return rad;
        }


        public static float GetGoodRandomRad(float parentRad, int slot, Random? rnd = null)
        {
            rnd ??= new Random(); //if rnd is null, create a new Random object

            bool goHigh = false;

            if (useSlots.Count == 2)
            {
                if (slot == useSlots.Min()) { goHigh = true; }
            }
            else if (useSlots.Count % 2 == 1) //odd number of slots in use
            {
                if (slot % 2 == 1) { goHigh = true; }
            }
            else
            {
                if (slot % 2 == 0) { goHigh = true; }
            }

            int end = 0;
            int mid = slotRadMults.Count / 2;
            if (goHigh)
            {
                end = slotRadMults.Count - 1;   //this is the important bit

                int coin = rnd.Next(1, 2);
                mid -= coin % 2;
                if (coin % 2 == 0) { parentRad = Math.Max(parentRad, initRadius); }
            }
            else
            {
                int coin = rnd.Next(1, 2);
                mid += coin % 2;
            }

            int sizeSlot = rnd.Next(Math.Min(end, mid), Math.Max(end, mid));
            float rad = parentRad * slotRadMults[sizeSlot];

            if (Math.Round(rad) < minRadius / 2) { return GetGoodRandomRad(parentRad, rnd); }
            //else:
            return rad;
        }


        public static List<int> GetSlotList(int maxNumLeaves)
        {
            int numSlots = slotSizes.Count;
            List<int> slotLst;

            if (maxNumLeaves == 2)
            {
                if (slotSizes.Count == 4) { return new List<int> { 1, 2 }; }
                if (GRAD && DIVOPTION == 1)
                {
                    if (SMTOLG) { return new List<int> { 1, 3 }; }
                    else if (LGMAX) { return new List<int> { 2, 4 }; }
                    else { return new List<int> { 3, 5 }; }
                }
                if (LGMAX && GRAD && !SMTOLG) { return new List<int> { 2, 3 }; }
                else { return new List<int> { 2, 4 }; }
            }

            int strt = (numSlots - maxNumLeaves) / 2;
            if (numSlots % 2 == 1) //odd number of slots: 5 and 7
            {
                if (maxNumLeaves % 2 == 1) //select odd: take same number from each end
                {
                    slotLst = Enumerable.Range(strt, maxNumLeaves).ToList();
                }
                else    //select even: leave out smallest-size leaf
                {
                    slotLst = Enumerable.Range(strt, maxNumLeaves).ToList();
                    if (!SMTOLG) { slotLst = slotLst.Select(x => x + 1).ToList(); }
                }
                if (SMTOLG && numSlots == 7 && maxNumLeaves < 5) { slotLst = slotLst.Select(x => x - 1).ToList(); }
                if (!SMTOLG && numSlots == 7 && maxNumLeaves < 5) { slotLst = slotLst.Select(x => x + 1).ToList(); }
            }

            else //even number of slots: 6
            {
                if (maxNumLeaves % 2 == 0) //select even (i.e. 4): take 1 from each end
                {
                    slotLst = Enumerable.Range(1, maxNumLeaves).ToList();
                }
                else //select odd: 5 or 3
                {
                    slotLst = Enumerable.Range(strt, maxNumLeaves).ToList();
                    if (!SMTOLG) { slotLst = slotLst.Select(x => x + 1).ToList(); }
                }
            }

            return slotLst;
        }

        /*initializers and initializer utility methods--------------------------------------------------*/


        public static void InitAll(Random? rnd = null)
        {
            rnd ??= new Random();       //if rnd is null, create a new Random object
            twinRatio = RANDLRG || RANDSZ ? Random(0.6f, 1f, rnd) : 1f;

            availSlotSpaces = LGMAX ? 5 : 6;

            sproutAngle = unchangedSproutAngle + sproutAdjustment;
            sproutMaxAngle = unchangedSproutMaxAngle + sproutAdjustment;

            minRadius = unscaledMinRadius * scale;
            initRadius = unscaledInitRadius * scale;
            nodeBuffer = unscaledNodeBuffer * scale;
            rootBuffer = unscaledRootBuffer * scale;

            endAt = (float)Math.PI / 4f;  //initialize global values for start and end arcs
            InitStartAt();

            if (RANDNUM) { maxLeaves = 8; } //establish independence of these options, regardless of interface
            if (maxLeaves < 2) { maxLeaves = 2; }    //otherwise no hope of growing much of a "tree"

            InitSegments();
        }


        public static void InitSegments()
        {
            //fibNums 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377
            //triangleNums 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66, 78, 91, 105, 120, 136,
            //primeQuads {5, 7, 11, 13}, {11, 13, 17, 19}
            List<int> triangleNums = new() { 10, 15, 21, 28, 36, 45, 55, 66 };
            List<int> fibNums = new() { 5, 8, 13, 21, 34, 55, 89, 144 };
            List<int> fibNums2 = new() { 13, 21, 34, 55, 89, 144, 233, 377 };

            List<float> fracts = new();

            if (DIVOPTION == 1)
            { fracts = CreateFractions(Enumerable.Range(5, 8).ToList(), triangleNums); }

            //"even" growth rate using globals upperLim & lowerLim - unevenSplit() takes it from here   
            if (DIVOPTION == 2) { fracts = ModeratedFractions(); }

            if (DIVOPTION == 3)
            { fracts = CreateFractions(Enumerable.Range(1, 8).ToList(), fibNums); }

            if (DIVOPTION == 4)
            {
                fracts = CreateFractions(Enumerable.Repeat(1, 8).ToList(),
                                        Enumerable.Range(4, 8).ToList());
            }

            if (DIVOPTION == 5)
            {
                List<float> inverses = CreateFractions(fibNums, Enumerable.Range(3, 8).ToList());
                while (fibNums2.Count > inverses.Count) { fibNums2.RemoveAt(fibNums2.Count - 1); }
                fracts = CreateFractions(inverses, fibNums2);
            }

            Tuple<List<float>, List<float>, List<float>> results = !GRAD && !RANDSZ ? EvenSplit() : UnevenSplit(fracts);
            slotRadMults = results.Item1;
            slotSizes = results.Item2;
            slotAngles = results.Item3;

            slotRadMults.Sort();
            slotSizes.Sort();
            slotAngles.Sort();

            if (shiftFactor != 0)
            {
                List<float> adjustedSlotAngls = slotAngles.Select(x => x + shiftFactor).ToList();
                slotAngles = adjustedSlotAngls;
            }

            if (GRAD && SMTOLG) { slotRadMults.Reverse(); }

            //initialize list of slots to use when number of leaves varies
            int maxSlots = slotSizes.Count;
            if (maxLeaves < maxSlots)
            {
                useSlots = GetSlotList(maxLeaves);
                if (maxLeaves <= 3) { AdjustSparseSlots(); }
            }
            else { useSlots = Enumerable.Range(0, maxSlots).ToList(); } //initialize it to all available slots
            useSlots.Reverse();
        }


        public static void InitStartAt()
        {
            if (!TWIN) { startAt = 0.1f; }
            else
            {
                if (GRAD)
                {
                    if (SMTOLG && !LGMAX) { startAt = 0.1f; }
                    if (SMTOLG && LGMAX) { startAt = 0; }
                }
                else
                { startAt = (float)Math.Tau / 7f; }
            }
        }

        public static string LogProperties()
        {
            string lg = "\n---------\n";
            lg += $"maxNodes: {maxNodes}; ";
            lg += $"maxLeaves: {maxLeaves}; ";
            lg += $"RANDNUM: {RANDNUM};  \n";
            lg += $"initRadius: {initRadius:F3}; ";
            lg += $"minRadius: {minRadius:F3}; ";
            lg += $"childProportion: {childProportion:F3};   ";

            lg += $"sproutAdjustment: {sproutAdjustment:F3};  ";
            lg += $"spreadFactor: {spreadFactor:F3}; ";
            lg += $"shiftFactor: {shiftFactor:F3};  ";
            lg += $"startAt: {startAt:F3};  ";
            lg += $"endAt: {endAt:F3}; \n";

            lg += $"TWIN: {TWIN}; ";
            lg += $"twinRatio: {twinRatio:F3}; ";
            lg += $"rootAngle: {rootAngle:F3};  ";
            lg += $"RANDANG: {RANDANG};  ";
            lg += $"RANDLRG: {RANDLRG}; ";
            lg += $"RANDSZ: {RANDSZ}; \n";

            lg += $"GRAD: {GRAD}; ";
            lg += $"SMTOLG: {SMTOLG}; ";
            lg += $"LGMAX: {LGMAX};  ";
            lg += $"DIVOPTION #{DIVOPTION}  ";
            lg += $"GROWTINY: {GROWTINY};  \n";

            lg += "---Slot Radius Multipliers:\n";
            lg += string.Join(", ", slotRadMults.Select(x => x.ToString("F3")));

            lg += "\n---Slot Sizes:\n";
            lg += string.Join(", ", slotSizes.Select(x => x.ToString("F3")));

            lg += "\n---Slot Angles:\n";
            lg += string.Join(", ", slotAngles.Select(x => x.ToString("F3")));

            lg += "\n---Slots In Use:\n";
            lg += string.Join(", ", useSlots);
            lg += "\n\n";
            return lg;
        }


        public static List<float> ModeratedFractions()
        {
            int localMax = availSlotSpaces;

            List<float> fracts = new();
            float baseFract = ((float)Math.Tau - (1.5f * endAt)) / localMax;
            float totlGrowth = Math.Abs(upperLim - lowerLim);
            float fractGrowth = 0.01f * totlGrowth / localMax;  //convert percent to fraction

            for (int idx = 0; idx < localMax; idx++)
            {
                fracts.Add(baseFract);
                baseFract += fractGrowth;
            }

            return fracts;
        }


        public static float NextLeafRad(float parentRad, int leafSlot = -1, Random? rnd = null)
        {
            rnd ??= new Random();

            if (leafSlot == -1) //leafSlot matters to options below
            {
                return RANDSZ ? GetGoodRandomRad(parentRad, rnd) : parentRad * childProportion;
            }

            if (RANDLRG)
            {
                int lrgSlot = rnd.Next(0, slotSizes.Count); //guess current slot 
                if (lrgSlot == leafSlot)
                {
                    { return Random(initRadius * 0.5f, initRadius * 0.9f, rnd); }
                }
                //else: if didn't guess, proceed to other options as normally
            }

            if (RANDSZ)
            {
                return GRAD ? GetGoodRandomRad(parentRad, leafSlot, rnd) : GetGoodRandomRad(parentRad, rnd);
            }

            //else:
            return parentRad * slotRadMults[leafSlot];
        }

        //tree/node helper methods--------------------------------------------------------------

        public static int NumLeaves(Random? rnd = null) //only used with RANDNUM
        {
            rnd ??= new Random();       //if rnd is null, create a new Random object

            int maxSlots = availSlotSpaces;
            if (DIVOPTION == 1) { maxSlots = availSlotSpaces + 1; }
            return rnd.Next(2, maxSlots);
        }



        //fudging the slots/slot sizes to improve look of sparce leaf options (2 & 3)
        public static void AdjustSparseSlots()
        {
            bool spreadSlots = maxLeaves == 3;
            if (maxLeaves == 2 && GRAD && !SMTOLG && LGMAX && DIVOPTION < 5) { spreadSlots = true; }
            if (maxLeaves == 2 && !GRAD && LGMAX) { spreadSlots = true; }
            if (spreadSlots)
            {
                int minSlot = useSlots.Min();
                int maxSlot = useSlots.Max();
                float divizor = 3;
                if (GRAD && SMTOLG && !LGMAX && DIVOPTION != 3) { divizor = 2; }
                if (GRAD && !SMTOLG && maxLeaves == 2 && LGMAX) { divizor = 10; }
                if (GRAD && SMTOLG && DIVOPTION == 5 && LGMAX) { divizor = -10; }
                if (!GRAD && maxLeaves == 3 && LGMAX) { divizor = 4; }
                slotAngles[minSlot] -= slotSizes[minSlot] / divizor;
                slotAngles[maxSlot] += slotSizes[maxSlot] / divizor;
            }

            bool shrinkSlots = maxLeaves == 2;
            if (maxLeaves == 2 && GRAD && !SMTOLG && LGMAX) { shrinkSlots = false; }
            if (shrinkSlots)
            {
                int minSlot = useSlots.Min();
                int maxSlot = useSlots.Max();
                slotAngles[minSlot] += slotSizes[minSlot] / 3;
                slotAngles[maxSlot] -= slotSizes[maxSlot] / 3;
            }

            bool shiftBack = GRAD && !SMTOLG && maxLeaves <= 3;
            if (maxLeaves == 2 && !GRAD && LGMAX) { shiftBack = true; }
            if (shiftBack)
            {
                float minSize = slotSizes.Min() / 2;
                if (DIVOPTION > 3) { minSize += (float)Math.PI / 10; }
                if (LGMAX) { minSize += (float)Math.PI / 15; }
                if (!GRAD) { minSize = slotSizes[0] / 4; }
                foreach (int slt in useSlots) { slotAngles[slt] += minSize; }
            }

            bool shiftForward = GRAD && SMTOLG && maxLeaves <= 3;
            if (shiftForward)
            {
                float minSize = slotSizes.Min() / 2;

                if (DIVOPTION == 2 && LGMAX) { minSize -= (float)Math.PI / 12; }
                if (DIVOPTION == 3 && LGMAX) { minSize += (float)Math.PI / 8; }
                if (maxLeaves == 2 && !LGMAX && DIVOPTION != 1) { minSize = slotSizes.Min(); }
                foreach (int slt in useSlots) { slotAngles[slt] -= minSize; }
            }
        }


        public static List<float> ProportionFractions(List<float> fracts)
        {
            // add up all fracts
            // take ratio of total to desired proportion of whole
            // multiply each fract by INVERSE of this ratio
            float frTotl = fracts.Sum();

            // 1.5 * Math.PI/4 = 1.178; Math.PI/4 + Math.PI/6 = 1.309
            //Math.PI/6 is greater than min root base in all cases
            float desiredTotl = (float)Math.Tau - endAt - (float)Math.PI / 6f;

            if (SMTOLG)
            {
                if (DIVOPTION == 2)
                {
                    if (LGMAX) { desiredTotl = (float)Math.Tau - 1.7f * endAt; }
                    else { desiredTotl = (float)Math.Tau - 1.8f * endAt; }
                }
                if (DIVOPTION == 3) { desiredTotl = (float)Math.Tau - 1.6f * endAt; }
                if (DIVOPTION >= 4 && !LGMAX) { desiredTotl -= 0.2f; }

            }
            else
            {
                if (DIVOPTION == 2 && LGMAX) { desiredTotl = (float)Math.Tau - 1.8f * endAt; }
                if (DIVOPTION == 3) { desiredTotl = (float)Math.Tau - 1.7f * endAt; }
            }

            int extra = 1;
            if (LGMAX) { extra = 2; }
            desiredTotl += spreadFactor;
            float adjustment = (desiredTotl - (fracts.Count * extra * nodeHalo)) / frTotl;

            List<float> newFracts = fracts.Select(x => x * adjustment).ToList();
            return newFracts;
        }


        public static float Random(float min = 0f, float max = 0f, Random? rnd = null)
        {
            rnd ??= new Random();       //if rnd is null, create a new Random object
            float _max = (float)Math.Max(max, min);
            float _min = (float)Math.Min(max, min);
            return ((float)rnd.NextDouble() * (_max - _min)) + _min;
        }


        public static float RootBaseArc(int rootIdx, float rootDist)
        {
            float rootBase = startAt;
            if (TWIN)
            {
                float otherRootRad = initRadius;
                if (rootIdx == 0) { otherRootRad = initRadius * twinRatio; }

                if (GRAD && !RANDSZ)
                {
                    float minMult = slotRadMults.Min();
                    float minLeaf = otherRootRad * minMult;
                    if (SMTOLG)
                    {
                        rootBase = (float)Math.Asin(otherRootRad / rootDist);
                        if (twinRatio == 1 || rootIdx == 0) { rootBase -= nodeHalo; }
                        else
                        {
                            float leafArc = (float)Math.Asin(minLeaf / (otherRootRad + minLeaf));
                            rootBase += leafArc;
                        }
                    }
                    else
                    {
                        rootBase = (float)Math.Asin((otherRootRad + minLeaf + (1.5 * nodeBuffer)) / rootDist);
                    }
                }
            }

            return rootBase + shiftFactor;
        }


        public static Tuple<List<float>, List<float>, List<float>> UnevenSplit(List<float> fracts)
        {
            if (fracts.Count < 2) { return Tuple.Create(new List<float> { }, new List<float> { }, new List<float> { }); }
            List<float> adjFracts = ProportionFractions(fracts);

            adjFracts.Sort();
            List<float> spreadFracts = new();
            List<float> radMults = new();
            foreach (float adjFract in adjFracts)
            {
                float radMult = (float)Math.Sin(adjFract / 2f) / (1f - (float)Math.Sin(adjFract / 2f));
                radMults.Add(radMult);
                spreadFracts.Add(adjFract + nodeHalo);
            }

            List<float> fractAngls = new();
            float totl = endAt + 0.0001f - adjFracts.Min();

            spreadFracts.Sort();
            adjFracts.Sort();

            if (SMTOLG)
            {
                //Root base for idx#0 && idx#1 is 0.463, when twinRatio is 1 (i.e. max). Math.PI/6.5 = 0.4833
                //Root base for idx#0 is 0.332 and for idx#1 is 0.575, when twinRatio: 0.6 (i.e. min). Math.PI/9 = 0.3491; Math.PI/5.5 = 0.5712
                totl = twinRatio < 1 ? (float)Math.PI / 5.5f : (float)Math.PI / 6.5f;
                spreadFracts.Reverse();
                adjFracts.Reverse();
            }

            foreach (float adjFract in adjFracts)
            {
                totl += adjFract;
                fractAngls.Add(totl);
            }

            return Tuple.Create(radMults, spreadFracts, fractAngls);
        }
    }
}