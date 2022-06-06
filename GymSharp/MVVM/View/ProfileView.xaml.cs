using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using GymSharp;
using GymSharp.MVVM.ViewModel;
using GymSharp.Data;
using GymSharp.Utils;

namespace GymSharp.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        int height;
        string sex;
        int weightObj;
        
        public ProfileView()
        {
            InitializeComponent();
            switch(UserProfile.Get_sexe())
            {
                case "Homme":
                    Man.IsChecked = true;
                    break;
                case "Femme":
                    Woman.IsChecked = true;
                    break;
                default:
                    Other.IsChecked = true;
                    break;
            }

            switch (UserProfile.Get_objective())
            {
                case "Commencer le sport":
                    StartSport.IsChecked = true;
                    break;
                case "Améliorer mon endurance":
                    IncreaseStamina.IsChecked = true;
                    break;
                case "Améliorer ma force":
                    IncreaseStrenght.IsChecked = true;
                    break;
                case "Améliorer mon physique":
                    BetterBody.IsChecked = true;
                    break;
                case "Rester en forme":
                    KeepFit.IsChecked = true;
                    break;
            }
        }

        private void ForceFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Focus();
        }

        public void Checked(object sender, RoutedEventArgs e)
        {
            string Obj;
            if (StartSport.IsChecked == true)
            {
                Obj = (string)StartSport.Content;
            }
            else if (IncreaseStamina.IsChecked == true)
            {
                Obj = (string)IncreaseStamina.Content;
            }
            else if (IncreaseStrenght.IsChecked == true)
            {
                Obj = (string)IncreaseStrenght.Content;
            }
            else if (BetterBody.IsChecked == true)
            {
                Obj = (string)BetterBody.Content;
            }
            else
            {
                Obj = (string)KeepFit.Content;
            }

            string sexe;
            if (Man.IsChecked == true)
            {
                sexe = (string)Man.Content;
            }
            else if (Woman.IsChecked == true)
            {
                sexe= (string)Woman.Content;
            }
            else
            {
                sexe = (string)Other.Content;
            }


            if (Valid.IsChecked == true)
            {
                Console.WriteLine(FirstNameBox.Text);
                Console.WriteLine(AgeBox.Text);
                UserProfile.FillInfos(FirstNameBox.Text, LastNameBox.Text, AgeBox.Text, WeightBox.Text, HeightBox.Text, sexe, Obj);
                Valid.IsChecked = null;
                Valid.Content = "Vos données ont été enregistrées";
            }
        }
    }
}
