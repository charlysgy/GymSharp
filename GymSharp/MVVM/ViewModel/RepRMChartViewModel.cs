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

        public string textPart1 { get; }
        public string textPart2 { get; }
        public string textPart3 { get; }
        public string textPart4 { get; }
        public string textPart5 { get; }
        public string textPart6 { get; }
        public string textPart7 { get; }

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
                // Splitting the text in multiple parts in order to find each text for each UIElement to tranlsate
                string muscleFile = "Translated.txt";
                FindPath.FindFile(ref muscleFile);
                StreamReader stream = new StreamReader(muscleFile);
                string[] content = stream.ReadToEnd().Split('$');
                stream.Close();

                string graphTexts = "";
                foreach (string block in content)
                {
                    if (block.Contains("graphique"))
                    {
                        graphTexts = block;
                    }
                }

                foreach (string line in graphTexts.Split('\n'))
                {
                    string[] temp = line.Split(':');
                    switch (temp[0])
                    {
                        case "radiobuttons":
                            PecRadButton =    temp[1].Split(';')[0];
                            DosRadButton =    temp[1].Split(';')[1];
                            BrasRadButton =   temp[1].Split(';')[2];
                            EpauleRadButton = temp[1].Split(';')[3];
                            AbsRadButton =    temp[1].Split(';')[4];
                            QuadRadButton =   temp[1].Split(';')[5];
                            IschioRadButton = temp[1].Split(';')[6];
                            MolletRadButton = temp[1].Split(';')[7];
                            break;

                        case "textPart1":
                            textPart1 = temp[1].Replace("\n", "");
                            break;

                        case "textPart2":
                            textPart2 = temp[1].Replace("\n", "");
                            break;

                        case "textPart3":
                            textPart3 = temp[1].Replace("\n", "");
                            break;

                        case "textPart4":
                            textPart4 = temp[1].Replace("\n", "");
                            break;

                        case "textPart5":
                            textPart5 = temp[1];
                            break;

                        case "textPart6":
                            textPart6 = temp[1];
                            break;

                        case "textPart7":
                            textPart7 = temp[1];
                            break;

                        case "axisXName":
                            AxisXName = temp[1].Replace("\n", "");
                            break;

                        case "axisYName":
                            AxisYName = temp[1].Replace("\n", "");
                            break;
                    }
                }
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

                textPart1 = "Chaque point sur le graphique correspond ";
                textPart2 = "(en rouge) ";
                textPart3 = "à la moyenne du poids utilisé lors de votre séance et ";
                textPart4 = "(en bleue) ";
                textPart5 = "à la moyenne du nombre de répétition sur cet exercice durant votre séance.";
                textPart6 = "&#x0a;Si vos séances s'étale sur plusieurs semaine alors chaque point correspond à la moyenne sur chaque semaine";
                textPart7 = "&#x0a;Si vos séances s'étale sur plusieurs mois alors chaque point correspond à la moyenne sur chaque mois";

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
                        radio.Name = str.Replace(" ", "_");
                        radio.Content = str;
                        radio.Cursor = System.Windows.Input.Cursors.Hand;
                        radio.Checked += View.ExoChecked;
                        radio.Style = (Style)Application.Current.TryFindResource("StyleBoutons");
                        radio.BorderBrush = Brushes.Black;
                        radio.BorderThickness = new Thickness(5);
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