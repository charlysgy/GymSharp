using System;
using System.Windows;
using System.IO;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;
using System.Collections.Generic;
using GymSharp.ressources.enums;

namespace GymSharp.MVVM.ViewModel
{
    internal class RepRMChartViewModel : Window
    {

        private enum Months
        {
            Janvier,
            Fevrier,
            Mars,
            Avril,
            Mai,
            Juin,
            Juillet,
            Aout,
            Septembre,
            Octobre,
            Novembre,
            Decembre
        }

        #region Attributes
        public SeriesCollection SeriesCollection { get; }
        public Func<double, string> Yformatter { get; }

        public string AxisXName { get; }
        public string AxisYName { get; }
        public string[] Labels { get; }
        
        private List<string> ListMuscles = new List<string>();
        private List<int> ListDays = new List<int>();
        private List<int> ListMonths = new List<int>();
        private List<int> ListYears = new List<int>();

        #endregion


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
                }
            }
            stream.Close();

            stream = new StreamReader("../../Data/RepMaxRepData.txt");
            string content = stream.ReadToEnd();
            stream.Close();

            foreach (string line in content.Split('\n'))
            {
                string[] data = line.Split('/');
                if (ListDays.Count > 0 && ListDays[-1] != int.Parse(data[0]))
                {
                    ListDays.Add(int.Parse(data[0]));
                }
                if (ListMonths.Count > 0 &&  ListMonths[-1] != int.Parse(data[1]))
                {
                    ListMonths.Add(int.Parse(data[1]));
                }
                if (ListYears.Count > 0 &&  ListYears[-1] != int.Parse(data[2]))
                {
                    ListYears.Add(int.Parse(data[2]));
                }
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Répétition Max",
                    Values = new ChartValues<double> { 20, 22, 25, 30 ,35 },
                    PointGeometry = DefaultGeometries.Cross,
                    PointForeground = Brushes.Red,
                    
                }
            };

        }
    }
}
