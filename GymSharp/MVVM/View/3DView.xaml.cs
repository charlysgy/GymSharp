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
using System.Windows.Media.Media3D;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GymSharp.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour _3DView.xaml
    /// </summary>
    public partial class _3DView : UserControl
    {
        public _3DView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "Left":
                    pCamera.Position = new Point3D(5, 0, 0);
                    pCamera.LookDirection = new Vector3D(-1, 0, 0);
                    break;
                case "Right":
                    pCamera.Position = new Point3D(-5, 0, 0);
                    pCamera.LookDirection = new Vector3D(1, 0, 0);
                    break;
                case "Face":
                    pCamera.Position = new Point3D(0, 0, 5);
                    pCamera.LookDirection = new Vector3D(0.0001, 0, -1);
                    break;
                case "Back":
                    pCamera.Position = new Point3D(0, 0, -5);
                    pCamera.LookDirection = new Vector3D(0.0001, 0, 1);
                    break;
            }
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
    }
}
