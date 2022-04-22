using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GymSharp.MVVM.Model;
using System.IO;
using System.Windows.Controls;
using GymSharp.MVVM.View;
using GymSharp.ressources.enums;

namespace GymSharp.MVVM.ViewModel
{
    internal class ListeExerciceViewModel : UserControl
    {
        public static ListeExerciceView View { get; set; }
        public ListeExerciceViewModel()
        {

        }

        public static void ChangeInfoAboutMuscle(int muscle)
        {
            //Suppression des anciens radiobutton 
            List<UIElement> elementList = new List<UIElement>();
            foreach (UIElement element in View.gridAfficheExo.Children)
            {
                elementList.Add(element);
            }

            foreach (UIElement element in elementList)
            {
                View.gridAfficheExo.Children.Remove(element);
            }

            View.gridAfficheExo.RowDefinitions.Clear();
            View.gridAfficheExo.ColumnDefinitions.Clear();


            View.gridAfficheExo.RowDefinitions.Add(new RowDefinition());
            TextBlock text = new TextBlock()
            {
                Foreground = System.Windows.Media.Brushes.White,
                TextAlignment = TextAlignment.Right,
                FontSize = 50,
                Margin = new Thickness(0, 0, 25, 0),
            };
            text.SetValue(Grid.RowProperty, 0);
            

            if (muscle > 30 && muscle < 40 || muscle == 310 || muscle == 311 || muscle == 312)
            {
                text.Text = "Information Exercice Bras";
            }
            else if (muscle == 3)
            {
                text.Text = "Information Bras";
            }
            else if (muscle == 6)
            {
                text.Text = "Information Jambe";
            }
            else if (muscle > 60 && muscle < 85)
            {
                text.Text = "Information Exercice Jambe";
            }
            else if (muscle == 2)
            {
                text.Text = "Information Dos";
            }
            else if (muscle > 20 && muscle < 30 || muscle == 210 || muscle == 211 || muscle == 212)
            {
                text.Text = "Information Exercice Dos";
            }
            else if (muscle == 1)
            {
                text.Text = "Information Pectoraux";
            }
            else if (muscle > 10 && muscle < 20)
            {
                text.Text = "Information Exercice Pectoraux";
            }
            else if (muscle == 4)
            {
                text.Text = "Information Epaules";
            }
            else if (muscle > 40 && muscle < 50)
            {
                text.Text = "Information Exercice Epaules";
            }
            else if (muscle == 5)
            {
                text.Text = "Information Abdos";
            }
            else if (muscle > 50 && muscle < 60)
            {
                text.Text = "Information Exercice Dos";
            }


            View.gridAfficheExo.Children.Add(text);
        }
    }
}
