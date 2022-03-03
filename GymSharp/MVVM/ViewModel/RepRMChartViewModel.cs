using System;
using System.Windows;
using System.IO;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;
using System.Collections.Generic;

namespace GymSharp.MVVM.ViewModel
{
    internal class RepRMChartViewModel : Window
    {
        #region Attributes
        public SeriesCollection SeriesCollection { get; }
        public Func<double, string> Yformatter { get; }

        public string AxisXName { get; }
        public string AxisYName { get; }
        public string[] Labels { get; }
        public bool DataLabels = true;
        
        private readonly List<Tuple<int, int>> ListExercises = new List<Tuple<int, int>>();
        private readonly List<int> ListDays = new List<int>();
        private readonly List<int> ListMonths = new List<int>();
        private readonly List<int> ListYears = new List<int>();
        private readonly string Langue;

        #endregion

        // Constructor of the line chart 

        public RepRMChartViewModel()
        {
            // Read the config text file to set attributes values and Chart basic configuration

            StreamReader stream = new StreamReader("../../Data/config.txt");
            foreach (string line in stream.ReadToEnd().Split('\n'))
            {
                string attribute = line.Split(':')[0], value = line.Split(':')[1];

                switch (attribute)
                {
                    case "FontFamily":
                        FontFamily = new FontFamily(value);
                        break;

                    case "FontSize":
                        FontSize = int.Parse(value);
                        break;
                    case "Langue":
                        Langue = value;
                        break;
                }
            }

            stream.Close();

            //Read the user data
            stream = new StreamReader("../../Data/RepMaxRepData.txt");
            string[] content = stream.ReadToEnd().Split('\n');
            stream.Close();

            // Select data and save it in lists
            foreach (string line in content) 
            {
                string[] data = line.Split('/');
                if ((ListDays.Count > 0 && ListDays[-1] != int.Parse(data[0])) || ListDays.Count == 0) //Avoiding the same day to be present multiple time
                    ListDays.Add(int.Parse(data[0]));

                if ((ListMonths.Count > 0 &&  ListMonths[-1] != int.Parse(data[1])) || ListMonths.Count == 0)
                    ListMonths.Add(int.Parse(data[1]));
                
                if ((ListYears.Count > 0 && ListYears[-1] != int.Parse(data[2])) || ListYears.Count == 0)
                    ListYears.Add(int.Parse(data[2]));

                ListExercises.Add(
                    new Tuple<int, int>
                        (int.Parse(data[3]), int.Parse(data[4]))
                );
            }

            if (ListDays.Count <= 28)
            {
                Labels = new string[ListDays.Count];
                for (int i = 0; i < ListDays.Count; i++) 
                {
                    Labels[i] = ListDays[i].ToString();
                }
            }
            else
            {
                stream = new StreamReader($"../../ressources/text/{Langue}/Months");
                content = stream.ReadToEnd().Split('\n');
                stream.Close();

                for (int i = 0; i < ListMonths.Count; i++)
                {
                    Labels[i] = content[ListMonths[i]];         //Select the corresponding month in the user language
                }
            }
        }

        // Return the average of a List<int> list

        public int GetAverage(List<int> list)
        {
            int count = 0;
            int total = 0;

            foreach (int item in list)
            {
                total += item;
                count++;
            }
            return total/count;
        }
    }
}
