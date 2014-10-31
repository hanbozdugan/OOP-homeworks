namespace Paths
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    using Point3D;
    public static class Storage
    {
        private static readonly string PathPattern = @"\{{1}([\r\n\t]*.+[\r\n\t]*)+\}{1}";
        private static readonly string PathElPattern = @"(\[[\r\n\t ]*(\-*\d+)[\r\n\t ]*,{1}[\r\n\t ]*(\-*\d+)[\r\n\t ]*,{1}[\r\n\t ]*(\-*\d+)[\r\n\t ]*\])+";
        public static Path3D LoadPath(string fileName)
        {
            Path3D path = new Path3D();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string inputText = sr.ReadToEnd();

                bool isValid = Validate(inputText.Trim());
                
                if(isValid)
                {
                    MatchCollection res = Regex.Matches(inputText, PathElPattern);
                    foreach (Match match in res)
                    {
                        int x = int.Parse(match.Groups[2].Value);
                        int y = int.Parse(match.Groups[3].Value);
                        int z = int.Parse(match.Groups[4].Value);

                        var point = new Point3D(x, y, z);
                        path.AddPoint(point);
                    }
                }
            }
            if(path.Path.Count == 0)
            {
                throw new FormatException(string.Format("Invalid path in file: {0}", fileName));
            }
            return path;
        }

        public static void SavePath(string fileName, Path3D path)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(path);
            }
        }

        private static bool Validate(string inputText)
        {
            Match pathMatch;
            try
            {
                 pathMatch = Regex.Match(inputText, PathPattern, RegexOptions.None, new TimeSpan(0, 0, 1));
            }
            catch (RegexMatchTimeoutException rmte)
            {

                throw new RegexMatchTimeoutException("Path brackets mismatch");
            }

            if (pathMatch.Success)
            {
                MatchCollection points = Regex.Matches(inputText, PathElPattern);
                MatchCollection commas = Regex.Matches(inputText, ",");
                if(((points.Count * 2) + points.Count - 1) == commas.Count)
                {
                    return true;
                }
            }
            return false;
        }
    }
}