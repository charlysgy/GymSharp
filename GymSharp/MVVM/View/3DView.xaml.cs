using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using GymSharp.MVVM.Model;
using HelixToolkit.Wpf;
using GymSharp.Utils;
using System.Threading;

namespace GymSharp.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour _3DView.xaml
    /// </summary>
    public partial class _3DView : UserControl
    {
        private string side { get; set; }
        public _3DView(Model3DGroup group)
        {
            InitializeComponent();
            ModelVisual3D modelVisual3D = new ModelVisual3D();

            modelVisual3D.Content = group.Clone();
            myViewport.Children.Add(modelVisual3D);
            myViewport.UpdateLayout();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            side = button.Name;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Button but in buttonContainer.Children)
            {
                but.Height = ActualHeight / 8;
                but.Width = ActualHeight / 8;
            }
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (Button but in buttonContainer.Children)
            {
                but.Height = ActualHeight / 8;
                but.Width = ActualHeight / 8;
            }
        }

        private void myViewport_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point pos = e.GetPosition(myViewport);
            Console.WriteLine((pos.X, pos.Y));
        }
    }
}
