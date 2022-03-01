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

        #endregion

        

        public RepRMChartViewModel()
        {
            // Read the config text file to set attriutes values and Chart basic configuration

            StreamReader stream = new StreamReader("../../Data/config.txt");
            foreach (string line in stream.ReadToEnd().Split('\n'))
            {
                string attribute = line.Split(';')[0], value = line.Split(';')[1];

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

            /*Faire un alogrithme qui, selon la durée sur laquelle s'étale
             * les données, affichera en label les jours, les mois ou les années
             * Poursuivre le code avec la mise en place de ces données dans le graphique*/
            

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Répétition Max",
                    Values = new ChartValues<double> { 20, 22, 25, 30 ,35 },
                    PointGeometry = DefaultGeometries.Cross,
                    PointForeground = Brushes.Red,
                    
                },
                new LineSeries
                {
                    Title = "Répétitions Moyennes",
                    Values = new ChartValues<int> { 15, 12, 10, 15 ,20 },
                    PointGeometry = DefaultGeometries.Cross,
                    PointForeground = Brushes.Black
                }
            };

        }
    }
}
