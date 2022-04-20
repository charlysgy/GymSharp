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
            foreach (Button but in buttonContainer.Children)
            {
                but.Height = ActualHeight / 8;
                but.Width = ActualHeight / 8;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Content)
            {
                case "Left":
                    pCamera.Position = new Point3D(3, 0, 0);
                    pCamera.LookDirection = new Vector3D(-1, 0, 0);
                    pLight.Direction = new Vector3D(-1, 0, 0);
                    break;
                case "Right":
                    pCamera.Position = new Point3D(-3, 0, 0);
                    pCamera.LookDirection = new Vector3D(1, 0, 0);
                    pLight.Direction = new Vector3D(1, 0, 0);
                    break;
                case "Up":
                    pCamera.Position = new Point3D(0, 3, 0);
                    pCamera.LookDirection = new Vector3D(0.0001, -1, 0);
                    pLight.Direction = new Vector3D(0.0001, -1, 0);
                    break;
                case "Down":
                    pCamera.Position = new Point3D(0, -3, 0);
                    pCamera.LookDirection = new Vector3D(0.0001, 1, 0);
                    pLight.Direction = new Vector3D(0.0001, 1, 0);
                    break;
            }
        }
    }
}
