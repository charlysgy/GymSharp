using System.Windows;
using GymSharp.MVVM.View;
using System.IO;
using GymSharp.ressources.Utils;

namespace GymSharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FindPath.FindFile("MainWindow.xaml");
        }

        private void HomeCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
        }

        private void ExercicesCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new ListeExerciceView();
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
