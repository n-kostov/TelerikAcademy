using System;

namespace _1_4_Points
{
    public struct Point3D
    {

        private double x;
        private double y;
        private double z;
        private static readonly Point3D defaultPoint = new Point3D(0, 0, 0);

        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double Z
        {
            get
            {
                return this.z;
            }
            set
            {
                this.z = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public double X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        public static Point3D DefaultPoint
        {
            get
            {
                return defaultPoint;
            }
        }

        public override string ToString()
        {
            return string.Format("({0:F2}, {1:F2}, {2:F2})", x, y, z);
        }
    }
}
