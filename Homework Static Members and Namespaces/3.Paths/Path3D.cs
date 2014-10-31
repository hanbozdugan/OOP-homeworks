namespace Paths
{
    using System.Collections.Generic;
    using System.Text;

    using Point3D;

    public class Path3D
    {
        private IList<Point3D> path;

        public Path3D()
        {
            this.path = new List<Point3D>();
        }

        public Path3D(IList<Point3D> path)
        {
            this.path = path;
        }

        public IList<Point3D> Path 
        {
            get
            {
                return this.path;
            }
            set
            {
                this.path = value;
            }
        }

        public Point3D this[int index]
        {
            get
            {
                return this.path[index];
            }
        }

        public void AddPoint(Point3D point)
        {
            this.path.Add(point);
        }

        public override string ToString()
        {
            StringBuilder pathAsString = new StringBuilder();
            pathAsString.Append("{ ");
            int elCount = this.Path.Count;
            int count = 0;

            foreach(var point in this.Path)
            {
                count += 1;
                if(count == elCount)
                {
                    pathAsString.Append(point);
                }
                else
                {
                    pathAsString.Append(point + ", ");
                }
            }
            pathAsString.Append(" }");

            return pathAsString.ToString();
        }
    }
}