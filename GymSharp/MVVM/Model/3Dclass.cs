using System.Collections.Generic;
using System.Windows;
using GymSharp.ressources.enums;
using GymSharp.Utils;
using System.IO;
using System;

namespace GymSharp.MVVM.Model
{
    public class _3Dclass
    {
        private static List<List<int>> _face = new List<List<int>>();
        private static List<List<int>> _back = new List<List<int>>();
        private static List<List<int>> _left = new List<List<int>>();
        private static List<List<int>> _right = new List<List<int>>();

        public Point point;
        private Point? oldPoint = null;
        public _3Dclass() { }
        public static Muscles CoordsToMuscle(Point O, double winx, double winy, string side)
        {
            return Muscles.Abdominaux;
        }

        private static double GetAngle(Point A, Point B, Point C)
        {
            double angle = 0;

            return angle;
        }

        public void RegisterCoords(View._3DView view)
        {
            string pathToDir = "text";
            FindPath.FindDirectory(ref pathToDir);

            List<string> faces = new List<string> { "front", "back", "left", "right" };

            StreamWriter sw = new StreamWriter(pathToDir + "/coordsFile.txt");

            int n = 4;
            int i = 1;
            foreach (string face in faces)
            {
                Console.WriteLine(face);
                sw.WriteLine(face + '#');
                foreach (Muscles muscle in Enum.GetValues(typeof(Muscles)))
                {
                    Console.WriteLine(Enum.GetName(typeof(Muscles), muscle));
                    sw.WriteLine(Enum.GetName(typeof(Muscles), muscle) + ':');

                    if (muscle == Muscles.Bras || muscle == Muscles.Ischios || muscle == Muscles.Mollets || muscle == Muscles.Epaules || muscle == Muscles.Quadirceps)
                        i = 2;
                    while (n > 0 && i > 0) 
                    {
                        if (oldPoint == null && (point.X, point.Y) != (0,0) || oldPoint != null && point != oldPoint)
                        {
                            oldPoint = point;
                            sw.WriteLine(point.X.ToString() + ';' + point.Y.ToString());
                            Console.WriteLine();
                            n--;
                        }
                        if (n == 0)
                        {
                            i--;
                            n = 4;
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
