using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using GymSharp.MVVM.ViewModel;
using System.IO;
using GymSharp.Utils;
using System.Linq;


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
                /*
                string[] content;
                using (StreamReader sr = new StreamReader(path))
                {
                    content = sr.ReadToEnd().Replace("\r", "").Split('\n');
                }

                string lastDay = perf.Split('/')[0];
                string month = perf.Split('/')[1];
                string year = perf.Split('/')[2];
                string numExo = perf.Split('/')[3];
                int rep = int.Parse(perf.Split('/')[4]);
                int weight = int.Parse(perf.Split('/')[5]);
                int coef = 1;

                foreach (string line in content.Reverse())
                {
                    if (lastDay == line.Split('/')[0] && line.Split('/')[3] == numExo)
                    {
                        coef++;
                        rep = (rep + int.Parse(line.Split('/')[4])) / coef;
                        weight = (weight + int.Parse(line.Split('/')[5])) / coef;
                    }
                    else
                    {
                        for(; coef > 0; coef--)
                        {
                            content.
                        }
                        StreamWriter sw = new StreamWriter(path, true);
                        sw.WriteLine(perf);
                        sw.Close();
                        break;
                    }
                }*/
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
