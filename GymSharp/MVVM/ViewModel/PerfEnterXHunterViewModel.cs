using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GymSharp.MVVM.Model;
using System.IO;
using System.Windows.Controls;
using GymSharp.MVVM.View;
using GymSharp.ressources.enums;
using System.Windows.Media.Imaging;

namespace GymSharp.MVVM.ViewModel
{
    internal class PerfEnterXHunterViewModel : UserControl
    {
        public static PerfEnterXHunterView View { get; set; }

        public PerfEnterXHunterViewModel()
        {

        }

        public static (string, bool) PerfEnter()
        {
            DateTime date = DateTime.Now;
            bool test1 = false;
            bool test2 = false;
            bool test3 = false;
            string perf = date.Day.ToString() + "/" + date.Month.ToString() + "/" + date.Year.ToString() + "/";
            foreach (RadioButton button in View.PanelListeExercice.Children)
            {
                if (button.IsChecked == true)
                {
                    perf += button.Name.Replace("_", "");
                    test1 = true;
                }
            }
            foreach (RadioButton button in View.PanelListeRepetition.Children)
            {
                if (button.IsChecked == true)
                {
                    perf += button.Name.Replace("_R", "") + "/";
                    test2 = true;
                }
            }
            foreach (RadioButton button in View.PanelListePoids.Children)
            {
                if (button.IsChecked == true)
                {
                    perf += button.Name.Replace("_P", "") + "/";
                    test2 = true;
                }
            }
            perf += "None";
            return (perf, test1 && test2 && test3);
        }
    }
}
