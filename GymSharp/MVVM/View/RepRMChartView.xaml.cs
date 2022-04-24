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

        public void ExoChecked(object sender, RoutedEventArgs e)
        {
            foreach (var element in gridBodyParts.Children)
            {
                if (element is RadioButton)
                {
                    RadioButton button = (RadioButton)element;
                    button.IsChecked = false;
                    Console.WriteLine(button.Name);
                }
            }

            RadioButton radio = (RadioButton)sender;
            radio.IsChecked = false;
            RepRMChartViewModel.ShowSeries((int)Enum.Parse(typeof(Exercice), radio.Name));
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RepRMChartViewModel.InitExos();
        }
    }
}
