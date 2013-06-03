using System;

namespace _1_4_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D pt = new Point3D(0,1,0);

            Console.WriteLine(Point3D.DefaultPoint);
            Console.WriteLine(Distance.CalculateDistance(Point3D.DefaultPoint, pt));

            Path path = new Path();
            path.Add(pt);
            path.Add(Point3D.DefaultPoint);

            PathStorage.SavePath(path, "path.txt");
        }
    }
}
