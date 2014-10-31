namespace DistanceCalculator
{
    using System;

    using Point3D;
    class DistanceCalculatorMain
    {
        static void Main(string[] args)
        {
            var p1 = new Point3D(-7, -4, 3);
            var p2 = new Point3D(17, 6, 2);

            double distance = DistanceCalculator.CalculateDistance(p1, p2);

            Console.WriteLine(distance);
        }
    }
}