namespace Point3D
{
    using System;

    public class Point3D
    {
        private int x;
        private int y;
        private int z;
        private static readonly Point3D startPoint = new Point3D();

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Point3D()
            : this(0,0,0)
        {

        }

        public int X 
        {
            get
            {
                return this.x;
            }
            set
            {
                int num;
                if(!int.TryParse(value.ToString(), out num))
                {
                    throw new FormatException(string.Format("X value must be valid integer number."));
                }
                this.x = value;
            }
        }

        public int Y 
        {
            get
            {
                return this.y;
            }
            set
            {
                int num;
                if (!int.TryParse(value.ToString(), out num))
                {
                    throw new FormatException(string.Format("X value must be valid integer number."));
                }
                this.y = value;
            }
        }

        public int Z 
        {
            get
            {
                return this.z;
            }
            set
            {
                int num;
                if (!int.TryParse(value.ToString(), out num))
                {
                    throw new FormatException(string.Format("X value must be valid integer number."));
                }
                this.z = value;
            }
        }

        public static Point3D StartPoint 
        {
            get
            {
                return Point3D.startPoint;
            }
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}, {2}]", this.X, this.Y, this.Z);
        }
    }
}