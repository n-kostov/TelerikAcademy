using System;

namespace _1_4_Points
{
    public static class Distance
    {
        public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            return Math.Sqrt(Math.Abs((firstPoint.X - secondPoint.X)*(firstPoint.X - secondPoint.X) + (firstPoint.Y - secondPoint.Y)*(firstPoint.Y - secondPoint.Y) + (firstPoint.Z - secondPoint.Z)*(firstPoint.Z - secondPoint.Z)));
        }
    }
}
