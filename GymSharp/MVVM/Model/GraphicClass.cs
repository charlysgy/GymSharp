using System.IO;
using System.Collections.Generic;
using GymSharp.Utils;


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
    }
}