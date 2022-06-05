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
            FirstNameBox.Text = UserProfile.firstName;
            LastNameBox.Text = UserProfile.lastName;
            AgeBox.Text = Convert.ToString(UserProfile.age);
            WeightBox.Text = Convert.ToString(UserProfile.weight);
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
            if (Valid.IsChecked == true)
            {
                UserProfile.FillInfos(FirstNameBox.Text, LastNameBox.Text, AgeBox.Text, WeightBox.Text, Obj);
            }
        }
    }
}
