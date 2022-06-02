using System.Collections.Generic;
using System.Windows;
using GymSharp.ressources.enums;
using GymSharp.Utils;
using System.IO;

namespace GymSharp.MVVM.Model
{
    public static class _3Dclass
    {
        private static List<List<int>> _face = new List<List<int>>();
        private static List<List<int>> _back = new List<List<int>>();
        private static List<List<int>> _left = new List<List<int>>();
        private static List<List<int>> _right = new List<List<int>>();
        public static Muscles CoordsToMuscle(Point O, double winx, double winy, string side)
        {
            return Muscles.Abdominaux;
        }

        private static double GetAngle(Point A, Point B, Point C)
        {
            double angle = 0;

            return angle;
        }

        public static void RegisterCoords()
        {
            string pathToDir = "text";
            FindPath.FindDirectory(ref pathToDir);

            List<string> faces = new List<string> { "front", "back", "left", "right" };

            StreamWriter sw = new StreamWriter(pathToDir);
            foreach (string face in faces)
            {
            }
        }
    }
}
