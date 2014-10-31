namespace DistanceCalculator
{
    using System;

    using Point3D;

    public static class DistanceCalculator
    {
        public static double CalculateDistance(Point3D p1, Point3D p2)
        {
            double additive1 = Math.Pow(p1.X - p2.X, 2);
            double additive2 = Math.Pow(p1.Y - p2.Y, 2);
            double additive3 = Math.Pow(p1.Z - p2.Z, 2);

            return Math.Sqrt(additive1 + additive2 + additive3);
        }
    }
}