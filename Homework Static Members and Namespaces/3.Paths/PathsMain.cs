namespace Paths
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    using Point3D;

    class PathsMain
    {
        static void Main(string[] args)
        {
            var pointCollection = new List<Point3D>();
            pointCollection.Add(new Point3D(1, 2, 3));
            pointCollection.Add(new Point3D(-1, 3, 100));
            pointCollection.Add(new Point3D(-10, 0, 550));

            var path = new Path3D(pointCollection);

            Path3D loadedPath;

            try
            {
                loadedPath = Storage.LoadPath("path.txt");
            }
            catch (RegexMatchTimeoutException rmte)
            {
                Console.WriteLine(rmte.Message);
                return;
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
                return;
            }
            catch(FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
                return;
            }
            Console.WriteLine("Loaded path: {0}", loadedPath);

            try
            {
                Storage.SavePath("savedPath.txt", path);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Path {0} saved successfully!", path);
        }
    }
}