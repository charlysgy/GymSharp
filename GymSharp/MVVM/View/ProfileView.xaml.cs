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

namespace GymSharp.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        UserProfile profile = new UserProfile();
        public ProfileView()
        {
            InitializeComponent();
        }

        public string GetInfoFirstName()
        {
            return FirstNameBox.SelectedText;
        }

        private void FirstNameBoxProfile_TouchEnter(object sender, TouchEventArgs e)
        {
            profile.firstName = FirstNameBox.Text;
        }
        public string GetInfoName()
        {
            return NameBox.SelectedText;
        }

        private void NameBoxProfile_TouchEnter(object sender, TouchEventArgs e)
        {
            profile.lastName = NameBox.Text;
        }
        public string GetInfoAge()
        {
            return AgeBox.SelectedText;
        }

        private void AgeBoxProfile_TouchEnter(object sender, TouchEventArgs e)
        {
            profile.age = Int32.Parse(FirstNameBox.Text);
        }
        public string GetInfoHeight()
        {
            return HeightBox.SelectedText;
        }

        private void HeightBoxProfile_TouchEnter(object sender, TouchEventArgs e)
        {
            Height = Int32.Parse(HeightBox.Text);
        }
        public string GetInfoWeight()
        {
            return WeightBox.SelectedText;
        }

        private void WeightBoxProfile_TouchEnter(object sender, TouchEventArgs e)
        {
            profile.weight = Int32.Parse(FirstNameBox.Text);
        }
    }
}
