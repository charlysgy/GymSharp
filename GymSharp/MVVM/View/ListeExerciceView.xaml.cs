using System;
using System.Windows;
using System.Windows.Controls;
using GymSharp.MVVM.ViewModel;

namespace GymSharp.MVVM.View
{
    /// <summary>
    /// Logique d'interaction pour UserControl2.xaml
    /// </summary> 
    public partial class ListeExerciceView : UserControl
    {
        
        public ListeExerciceView()
        {
            InitializeComponent();
            ListeExerciceViewModel.View = this;
        }

        public void ClearStackPanel(StackPanel name)
        {
            if (name != null)
            {
                name.Visibility = System.Windows.Visibility.Collapsed;
            }        
        }

        public void ClearText(TextBlock text)
        {
            if (text != null)
            {
                TextExoBras1.Visibility = System.Windows.Visibility.Collapsed;
            }           
        }

        private void StackPanel_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
        private void Changement_StackPanel (object sender, RoutedEventArgs e)
        {
            StackPanel name = null; 
            TextBlock text = null;

            if (ButExoBras1.IsChecked == true)
            {
                ClearStackPanel(name);
                ClearText(text);
                TextExoBras1.Visibility = System.Windows.Visibility.Visible;
                StackPanelExoBras1.Visibility = System.Windows.Visibility.Visible;
                name = StackPanelExoBras1;
                text = TextExoBras1;
                
                
            }
            if (ButExoBras2.IsChecked == true)
            {
                ClearStackPanel(name);
                ClearText(text);
                TextExoBras2.Visibility = System.Windows.Visibility.Visible;
                StackPanelExoBras2.Visibility = System.Windows.Visibility.Visible;
                name = StackPanelExoBras2;
                text = TextExoBras2;
            }
        }
    }
}
