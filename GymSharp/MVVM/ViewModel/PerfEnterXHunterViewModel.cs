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

        public static string PerfEnter()
        {
            DateTime date = DateTime.Now;
            
            string perf = date.Day.ToString() + "/" + date.Month.ToString() + "/" + date.Year.ToString() + "/";
            foreach (RadioButton button in View.PanelListeExercice.Children)
            {
                if (button.IsChecked == true)
                {
                    perf += button.Name.Replace("_", "") + "/";
                   
                }
            }
            foreach (RadioButton button in View.PanelListeRepetition.Children)
            {
                if (button.IsChecked == true)
                {
                    perf += button.Name.Replace("_R", "") + "/";
                   
                }
            }
            foreach (RadioButton button in View.PanelListePoids.Children)
            {
                if (button.IsChecked == true)
                {
                    perf += button.Name.Replace("_P", "") + "/";
                }
            }
            perf += "none";
            return perf;
        }
    }
}
