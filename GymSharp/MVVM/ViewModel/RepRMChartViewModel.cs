using System;
using System.Windows;
using System.IO;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;
using System.Collections.Generic;
using GymSharp.MVVM.Model;
using GymSharp.ressources.enums;

namespace GymSharp.MVVM.ViewModel
{
    internal class RepRMChartViewModel : Window
    {
        #region Attributes
        public SeriesCollection SeriesCollection { get; }
        public Func<double, string> Yformatter { get; }

        public string AxisXName { get; }
        public string AxisYName { get; }
        public string PecRadButtons { get; }
        public string DosRadButtons { get; }
        public string BrasRadButtons { get; }
        public string EpauleRadButtons { get; }
        public string AbsRadButtons { get; }
        public string QuadRadButtons { get; }
        public string IschioRadButtons { get; }
        public string MolletRadButtons { get; }
        public string[] Labels { get; }
        public bool DataLabels = true;
        
        private readonly List<Tuple<int, int>> ListExercises = new List<Tuple<int, int>>();
        private readonly List<int> ListDays = new List<int>();
        private readonly List<int> ListMonths = new List<int>();
        private readonly List<int> ListYears = new List<int>();
        private readonly StreamReader stream;
        private readonly string Langue;
        private readonly string[] content;

        #endregion

        // Constructor of the line chart 

        public RepRMChartViewModel()
        {
            // Read the config text file to set attributes values and Chart basic configuration

            foreach (string line in GraphicClass.GetConfig("../../Data/config.txt"))
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

            if (Langue != "Francais-fr")
            {
                stream = new StreamReader($"../../ressources/text/{Langue}/Muscles.txt");
                content = stream.ReadToEnd().Split('\n');
                stream.Close();

                PecRadButtons = content[(int)Muscles.Pectoraux];
                DosRadButtons = content[(int)Muscles.Dos];
                BrasRadButtons = content[(int)Muscles.Biceps];
                EpauleRadButtons = content[(int)Muscles.Epaules];
                AbsRadButtons = content[(int)Muscles.Abdominaux];
                QuadRadButtons = content[(int)Muscles.Quadirceps];
                IschioRadButtons = content[(int)Muscles.Ischios];
                MolletRadButtons = content[(int)Muscles.Mollets];
            }
            else
            {
                PecRadButtons = "Pectauraux";
                DosRadButtons = "Dos";
                BrasRadButtons = "Bras";
                EpauleRadButtons = "Epaules";
                AbsRadButtons = "Abdos";
                QuadRadButtons = "Quadricpes";
                IschioRadButtons = "Ischios";
                MolletRadButtons = "Mollets";
            }

            content = GraphicClass.GetData("../../Data/RepMaxRepData.txt");
            ListDays = GraphicClass.GetListDays(content);
            ListMonths = GraphicClass.GetListMonths(content);
            ListYears = GraphicClass.GetListYears(content);
            
        }
    }
}
