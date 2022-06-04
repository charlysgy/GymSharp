using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using GymSharp.MVVM.ViewModel;

namespace GymSharp.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour PerfEnterXHunterView.xaml
    /// </summary>
    public partial class PerfEnterXHunterView : UserControl
    {
        public PerfEnterXHunterView()
        {
            InitializeComponent();
            PerfEnterXHunterViewModel.View = this;
        }
        
        public void ExoChecked(object sender, RoutedEventArgs e)
        {

        }

        public void PoidsChecked(object sender, RoutedEventArgs e)
        {

        }

        public void RepChecked(object sender, RoutedEventArgs e)
        {

        }

        //renvoie un couple avec d'abord un string sous la forme jj/mm/aa/NumExo/NbrRep/NbrPoids/None et le boolléen qui définis si tout les boutons étaient cliqués avant de cliqué sur valider.
        public void Checked(object sender, RoutedEventArgs e)
        {
            
            (string, bool) perf = PerfEnterXHunterViewModel.PerfEnter();
        }
    }
}
