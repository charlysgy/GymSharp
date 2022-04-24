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
            //Suppression des anciens éléments 
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

            //Création d'un textBlock contenant le titre de l'exo
            View.gridAfficheExo.RowDefinitions.Add(new RowDefinition());
            TextBlock title = new TextBlock()
            {
                Foreground = System.Windows.Media.Brushes.White,
                TextAlignment = TextAlignment.Right,
                FontSize = 50,
                Margin = new Thickness(0, 0, 25, 0),
            };
            title.SetValue(Grid.RowProperty, 0);
            title.SetValue(Grid.ColumnProperty, 1);

            //Ajout de 2 collonnes, une pour le texte et l'aute pour l'image
            View.gridAfficheExo.ColumnDefinitions.Add(new ColumnDefinition());
            ColumnDefinition columnDefinition = new ColumnDefinition()
            {
                Width = GridLength.Auto,
            };
            View.gridAfficheExo.ColumnDefinitions.Add(columnDefinition);

            //Création d'un ScrollViewer contenant le texte associé au titre
            View.gridAfficheExo.RowDefinitions.Add(new RowDefinition());
            ScrollViewer scrollViewer = new ScrollViewer()
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
                VerticalScrollBarVisibility = ScrollBarVisibility.Visible,
                CanContentScroll = true,
                Height = 500,
                
            };
            scrollViewer.SetValue(Grid.RowProperty, 1);
            scrollViewer.SetValue(Grid.ColumnProperty, 1);
           

            //Ce qui viens dans le ScrollViwer
            StackPanel stackPanel = new StackPanel()
            {
               
            };


            TextBlock text = new TextBlock()
            {
                Foreground = System.Windows.Media.Brushes.White,
                TextAlignment = TextAlignment.Right,
                FontSize = 14,
                Margin = new Thickness(0, 0, 25, 0),
                
            };
            text.Text = getText(muscle);

            //Image
            Uri imageUri = new Uri(getImage(muscle), UriKind.Relative);
            Image image = new Image()
            {
                Source = new System.Windows.Media.Imaging.BitmapImage(imageUri),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Width = 500,
                Height = 500,
                Margin = new Thickness(0, 0, 25, 0),
            };
            image.SetValue(Grid.ColumnProperty, 0);
            image.SetValue(Grid.RowProperty, 1);
            
            

            //Décide de qu'elle titre il faut
            if (muscle > 30 && muscle < 40 || muscle == 310 || muscle == 311 || muscle == 312)
            {
                title.Text = "Information Exercice Bras";
            }
            else if (muscle == 3)
            {
                title.Text = "Information Bras";
            }
            else if (muscle == 6)
            {
                title.Text = "Information Jambe";
            }
            else if (muscle > 60 && muscle < 85)
            {
                title.Text = "Information Exercice Jambe";
            }
            else if (muscle == 2)
            {
                title.Text = "Information Dos";
            }
            else if (muscle > 20 && muscle < 30 || muscle == 210 || muscle == 211 || muscle == 212)
            {
                title.Text = "Information Exercice Dos";
            }
            else if (muscle == 1)
            {
                title.Text = "Information Pectoraux";
            }
            else if (muscle > 10 && muscle < 20)
            {
                title.Text = "Information Exercice Pectoraux";
            }
            else if (muscle == 4)
            {
                title.Text = "Information Epaules";
            }
            else if (muscle > 40 && muscle < 50)
            {
                title.Text = "Information Exercice Epaules";
            }
            else if (muscle == 5)
            {
                title.Text = "Information Abdos";
            }
            else if (muscle > 50 && muscle < 60)
            {
                title.Text = "Information Exercice Dos";
            }

            //Affiche tout dans la View
            View.gridAfficheExo.Children.Add(title);
            stackPanel.Children.Add(text);
            scrollViewer.Content = stackPanel;
            View.gridAfficheExo.Children.Add(image);
            View.gridAfficheExo.Children.Add(scrollViewer);
        }
        
        //Permet d'avoir le chemin des fichiers textes en fonction de leur nom d'exo. EX: 3.txt -> Bras
        private static string getText(int muscle)
        {
            string strMuscle = muscle.ToString();
            string path = "C:/Users/theodore2/Desktop/Epita/1ère année PREPA/Projet S2/GymSharp/GymSharp/ressources/text/Francais-fr/Text_Exo_fr/" + strMuscle + ".txt";
            using (StreamReader stream = new StreamReader(path))
            {
                return stream.ReadToEnd();
            }

        }

        private static string getImage(int muscle)
        {
            string strMuscle = muscle.ToString();
            return "C:/Users/theodore2/Desktop/Epita/1ère année PREPA/Projet S2/GymSharp/GymSharp/ressources/Images/Images_Exos/" + strMuscle + ".jpg";
        }
    }
}
