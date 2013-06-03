using System;
using System.Collections.Generic;

namespace _1_4_Points
{
    public class Path
    {
        private readonly List<Point3D> pathList;

        public Path()
        {
            pathList = new List<Point3D>();
        }

        public int Count
        {
            get { return pathList.Count; }
        }

        public void Add(Point3D point)
        {
            pathList.Add(point);
        }

        public Point3D this[int index]
        {
            get
            {
                if (index < 0 || index >= pathList.Count)
                {
                    throw new ArgumentOutOfRangeException("The index is out of bounds");
                }

                return pathList[index];
            }
        }
    }
}
