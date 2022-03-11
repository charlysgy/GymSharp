using System.IO;
using System.Collections.Generic;


namespace GymSharp.MVVM.Model
{
    public static class GraphicClass
    {
        public static string[] GetConfig()
        {
            string currentDir = Directory.GetCurrentDirectory();
            StreamReader stream = new StreamReader($"{currentDir}/../../Data/config.txt");
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

        public static List<int> GetListDays(string[] content)
        {
            List<int> days = new List<int>();

            foreach (string line in content)
            {
                string[] data = line.Split('/');
                if ((days.Count > 0 && days[days.Count-1] != int.Parse(data[0])) || days.Count == 0)
                    days.Add(int.Parse(data[0]));
            }

            return days;
        }

        public static List<int> GetListMonths(string[] content)
        {
            List<int> months = new List<int>();

            foreach (string line in content)
            {
                string[] data = line.Split('/');
                if (months.Count == 0 || (months.Count > 0 && months[months.Count-1] != int.Parse(data[1])))
                    months.Add(int.Parse(data[1]));
            }

            return months;
        }

        public static List<int> GetListYears(string[] content)
        {
            List<int> years = new List<int>();

            foreach (string line in content)
            {
                string[] data = line.Replace("\r", "").Split('/');
                if (years.Count == 0 || (years.Count > 0 && years[years.Count-1] != int.Parse(data[2])))
                    years.Add(int.Parse(data[2]));
            }

            return years;
        }

    }
}
