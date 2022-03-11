using System.Windows;
using GymSharp.MVVM.View; /*Permet de définir où se trouve les views*/

namespace GymSharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HomeCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
        }

        private void ExercicesCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new ListeExercices();
            viewContainer.Children.Add(element);
        }

        private void ParametreCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new parametres();
            viewContainer.Children.Add(element);
        }

        private void GraphiqueCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new RepRMChartView();
            viewContainer.Children.Add(element);
        }
    }
}
