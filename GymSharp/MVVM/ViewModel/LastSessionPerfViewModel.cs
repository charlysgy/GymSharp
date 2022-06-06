using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymSharp.Utils;
using System.IO;
using GymSharp.ressources.enums;
using GymSharp.MVVM.View;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace GymSharp.MVVM.ViewModel
{
    public class LastSessionPerfViewModel : UserControl
    {
        public static LastSessionPerfView View { get; set; }
        public LastSessionPerfViewModel()
        {            
        }

        private static string GetLangue()
        {
            string path = "config.txt";
            if (!FindPath.FindFile(ref path))
                throw new Exception("File not found excpetion");

            StreamReader sr = new StreamReader(path);
            foreach (string line in sr.ReadToEnd().Split('\n'))
            {
                if (line.Contains("Langue"))
                {
                    return line.Split(':')[1];
                }
            }
            return "Francais-fr";
        }

        public static void TextBlockClicked(object sender, RoutedEventArgs e)
        {
            foreach (UIElement border in View.grid.Children)
            {
                if (border is Border)
                {
                    foreach (UIElement child in ((StackPanel)((Border)border).Child).Children)
                    {
                        if (child is TextBlock)
                        {
                            ((TextBlock)child).MaxHeight = 20;
                        }
                    }
                }
            }

            ((TextBlock)sender).MaxHeight = ((TextBlock)sender).MaxHeight == 200 ? 20 : 200;
        }

        public static void DisplayLastSessions()
        {
            View.title.Text = "Voici vos performance sur vos trois dernières séances";
            View.description.Text = "Pour voir le détail des exercices sur une des ces séances, cliquez sur un exercice.\n" +
                                    "Vous pourrez ainsi voir la moyenne de votre charge et la moyenne du nombre de répétion que vous avez effectué\n" + 
                                    "Pour voir un suivi de vos performance sur un plus long terme, rendez-vous sur l'onglet graphique, pour cela," + 
                                    "cliquez sur l'icone de l'application en haut à gauche puis cliquez sur \"Graphique\", enfin sélectionnez l'exercice" + 
                                    "dont vous souhaitez voir l'évolution";

            string path = "exosData.txt";
            if (!FindPath.FindFile(ref path))
            {
                if (GetLangue() == "Français-fr")
                {
                    View.LastDayTitle.Text = "Vous n'avez";
                    View.LastDay2Title.Text = "aucune session";
                    View.LastDay3Title.Text = "à afficher.";
                }
                return;
            }


            StreamReader sr = new StreamReader(path);
            int? tempDay = null;
            int n = 3;
            string[] parts = new[] {""};
            string content = sr.ReadToEnd();

            if (content == "")
            {
                View.LastDayTitle.Text = "Vous n'avez";
                View.LastDay2Title.Text = "aucune session";
                View.LastDay3Title.Text = "à afficher.";
                return;
            }

            foreach (string line in content.Split('\n').Reverse())
            {
                if (line == "")
                    continue;
                parts = line.Split('/');

                TextBlock textBlock = new TextBlock()
                {
                    FontSize = 20,
                    FontFamily = new FontFamily("Berlin sans FB"),
                    Foreground = Brushes.White,
                    Background = Brushes.Transparent,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(15),
                    MaxHeight = 20
                };
                textBlock.MouseDown += TextBlockClicked;
                
                DateTime date = new DateTime(int.Parse(parts[2]), int.Parse(parts[1]), int.Parse(parts[0]));

                if (tempDay is null)
                {
                    tempDay = date.Day;

                    textBlock.Text = Enum.GetName(typeof(Exercice), int.Parse(parts[3])).ToString().Replace("_", " ");
                    textBlock.Text += $"\n    Poids ajouté (en moyenne) = {parts[5]}\n    Nombre de répétition (en moyenne) = {parts[4]}";

                    View.LastDayTitle.Text = $"Séance du {date.Day}/{date.Month}/{date.Year}";
                    View.LastDayPerfPanel.Children.Add(textBlock);
                }
                else if (int.Parse(parts[0]) == tempDay && n > 0)
                {
                    textBlock.Text = Enum.GetName(typeof(Exercice), int.Parse(parts[3])).ToString().Replace("_", " ");
                    textBlock.Text += $"\n    Poids ajouté (en moyenne) = {parts[5]}\n    Nombre de répétition (en moyenne) = {parts[4]}";

                    switch (n)
                    {
                        case 1:
                            View.LastDay3PerfPanel.Children.Add(textBlock);
                            break;
                        case 2:
                            View.LastDay2PerfPanel.Children.Add(textBlock);
                            break;
                        case 3:
                            View.LastDayPerfPanel.Children.Add(textBlock);
                            break;
                    }
                }
                else if (int.Parse(parts[0]) != tempDay && n > 0)
                { 
                    n--;
                    tempDay = int.Parse(parts[0]);

                    textBlock.Text = Enum.GetName(typeof(Exercice), int.Parse(parts[3])).ToString().Replace("_", " ");
                    textBlock.Text += $"\n    Poids ajouté (en moyenne) = {parts[5]}\n    Nombre de répétition (en moyenne) = {parts[4]}";

                    switch (n)
                    {
                        case 1:
                            View.LastDay3Title.Text = $"Séance du {date.Day}/{date.Month}/{date.Year}";
                            View.LastDay3PerfPanel.Children.Add(textBlock);
                            break;
                        case 2:
                            View.LastDay2Title.Text = $"Séance du {date.Day}/{date.Month}/{date.Year}";
                            View.LastDay2PerfPanel.Children.Add(textBlock);
                            break;
                    }
                }
                else
                {
                    break;
                }
            }
            if (n != 0)
            {
                TextBlock textBlock = new TextBlock()
                {
                    FontSize = 20,
                    FontFamily = new FontFamily("Berlin sans FB"),
                    Foreground = Brushes.White,
                    Background = Brushes.Transparent,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    Margin = new Thickness(5),
                    MaxHeight = 20
                };
                textBlock.MouseDown += TextBlockClicked;

                DateTime date = new DateTime(int.Parse(parts[2]), int.Parse(parts[1]), int.Parse(parts[0]));

                switch (n)
                {
                    case 1:
                        View.LastDay3PerfPanel.Children.Add(textBlock);
                        break;
                    case 2:
                        View.LastDay2PerfPanel.Children.Add(textBlock);
                        break;
                    case 3:
                        View.LastDayPerfPanel.Children.Add(textBlock);
                        break;
                }
            }
            sr.Close();
        }
    }
}
