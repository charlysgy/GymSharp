﻿using System;
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
        int height;
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
        private void FirstNameBoxProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UserProfile.firstName = FirstNameBox.Text;
                UserProfile.FillFirstName(UserProfile.firstName);
            }            
        }
        
        private void LastNameBoxProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UserProfile.lastName = LastNameBox.Text;
                ///UserProfile.FillLastName();
            }
        }
        private void AgeBoxProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UserProfile.age = Int32.Parse(AgeBox.Text);
                ///UserProfile.FillAge();
            }
        }

        private void WeightBoxProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                UserProfile.weight = Int32.Parse(WeightBox.Text);
                ///UserProfile.FillWeight();
            }
        }

        private void HeightBoxProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                height = Int32.Parse(HeightBox.Text);
            }
        }
        private void CCBoxProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                cc = Int32.Parse(CCBoxProfile.Text);
            }
        }
        private void CryptBoxProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                crypt = Int32.Parse(CryptBoxProfile.Text);
            }
        }
        private void SexBoxProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                sex = SexBoxProfile.Text;
            }
        }
        private void RMBoxProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                rm = Int32.Parse(RMBoxProfile.Text);
            }
        }
        private void RMObjBoxProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                rmObj = Int32.Parse(RMObjBoxProfile.Text);
            }
        }
        private void WeightObjBoxProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                weightObj = Int32.Parse(WeightObjBoxProfile.Text);
            }
        }       
    }
}
