using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    class Point3DMain
    {
        static void Main(string[] args)
        {
            var point = new Point3D(5, 10, 35);
            Console.WriteLine(point);
            Console.WriteLine(Point3D.StartPoint);
        }
    }
}