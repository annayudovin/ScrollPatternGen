namespace BFSSpiralTree
{
    public static class Trig
    {

        public static float EdgeFitArc(FlPoint edgePt, FlPoint parentCtr, float parentRad, float leafRad, float leafLift)
        {
            //hypotenuse = parentRad + leafRad + leafLift
            //adjacent = distToEdge - leafRad - nodeBuffer = dist(edgePt.X,edgePt.Y,leafCtr.X,leafCtr.Y) - leafRad - nodeBuffer;
            //angle = Math.Acos(adjacent/hypotenuse)
            float hypotenuse = parentRad + leafRad + leafLift;
            float adjSide = PointDist(edgePt, parentCtr) - leafRad - Configs.nodeBuffer;
            if (hypotenuse < adjSide) { return -100; }
            if (adjSide / hypotenuse < 0.1) { return -100; } //produces a greater-than-90-degree angle, a problem in context
            //else 
            return (float)Math.Acos(adjSide / hypotenuse);
        }

        public static bool PredictEdgeCollision(SpiralNode node, int edgeIdx)
        {
            float lfRad = 0.75f * (node.Rad * Configs.initRadius) / Configs.minRadius;
            float anglToCtr = node.ToAbsoluteAngle(5f / 4f * (float)Math.PI);
            float lift = node.CalcNodeLift(lfRad, anglToCtr);

            FlPoint edgePt = node.EdgePoints[edgeIdx];
            float edgeDist = node.EdgeDists[edgeIdx];
            float edgePtAngl = AngleToPoint(node.Ctr, edgePt);
            float hypBig = edgeDist / (float)Math.Cos(Math.Abs(anglToCtr - edgePtAngl));
            float hypSmall = hypBig - node.Rad - lfRad - lift;
            float adjSmall = hypSmall * (float)Math.Cos(Math.Abs(anglToCtr - edgePtAngl));

            return lfRad + Configs.nodeHalo >= adjSmall;
        }

        public static float AltClosestFitAngle(float parentNeighborDist, float leafRadAndLift, float parentRad, float neighborRad)
        {
            //triangle1: hypotenuse = parentNeighborDist; opposite = neighborRad
            //triangle2: hypotenuse = parentLeafDist = leafRadAndLift+parentRad; opposite = leafRadAndLift
            //angle = Math.Asin(opposite/hypotenuse)
            //best fit angle = add two angles + nodeHalo
            float ang1 = (float)Math.Asin(neighborRad / parentNeighborDist);
            float ang2 = (float)Math.Asin(leafRadAndLift / (parentRad + leafRadAndLift));
            float targetAng = Configs.nodeHalo + ang1 + ang2;
            return targetAng;
        }


        public static float ClosestFitAngle(SpiralNode parent, SpiralNode leaf, SpiralNode neighbor)
        {
            float prntNhbrDist = PointDist(neighbor.Ctr, parent.Ctr);
            float nhbrPrntSkinDist = SpiralNode.GetSurfaceDist(neighbor, parent);

            float adjacent;
            float hypotenuse = neighbor.Rad + leaf.Rad + Configs.nodeBuffer;    //desired distance from neighbor

            float nhbrToPrntAngl = AngleToPoint(neighbor.Ctr, parent.Ctr);
            if (nhbrPrntSkinDist > leaf.Rad)
            {
                float nhbrSurfcTwrdPrnt = neighbor.RadAtAngle(nhbrToPrntAngl);
                float halfNhbrPrntDist = (nhbrPrntSkinDist - leaf.Lift) / 2;
                adjacent = nhbrSurfcTwrdPrnt + halfNhbrPrntDist;
            }
            else { adjacent = prntNhbrDist / 2; }

            if (hypotenuse < adjacent) { return -100; }
            float adjustArc = (float)Math.Acos(adjacent / hypotenuse);

            float tryAngl1 = nhbrToPrntAngl + adjustArc;
            float ContactPt1X = neighbor.Ctr.X + ((float)Math.Cos(tryAngl1) * hypotenuse);
            float ContactPt1Y = neighbor.Ctr.Y + ((float)Math.Sin(tryAngl1) * hypotenuse);
            float prntToPtAngl = AngleToPoint(parent.Ctr.X, parent.Ctr.Y, ContactPt1X, ContactPt1Y);

            float relPrntToPt = parent.ToRelativeAngle(prntToPtAngl);
            float relPrntToNhbr = parent.ToRelativeAngle(ComplementAngle(nhbrToPrntAngl));

            float fitArc = Math.Abs(relPrntToNhbr - relPrntToPt);
            return fitArc + Configs.nodeHalo;
        }


        public static float AngleToPoint(FlPoint start, FlPoint end) { return AngleToPoint(start.X, start.Y, end.X, end.Y); }


        public static float AngleToPoint(float startCtrX, float startCtrY, float endCtrX, float endCtrY)
        {
            float oppSide = endCtrY - startCtrY;
            float adjSide = endCtrX - startCtrX;
            return Mod2PI((float)Math.Atan2(oppSide, adjSide));
        }


        public static float Mod2PI(float angl)
        {
            if (angl < 0f)
            {
                int mult = Math.Max((int)Math.Ceiling(Math.Abs(angl) / (float)Math.Tau), 1);
                return (mult * (float)Math.Tau) + angl;
            }

            if (angl > (float)Math.Tau)
            {
                int mult = Math.Max((int)Math.Floor(angl / (float)Math.Tau), 1);
                return angl - (mult * (float)Math.Tau);
            }

            return angl;
        }


        public static float SpanThruOrigin(float x, float y)
        {
            float start = Math.Min(x, y);
            float end = Math.Max(x, y);
            return (float)Math.Tau - end + start;
        }


        public static float CalcLeafArcSpan(float parentRad, float leafRad)
        {
            return (float)Math.Asin(leafRad / (parentRad + leafRad));   //[half of] node projection arc [onto another node] 
        }


        //not used
        public static float ReflectOverX(float angl)
        {
            //resulting angle is MIRROR IMAGE OVER X-AXIS
            return Mod2PI(-1 * angl);
        }

        //not used
        public static float ReflectOverY(float angl)
        {
            //resulting angle is MIRROR IMAGE OVER Y-AXIS
            return Mod2PI((float)Math.PI - Mod2PI(angl));
        }


        public static float ComplementAngle(float angl)
        {
            //resulting angle is collinear - continues in opposite direction
            return Mod2PI(angl - (float)Math.PI);
        }


        public static float PointDist(FlPoint a, FlPoint b) { return PointDist(a.X, a.Y, b.X, b.Y); }


        public static float PointDist(float x1, float y1, float x2, float y2)
        {
            float sideA = Math.Abs(x1 - x2);
            float sideB = Math.Abs(y1 - y2);
            return sideA == 0 || sideB == 0 ? Math.Max(sideA, sideB) : Hypotenuse(sideA, sideB);
        }


        public static float Hypotenuse(float sideA, float sideB)
        {
            return (float)Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));
        }


        public static bool CtrLineIntersects(float ctrX, float ctrY, float rad, float lineP1x,
                                              float lineP1y, float lineP2x, float lineP2y)
        {
            if (lineP1x == lineP2x)
            {
                float B = 2 * ctrY;
                float C = (float)Math.Pow(ctrX, 2) + (float)Math.Pow(ctrY, 2) - (float)Math.Pow(rad, 2)
                        + (float)Math.Pow(lineP1x, 2) - (2f * ctrX * lineP1x);
                float D = (B * B) - (4 * C);
                if (D >= 0) { return true; }
            }
            else
            {
                float Slope = (lineP2y - lineP1y) / (lineP2x - lineP1x);
                float YIntercept = lineP2y - (Slope * lineP2x);
                float A = (float)Math.Pow(Slope, 2) + 1f;
                float B = 2 * ((Slope * YIntercept) - (Slope * ctrY) - ctrX);
                float C = (float)Math.Pow(ctrX, 2) + (float)Math.Pow(ctrY, 2) - (float)Math.Pow(rad, 2)
                        + (float)Math.Pow(YIntercept, 2) - (2f * YIntercept * ctrY);
                float D = (B * B) - (4 * A * C);
                if (D >= 0) { return true; }
            }
            return false;
        }
    }
}