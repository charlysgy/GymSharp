using System.Collections.Generic;
using System.Windows;
using GymSharp.ressources.enums;
using GymSharp.Utils;
using System.IO;
using System;
using GymSharp.MVVM.View;
using System.Linq;

namespace GymSharp.MVVM.Model
{
    public class _3Dclass
    {
        public Point point;
        private Point? oldPoint = null;

        public _3Dclass() { }
        public static Muscles CoordsToMuscle(Point O, double winx, double winy, string side)
        {
            return Muscles.Abdominaux;
        }

        public string IsPointInsideAMuscle(Point click, string side, _3DView view)
        {
            int INF = 10000;

            bool onSegment(Point p, Point q, Point r)
            {
                if (q.X <= Math.Max(p.X, r.X) &&
                    q.X >= Math.Min(p.X, r.X) &&
                    q.Y <= Math.Max(p.Y, r.Y) &&
                    q.Y >= Math.Min(p.Y, r.Y))
                {
                    return true;
                }
                return false;
            }

            int orientation(Point p, Point q, Point r)
            {
                int val = (int)(q.Y - p.Y) * (int)(r.X - q.X) -
                        (int)(q.X - p.X) * (int)(r.Y - q.Y);

                if (val == 0)
                {
                    return 0; // collinear
                }
                return (val > 0) ? 1 : 2; // clock or counterclock wise
            }

            bool doIntersect(Point p1, Point q1, Point p2, Point q2)
            {
                // Find the four orientations needed for
                // general and special cases
                int o1 = orientation(p1, q1, p2);
                int o2 = orientation(p1, q1, q2);
                int o3 = orientation(p2, q2, p1);
                int o4 = orientation(p2, q2, q1);

                if (o1 != o2 && o3 != o4)
                {
                    return true;
                }

                if (o1 == 0 && onSegment(p1, p2, q1))
                {
                    return true;
                }

                if (o2 == 0 && onSegment(p1, q2, q1))
                {
                    return true;
                }


                if (o3 == 0 && onSegment(p2, p1, q2))
                {
                    return true;
                }


                if (o4 == 0 && onSegment(p2, q1, q2))
                {
                    return true;
                }

                return false;
            }

            bool isInside(Point[] polygon, int n, Point p)
            {
                p.X = (p.X / view.rect.ActualWidth) * 1000;
                p.Y = (p.Y / view.rect.ActualHeight) * 1000;

                // There must be at least 3 vertices in polygon[]
                if (n < 3)
                {
                    return false;
                }


                Point extreme = new Point(INF, p.Y);

                int count = 0, i = 0;
                do
                {
                    int next = (i + 1) % n;

                    if (doIntersect(polygon[i], polygon[next], p, extreme))
                    {
                        if (orientation(polygon[i], p, polygon[next]) == 0)
                        {
                            return onSegment(polygon[i], p, polygon[next]);
                        }
                        count++;
                    }
                    i = next;
                } while (i != 0);


                return (count % 2 == 1);
            }

            string file = "coordsFile.txt";
            FindPath.FindFile(ref file);

            string[] content;

            using (StreamReader sr = new StreamReader(file))
            {
                content = sr.ReadToEnd().Replace("\r", "").Split('#');
            }

            int index = 0;
            foreach (string line in content)
            {
                index++;
                if (line == side)
                {
                    break;
                }
            }

            string[] sideMuscles = content[index].Split('\n');
            index = 0;

            while (index < sideMuscles.Length - 1)
            {
                index++;
                string line = sideMuscles[index];
                if (Enum.GetNames(typeof(Muscles)).Contains(line))
                {
                    index++;
                    List<Point> surface = new List<Point>();
                    while (index < sideMuscles.Length && !Enum.GetNames(typeof(Muscles)).Contains(sideMuscles[index]) && sideMuscles[index] != "")
                    {
                        string xstring = sideMuscles[index].Split(';')[0];
                        string ystring = sideMuscles[index].Split(';')[1];
                        double x = double.Parse(xstring);
                        double y = double.Parse(ystring);
                        surface.Add(new Point(x, y));
                        index++;
                    }
                    index--;

                    if (isInside(surface.ToArray(), surface.Count, click))
                    {
                        return sideMuscles[index - surface.Count];
                    }
                }
            }

            return "none";
            
        }
        

        public void RegisterCoords(_3DView view)
        {
            string pathToDir = "text";
            FindPath.FindDirectory(ref pathToDir);

            List<string> faces = new List<string> { "front", "back", "left", "right" };

            StreamWriter sw = new StreamWriter(pathToDir + "/coordsFile.txt");

            int n = 4;
            int i = 1;
            foreach (string face in faces)
            {
                sw.WriteLine('#' + face + '#');
                foreach (Muscles muscle in Enum.GetValues(typeof(Muscles)))
                {
                    sw.WriteLine(Enum.GetName(typeof(Muscles), muscle));

                    if (muscle == Muscles.Bras || muscle == Muscles.Ischios || muscle == Muscles.Mollets || muscle == Muscles.Epaules || muscle == Muscles.Quadriceps)
                        i = 2;
                    while (n > 0 && i > 0) 
                    {
                        if (oldPoint == null && (point.X, point.Y) != (0,0) || oldPoint != null && point != oldPoint)
                        {
                            oldPoint = point;
                            sw.WriteLine(((point.X / view.rect.ActualWidth) * 1000).ToString() + ';' + ((point.Y / view.rect.ActualHeight) * 1000).ToString());
                            n--;
                        }
                        if (n == 0)
                        {
                            i--;
                            n = 4;
                            if (i == 1)
                            {
                                sw.WriteLine(Enum.GetName(typeof(Muscles), muscle));
                            }
                        }
                    }
                    n = 4;
                    i = 1;
                }
            }
            sw.Close();
        }
    }
}
