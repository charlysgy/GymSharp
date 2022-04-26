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
using System.Windows.Media.Imaging;

namespace GymSharp.MVVM.ViewModel
{
    internal class ListeExerciceViewModel : UserControl
    {
        public static ListeExerciceView View { get; set; }
        public static List<List<string>> ListeText = FileToListOfString("C:/Users/theodore2/Desktop/Epita/1ère année PREPA/Projet S2/GymSharp/GymSharp/ressources/text/Francais-fr/Text_Exo_fr/ListeInfo.txt");

        public ListeExerciceViewModel()
        {

        }

        public static List<List<string>> FileToListOfString(string path)
        {
            StreamReader stream = new StreamReader(path);
            List<List<string>> listRetour = new List<List<string>>();
            string text = stream.ReadToEnd();
            string strTransi = "";
            foreach (var c in text)
            {
                if (c == '$')
                {
                    listRetour.Add(new List<string> { strTransi });
                    strTransi = "";
                }
                else
                {
                    strTransi += c;
                }
            }
            return listRetour;
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
                VerticalScrollBarVisibility = ScrollBarVisibility.Hidden,
                CanContentScroll = true,  
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
            text.Text = getText(muscle, ListeTexte);

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
                View.title.Text = "Information Exercice Bras";
            }
            else if (muscle == 3)
            {
                View.title.Text = "Information Bras";
            }
            else if (muscle == 6)
            {
                View.title.Text = "Information Jambe";
            }
            else if (muscle > 60 && muscle < 85)
            {
                View.title.Text = "Information Exercice Jambe";
            }
            else if (muscle == 2)
            {
                View.title.Text = "Information Dos";
            }
            else if (muscle > 20 && muscle < 30 || muscle == 210 || muscle == 211 || muscle == 212)
            {
                View.title.Text = "Information Exercice Dos";
            }
            else if (muscle == 1)
            {
                View.title.Text = "Information Pectoraux";
            }
            else if (muscle > 10 && muscle < 20)
            {
                View.title.Text = "Information Exercice Pectoraux";
            }
            else if (muscle == 4)
            {
                View.title.Text = "Information Epaules";
            }
            else if (muscle > 40 && muscle < 50)
            {
                View.title.Text = "Information Exercice Epaules";
            } 
            else if (muscle == 5)
            {
                View.title.Text = "Information Abdos";
            }
            else if (muscle > 50 && muscle < 60)
            {
                View.title.Text = "Information Exercice Dos";
            }

            View.panelText.Children.Clear();
            TextBlock text = new TextBlock()
            {
                Foreground = System.Windows.Media.Brushes.White,
                TextAlignment = TextAlignment.Left,
                FontSize = 20,
                Margin = new Thickness(25, 0, 10, 0),
                FontFamily = new System.Windows.Media.FontFamily("Berlin sans FB"),
            };
            text.Text = getText(muscle, ListeText);
            View.panelText.Children.Add(text);

            RadioButton radio = new RadioButton();
            View.panelText.Children.Add(radio);
            //Image
            View.imageExo.Source = new BitmapImage(new Uri(getImage(muscle)));
            
        }
        
        //Permet d'avoir le chemin des fichiers textes en fonction de leur nom d'exo. EX: 3.txt -> Bras
        private static string getText(int muscle, List<List<string>> ListeTexte)
        {
            return ListeTexte[muscle][0].Replace("\r\n", Environment.NewLine);
        }

        private static string getImage(int muscle)
        {

            if (muscle > 30 && muscle < 40 || muscle == 310 || muscle == 311 || muscle == 312 || muscle == 3)
            {
                return "C:/Users/theodore2/Desktop/Epita/1ère année PREPA/Projet S2/GymSharp/GymSharp/ressources/Images/Images_Exos/3.jpg";
            }
            else if (muscle > 60 && muscle < 85 || muscle == 6)
            {
                return "C:/Users/theodore2/Desktop/Epita/1ère année PREPA/Projet S2/GymSharp/GymSharp/ressources/Images/Images_Exos/6.jpg";
            }
            else if (muscle > 20 && muscle < 30 || muscle == 210 || muscle == 211 || muscle == 212 || muscle == 2)
            {
                return "C:/Users/theodore2/Desktop/Epita/1ère année PREPA/Projet S2/GymSharp/GymSharp/ressources/Images/Images_Exos/2.jpg";
            }
            else if (muscle > 10 && muscle < 20 || muscle == 1)
            {
                return "C:/Users/theodore2/Desktop/Epita/1ère année PREPA/Projet S2/GymSharp/GymSharp/ressources/Images/Images_Exos/1.jpg";
            }
            else if (muscle > 40 && muscle < 50 || muscle == 4)
            {
                return "C:/Users/theodore2/Desktop/Epita/1ère année PREPA/Projet S2/GymSharp/GymSharp/ressources/Images/Images_Exos/4.jpg";
            }
            else
            {
                return "C:/Users/theodore2/Desktop/Epita/1ère année PREPA/Projet S2/GymSharp/GymSharp/ressources/Images/Images_Exos/5.jpg";
            }
        }
    }
}
