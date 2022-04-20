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

namespace GymSharp.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour FirstStartView.xaml
    /// </summary>
    public partial class FirstStartView : Window
    {
        public FirstStartView()
        {
            InitializeComponent();
            /*ImageBrush lBoxBg = new ImageBrush();
            lBoxBg.ImageSource = new BitmapImage(new Uri(@"../../ressources/Images/enflag.png"));*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FirstStartViewModel.StartButtonClicked(this);
            MainWindow window = new MainWindow();
            Content = window;
        }
    }
}
