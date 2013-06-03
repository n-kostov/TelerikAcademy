using System;
using System.IO;

namespace _1_4_Points
{
    public static class PathStorage
    {
        public static Path LoadPath(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("{0} cannot be found", fileName);
            }

            Path path = new Path();

            using (StreamReader fileReader = new StreamReader(fileName))
            {
                string line;
                while ((line = fileReader.ReadLine()) != null)
                {
                    string[] coordinates = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int x, y, z;
                    if (coordinates.Length == 3 &&
                        int.TryParse(coordinates[0], out x) &&
                        int.TryParse(coordinates[1], out y) &&
                        int.TryParse(coordinates[2], out z))
                    {
                        Point3D point = new Point3D(x, y, z);
                        path.Add(point);
                    }
                }
            }

            return path;
        }

        public static void SavePath(Path points, string fileName)
        {
            using (StreamWriter fileWriter = new StreamWriter(fileName, false))
            {
                for (int i = 0; i < points.Count;i++)
                {
                    string line = String.Format("{0} {1} {2}", points[i].X, points[i].Y, points[i].Z);
                    fileWriter.WriteLine(line);
                }
            }
        }
    }
}
