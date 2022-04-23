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
    /// Logique d'interaction pour FirstStartView.xaml
    /// </summary>
    public partial class FirstStartView : Window
    {

        public string FirstName;
        public FirstStartView()
        {
            InitializeComponent();
            /*ImageBrush lBoxBg = new ImageBrush();
            lBoxBg.ImageSource = new BitmapImage(new Uri(@"../../ressources/Images/enflag.png"));*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserProfile.FillFirstName(this);
            this.Close();
        }

        public void OpenDialog()
        {
            this.ShowDialog();
        }

        public void GetInfoFirstName()
        {
            FirstName = FirstNameBox.Text;
        }

        private void FirstNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine(FirstNameBox.Text);
        }
    }
}
