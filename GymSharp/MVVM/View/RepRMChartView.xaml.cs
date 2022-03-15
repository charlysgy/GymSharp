using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GymSharp.MVVM.ViewModel;
using GymSharp.ressources.enums;
using LiveCharts.Wpf;
using LiveCharts;
using System;

namespace GymSharp.MVVM.View
{
    /* <summary>
       Logique d'interaction pour RepRMChartView.xaml
       </summary> */
    public partial class RepRMChartView : UserControl
    {
        public RepRMChartView()
        {
            InitializeComponent();
            RepRMChartViewModel.View = this;
        }

        public void BodyPartChecked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            RepRMChartViewModel.ChangeMuscleButtons(int.Parse(radio.Name.Replace("_", "")));
        }

        public void ExoChecked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            RepRMChartViewModel.ShowSeries((int)Enum.Parse(typeof(Exercice), radio.Name));
        } 
    }
}
