using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using GymSharp.MVVM.ViewModel;
using System.IO;
using GymSharp.Utils;


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
            if ((string)Valid.Content == "Valider")
            {
                string perf = PerfEnterXHunterViewModel.PerfEnter();
                string path = "exosData.txt";
                FindPath.FindFile(ref path);

                using (StreamReader sr = new StreamReader(path))
                {

                }

                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine(perf);
                sw.Close();
                Valid.Content = "Enregistrer ! Cliquez pour de nouveau enregistrer une donnée";
                Valid.IsChecked = false;
            }
            else if ((string)Valid.Content == "Enregistrer ! Cliquez pour de nouveau enregistrer une donnée")
            {
                Valid.Content = "Valider";
                Valid.IsChecked = false;
                _31.IsChecked = true;
                _P1.IsChecked = true;
                _R1.IsChecked = true;
            }
            
        }
    }
}
