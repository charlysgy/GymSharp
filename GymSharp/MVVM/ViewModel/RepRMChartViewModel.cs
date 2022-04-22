using System;
using System.Windows;
using System.IO;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;
using GymSharp.MVVM.Model;
using GymSharp.ressources.enums;
using GymSharp.Utils;
using GymSharp.MVVM.View;

namespace GymSharp.MVVM.ViewModel
{
    public class RepRMChartViewModel : UserControl
    {
        #region Attributes
        public static SeriesCollection ChartSeries;
        public FontFamily Fontfamily { get; }
        public static RepRMChartView View { get; set; }

        public string AxisXName { get; }
        public string AxisYName { get; }
        public string[] XLabels { get; }
        public string[] YLabels { get; }
        public int Step { get; }

        public string PecRadButton { get; }
        public string DosRadButton { get; }
        public string BrasRadButton { get; }
        public string EpauleRadButton { get; }
        public string AbsRadButton { get; }
        public string QuadRadButton { get; }
        public string IschioRadButton { get; }
        public string MolletRadButton { get; }
        
        private static readonly List<int> ListDays = new List<int>();
        private static readonly List<int> ListMonths = new List<int>();
        private static readonly List<int> ListYears = new List<int>();
        private static readonly List<List<int>> ListDataExercices = new List<List<int>>();
        private static readonly List<int?> ListRM = new List<int?>();
        private readonly string Langue;

        #endregion

        // Constructor of the line chart 
        public RepRMChartViewModel()
        {
            // Read the config text file to set attributes values and Chart basic configuration
            foreach (string line in GraphicClass.GetConfig())
            {
                string attribute = line.Split(':')[0], value = line.Split(':')[1].Replace("\r", "");

                switch (attribute)
                {
                    case "FontFamily":
                        Fontfamily = new FontFamily(value);
                        break;

                    case "FontSize":
                        FontSize = int.Parse(value);
                        break;
                    case "Langue":
                        Langue = value;
                        break;
                }
            }

            if (Langue != "Francais-fr")
            {
                string muscleFile = "Muscles.txt";
                FindPath.FindFile(ref muscleFile);
                StreamReader stream = new StreamReader(muscleFile);
                string[] content = stream.ReadToEnd().Split('\n');
                stream.Close();

                PecRadButton = content[(int)Muscles.Pectoraux  -1];
                DosRadButton = content[(int)Muscles.Dos        -1];
                BrasRadButton = content[(int)Muscles.Bras      -1];
                EpauleRadButton = content[(int)Muscles.Epaules -1];
                AbsRadButton = content[(int)Muscles.Abdominaux -1];
                QuadRadButton = content[(int)Muscles.Quadirceps-1];
                IschioRadButton = content[(int)Muscles.Ischios -1];
                MolletRadButton = content[(int)Muscles.Mollets -1];
            }
            else
            {
                PecRadButton = "Pectauraux";
                DosRadButton = "Dos";
                BrasRadButton = "Bras";
                EpauleRadButton = "Epaules";
                AbsRadButton = "Abdos";
                QuadRadButton = "Quadricpes";
                IschioRadButton = "Ischios";
                MolletRadButton = "Mollets";

                AxisXName = "Date";
                AxisYName = "Poids : Kg";
            }

            string exosDataFile = "exosData.txt";
            FindPath.FindFile(ref exosDataFile);
            string[] data = GraphicClass.GetData(exosDataFile);

            GraphicClass.InitLists(data, ListDays, ListMonths, ListYears, ListDataExercices, ListRM);
            string[] daysName = new string[ListDays.Count];

            if (ListDays.Count > 30)
            {
                if (ListMonths.Count >= 12)
                {
                    for (int i = 0; i < ListDays.Count; i++)
                    {
                        DateTime date = new DateTime(ListYears[i], ListMonths[i], ListDays[i]);
                        daysName[i] = date.ToString("yyyy");
                    }
                    XLabels = daysName;
                }
                else
                {
                    for (int i = 0; i < ListDays.Count; i++)
                    {
                        DateTime date = new DateTime(ListYears[i], ListMonths[i], ListDays[i]);
                        daysName[i] = date.ToString("MMMM yyyy");
                    }
                    XLabels = daysName;
                }
            }
            else
            {
                for (int i = 0; i < ListDays.Count; i++)
                {
                    DateTime date = new DateTime(ListYears[i], ListMonths[i], ListDays[i]);
                    daysName[i] = date.ToString("dddd") + " " + date.ToString("MM");
                }
                XLabels = daysName;
            }
        }
        
        public static void InitExos()
        {
            List<List<string>> listExos = GraphicClass.GetExos();
            int index = 0;
            foreach (var element in View.grid.Children)
            {
                if (element is StackPanel)
                {
                    StackPanel panel = (StackPanel)element;
                    panel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ADADAD"));

                    foreach (string str in listExos[index])
                    {
                        RadioButton radio = new RadioButton();
                        radio.BorderBrush = Brushes.Black;
                        radio.Name = str.Replace(" ", "_");
                        radio.Content = str;
                        radio.Cursor = System.Windows.Input.Cursors.Hand;
                        radio.Checked += View.ExoChecked;
                        radio.Style = (Style)Application.Current.TryFindResource("StyleBoutons");
                        panel.Children.Add(radio);
                    }
                    index++;
                }
            }
        }

        public static void ShowSeries(int exo)
        {
            ChartValues<int> RepList = new ChartValues<int>();
            ChartValues<int> PoidsList = new ChartValues<int>();

            foreach (List<int> list in ListDataExercices)
            {
                if (list[0] == exo)
                {
                    RepList.Add(list[1]);
                    PoidsList.Add(list[2]);
                }
            }
            
            ChartSeries = new SeriesCollection
            {
                new LineSeries()
                {
                    Title = "Répétitions \n" + (Exercice)exo,
                    PointGeometry = null,
                    Values = RepList,
                    Fill = Brushes.Transparent
                },

                new LineSeries()
                {
                    Title = "Poids (Kg)",
                    PointGeometry = null,
                    Values=PoidsList,
                    Fill = Brushes.Transparent
                }
            };

            View.chart.Series = ChartSeries;
        }
    }
}