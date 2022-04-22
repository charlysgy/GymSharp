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
        int cc;
        int rm;
        int rmObj;
        int crypt;
        string sex;
        int weightObj;
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
            profile.weight = Int32.Parse(WeightBox.Text);
        }
        public string GetInfoCC()
        {
            return CCBoxProfile.SelectedText;
        }

        private void CCBoxProfile_TouchEnter(object sender, TouchEventArgs e)
        {
            cc = Int32.Parse(RMBoxProfile.Text);
        }
        public string GetInfoCrypt()
        {
            return CryptBoxProfile.SelectedText;
        }

        private void CryptBoxProfile_TouchEnter(object sender, TouchEventArgs e)
        {
            crypt = Int32.Parse(CryptBoxProfile.Text);
        }
        public string GetInfoSex()
        {
            return SexBoxProfile.SelectedText;
        }

        private void SexBoxProfile_TouchEnter(object sender, TouchEventArgs e)
        {
            sex = SexBoxProfile.Text;
        }
        public string GetInfoRMObj()
        {
            return RMObjBoxProfile.SelectedText;
        }

        private void RMObjBoxProfile_TouchEnter(object sender, TouchEventArgs e)
        {
            rmObj = Int32.Parse(RMObjBoxProfile.Text);
        }
        public string GetInfoWeightObj()
        {
            return WeightObjBoxProfile.SelectedText;
        }

        private void WeightObjBoxProfile_TouchEnter(object sender, TouchEventArgs e)
        {
            weightObj = Int32.Parse(WeightObjBoxProfile.Text);
        }
        public string GetInfoRM()
        {
            return RMBoxProfile.SelectedText;
        }

        private void RMBoxProfile_TouchEnter(object sender, TouchEventArgs e)
        {
            rm = Int32.Parse(RMBoxProfile.Text);
        }
    }
}
