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

            View.textInfos.Text = getText(muscle, ListeText);

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