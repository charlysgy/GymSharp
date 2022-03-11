using System.Windows;
using System.Windows.Controls;
using GymSharp.MVVM.ViewModel;
using GymSharp.ressources.enums;

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

        private void PecRadChecked(object sender, RoutedEventArgs e)
        {
            RepRMChartViewModel.ChangeGridCheckBox((Muscles)1);
        }

        private void BrasRadChecked(object sender, RoutedEventArgs e)
        {
            RepRMChartViewModel.ChangeGridCheckBox((Muscles)2);
        }

        private void DosRadChecked(object sender, RoutedEventArgs e)
        {
            RepRMChartViewModel.ChangeGridCheckBox((Muscles)3);
        }

        private void EpauleRadChecked(object sender, RoutedEventArgs e)
        {
            RepRMChartViewModel.ChangeGridCheckBox((Muscles)4);
        }

        private void AbsRadChecked(object sender, RoutedEventArgs e)
        {
            RepRMChartViewModel.ChangeGridCheckBox((Muscles)5);
        }

        private void QuadRadChecked(object sender, RoutedEventArgs e)
        {
            RepRMChartViewModel.ChangeGridCheckBox((Muscles)6);
        }

        private void IschioRadChecked(object sender, RoutedEventArgs e)
        {
            RepRMChartViewModel.ChangeGridCheckBox((Muscles)7);
        }

        private void MolletRadChecked(object sender, RoutedEventArgs e)
        {
            RepRMChartViewModel.ChangeGridCheckBox((Muscles)8);
        }
    }
}
