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

namespace GymSharp.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour ParametresView.xaml
    /// </summary>
    public partial class ParametresView : UserControl
    {
        public ParametresView()
        {
            InitializeComponent();
        }

        public void Checked(object sender, RoutedEventArgs e)
        {
            if (Valid.IsChecked == true)
            {
                
            }
        }
    }
}
