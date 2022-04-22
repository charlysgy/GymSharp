using System;
using System.IO;
using System.Collections.Generic;
using GymSharp.Utils;
using GymSharp.ressources.enums;


namespace GymSharp.MVVM.Model
{
    public static class GraphicClass
    {
        public static string[] GetConfig()
        {
            string file = "config.txt";
            FindPath.FindFile(ref file);
            StreamReader stream = new StreamReader(file);
            string[] content = stream.ReadToEnd().Split('\n');
            stream.Close();
            return content;
        }

        public static string[] GetData(string path)
        {
            StreamReader stream = new StreamReader(path);
            string[] content = stream.ReadToEnd().Split('\n');
            stream.Close();
            return content;
        }

        
        public static void InitLists(string[] content, List<int> days, List<int> months,
                                    List<int> years, List<List<int>> exercices, List<int?> rm)
        {
            foreach (string line in content)
            {
                string[] data = line.Replace("\r", "").Split('/');
                if (days.Count == 0 || (days.Count > 0 && days[days.Count - 1] != int.Parse(data[0])))
                {
                    days.Add(int.Parse(data[0]));
                    months.Add(int.Parse(data[1]));
                    years.Add(int.Parse(data[2]));
                }

                exercices.Add(new List<int> { int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5]) });

                if (data[6] != "none")
                {
                    rm.Add(int.Parse(data[6]));
                }
            }
        }

        public static List<List<string>> GetExos()
        {
            List<List<string>> res = new List<List<string>>();

            for (int i = 0; i < 8; i++)
            {
                res.Add(new List<string>());
            }

            foreach (var exo in Enum.GetValues(typeof(Exercice)))
            {
                if ((int)exo >= 100)
                {
                    res[((int)exo / 100) - 1].Add(exo.ToString().Replace('_', ' '));
                }
                else
                {
                    res[((int)exo / 10) - 1].Add(exo.ToString().Replace('_', ' '));
                }
            }

            return res;
        }
    }
}