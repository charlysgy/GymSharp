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
using GymSharp.MVVM.ViewModel;
using GymSharp.Utils;


namespace GymSharp.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class LastSessionPerfView : UserControl
    {
        public LastSessionPerfView()
        {
            InitializeComponent();
            LastSessionPerfViewModel.View = this;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LastSessionPerfViewModel.DisplayLastSessions();
        }
    }
}
