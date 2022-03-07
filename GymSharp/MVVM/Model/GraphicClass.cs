using System.IO;
using System.Collections.Generic;


namespace GymSharp.MVVM.Model
{
    public static class GraphicClass
    {
        public static string[] GetConfig(string path)
        {
            StreamReader stream = new StreamReader(path);
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

        public static List<int> GetListDays(string path)
        {
            string[] content = GetData(path);

            List<int> days = new List<int>();

            foreach (string line in content)
            {
                string[] data = line.Split('/');
                if ((days.Count > 0 && days[-1] != int.Parse(data[0])) || days.Count == 0)
                    days.Add(int.Parse(data[0]));
            }

            return days;
        }

        public static List<int> GetListDays(string[] content)
        {
            List<int> days = new List<int>();

            foreach (string line in content)
            {
                string[] data = line.Split('/');
                if ((days.Count > 0 && days[-1] != int.Parse(data[0])) || days.Count == 0)
                    days.Add(int.Parse(data[0]));
            }

            return days;
        }

        public static List<int> GetListMonths(string path)
        {
            string[] content = GetData(path);

            List<int> months = new List<int>();

            foreach (string line in content)
            {
                string[] data = line.Split('/');
                if ((months.Count > 0 && months[-1] != int.Parse(data[0])) || months.Count == 0)
                    months.Add(int.Parse(data[0]));
            }

            return months;
        }

        public static List<int> GetListMonths(string[] content)
        {
            List<int> months = new List<int>();

            foreach (string line in content)
            {
                string[] data = line.Split('/');
                if ((months.Count > 0 && months[-1] != int.Parse(data[0])) || months.Count == 0)
                    months.Add(int.Parse(data[0]));
            }

            return months;
        }

        public static List<int> GetListYears(string path)
        {
            string[] content = GetData(path);

            List<int> years = new List<int>();

            foreach (string line in content)
            {
                string[] data = line.Split('/');
                if ((years.Count > 0 && years[-1] != int.Parse(data[0])) || years.Count == 0)
                    years.Add(int.Parse(data[0]));
            }

            return years;
        }

        public static List<int> GetListYears(string[] content)
        {
            List<int> years = new List<int>();

            foreach (string line in content)
            {
                string[] data = line.Split('/');
                if ((years.Count > 0 && years[-1] != int.Parse(data[0])) || years.Count == 0)
                    years.Add(int.Parse(data[0]));
            }

            return years;
        }

    }
}
