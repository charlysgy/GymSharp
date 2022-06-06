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
using System.Windows.Shapes;
using GymSharp.Data;
using GymSharp.MVVM.ViewModel;

namespace GymSharp.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            HelloName.Text = "Bonjour " + FirstStartView.FirstName + ", que souhaitez-vous faire aujourd'hui ?";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parent = (MainWindow)Application.Current.MainWindow;
            foreach (ListViewItem listItem in parent.List_View.Items)
            {
                listItem.IsSelected = false;
            }
            parent.WorkoutCommand(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow parent = (MainWindow)Application.Current.MainWindow;
            foreach (ListViewItem listItem in parent.List_View.Items)
            {
                listItem.IsSelected = false;
            }
            parent.HistoricalCommand(sender, e);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow parent = (MainWindow)Application.Current.MainWindow;
            foreach (ListViewItem listItem in parent.List_View.Items)
            {
                listItem.IsSelected = false;
            }
            parent.GraphiqueCommand(sender, e);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow parent = (MainWindow)Application.Current.MainWindow;
            foreach (ListViewItem listItem in parent.List_View.Items)
            {
                listItem.IsSelected = false;
            }
            parent.ModelCommand(sender, e);
        }
    }
}
 