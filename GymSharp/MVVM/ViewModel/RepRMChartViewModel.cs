using System;
using System.Windows;
using System.IO;
using LiveCharts;
using System.Windows.Media;
using System.Collections.Generic;
using GymSharp.MVVM.Model;
using GymSharp.ressources.enums;
using GymSharp.MVVM.View;
using System.Windows.Controls;
using System.Windows.Data;

namespace GymSharp.MVVM.ViewModel
{
    internal class RepRMChartViewModel : UserControl
    {
        #region Attributes
        public SeriesCollection SeriesCollection { get; }
        public Func<double, string> Yformatter { get; }
        public GroupItem RadioButtonsBodyParts { get; }
        public FontFamily Fontfamily { get; }
        public static RepRMChartView View { get; set; }

        public string AxisXName { get; }
        public string AxisYName { get; }
        public string PecRadButton { get; }
        public string DosRadButton { get; }
        public string BrasRadButton { get; }
        public string EpauleRadButton { get; }
        public string AbsRadButton { get; }
        public string QuadRadButton { get; }
        public string IschioRadButton { get; }
        public string MolletRadButton { get; }
        public string[] Labels { get; }
        public bool DataLabels = true;
        
        private readonly List<Tuple<int, string>> ListExercises = new List<Tuple<int, string>>();
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
                stream = new StreamReader($"../../ressources/text/{Langue}/Muscles.txt");
                content = stream.ReadToEnd().Split('\n');
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
            }

            content = GraphicClass.GetData("../../Data/RepMaxRepData.txt");
            ListDays = GraphicClass.GetListDays(content);
            ListMonths = GraphicClass.GetListMonths(content);
            ListYears = GraphicClass.GetListYears(content);
        }

        public static void ChangeGridCheckBox(Muscles muscle)
        {
            try
            {
                if (View.checkBoxGrid != null)
                {
                    foreach (int exo in Enum.GetValues(typeof(Exercice))) {

                    }
                }
            }
            catch (NullReferenceException)
            {
            }
            
        }
    }
}
