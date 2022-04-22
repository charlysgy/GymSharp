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

        public static void ChangeMuscleButtons(int muscle)
        {
            //Suppression des anciens radiobutton 
            List<UIElement> elementList = new List<UIElement>();
            foreach (UIElement element in View.gridAfficheExo.Children)
            {
                if (Grid.GetRow(element) == 0)
                {
                    elementList.Add(element);
                }
            }

            foreach (UIElement element in elementList)
            {
                View.gridAfficheExo.Children.Remove(element);
            }

            View.gridAfficheExo.RowDefinitions.Clear();
            View.gridAfficheExo.ColumnDefinitions.Clear();

            View.gridAfficheExo.RowDefinitions.Add(new RowDefinition());

            int currentCol = 0;
            foreach (Exercice exo in Enum.GetValues(typeof(Exercice)))
            {

                if ((int)exo < 100)
                {
                    if ((int)exo / 10 == muscle)
                    {
                        ColumnDefinition col = new ColumnDefinition
                        {
                            Width = new GridLength(1, GridUnitType.Auto)
                        };
                        View.gridAfficheExo.ColumnDefinitions.Add(col);

                        RadioButton radio = new RadioButton()
                        {
                            Name = exo.ToString(),
                            Content = exo.ToString().Replace("_", " "),
                        };
                        radio.Cursor = System.Windows.Input.Cursors.Hand;
                        radio.Margin = new Thickness(5, 0, 5, 0);
                        //radio.Checked += View.ExoChecked;
                        radio.SetValue(Grid.RowProperty, 0);
                        radio.SetValue(Grid.ColumnProperty, currentCol);
                        radio.Style = (Style)Application.Current.TryFindResource("StyleBoutons");
                        View.gridAfficheExo.Children.Add(radio);
                        currentCol++;
                    }
                }
                else
                {
                    if ((int)exo / 100 == muscle)
                    {
                        ColumnDefinition col = new ColumnDefinition
                        {
                            Width = new GridLength(1, GridUnitType.Star)
                        };

                        View.gridAfficheExo.ColumnDefinitions.Add(col);
                        RadioButton radio = new RadioButton()
                        {
                            Name = exo.ToString(),
                            Content = exo.ToString().Replace("_", " ")
                        };
                        radio.Cursor = System.Windows.Input.Cursors.Hand;
                        radio.Margin = new Thickness(5, 0, 5, 0);
                        radio.Height = double.NaN;
                        radio.Style = (Style)Application.Current.TryFindResource("StyleBoutons");
                        //radio.Checked += View.ExoChecked;
                        radio.SetValue(Grid.RowProperty, 0);
                        radio.SetValue(Grid.ColumnProperty, currentCol);
                        View.gridAfficheExo.Children.Add(radio);
                        currentCol++;
                    }
                }
            }

        }
    }
}
