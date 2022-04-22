using System;
using System.Windows;
using System.Windows.Controls;
using GymSharp.MVVM.ViewModel;

namespace GymSharp.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour UserControl2.xaml
    /// </summary> 
    public partial class ListeExerciceView : UserControl
    {

        public ListeExerciceView()
        {
            InitializeComponent();
            ListeExerciceViewModel.View = this;
        }

        public void BodyPartChecked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            RepRMChartViewModel.ChangeMuscleButtons(int.Parse(radio.Name.Replace("_", "")));
        }

        

    }
}
