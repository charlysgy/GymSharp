using System;
using System.Windows;
using GymSharp.MVVM.View;
using System.IO;
using GymSharp.ressources.enums;
using System.Linq;
using GymSharp.Data;
using System.Windows.Input;
using GymSharp.Utils;
using HelixToolkit.Wpf;
using System.Windows.Media.Media3D;
using System.Windows.Controls;

namespace GymSharp
{
    public partial class MainWindow : Window
    {
        private Model3DGroup group;
        private static string pathAccueil = "messages_accueil.txt";

        public MainWindow()
        {
            string modelPath = "model.obj";
            FindPath.FindFile(ref modelPath);
            ModelImporter importer = new ModelImporter();
            Console.WriteLine(modelPath);
            group = new Model3DGroup();
            this.Dispatcher.Invoke(() => group = importer.Load($"{modelPath}"));

            InitializeComponent();
            Anecdote.Text = GetAnecdote();
            toggle_button.Width = this.Height/10;
            toggle_button.Height = this.Height/10;
            Object sender = new Object();
            RoutedEventArgs e = new RoutedEventArgs();
            HomeCommand(sender, e);
        }

        public void RouteFromBodyToExo(int muscle)
        {
            foreach (ListViewItem listItem in List_View.Items)
            {
                listItem.IsSelected = false;
            }
            viewContainer.Children.Clear();
            UIElement element = new ListeExerciceView(muscle);
            viewContainer.Children.Add(element);
        }

        public void HomeCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new HomeView();
            viewContainer.Children.Add(element);
        }

        public void ExercicesCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new ListeExerciceView();
            viewContainer.Children.Add(element);
        }

        public void ParametresCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new ParametresView();
            viewContainer.Children.Add(element);
        }

        public void GraphiqueCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new RepRMChartView();
            viewContainer.Children.Add(element);
        }

        public void WorkoutCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new PerfEnterXHunterView();
            viewContainer.Children.Add(element);
        }

        public void HistoricalCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new LastSessionPerfView();
            viewContainer.Children.Add(element);
        }

        public void ModelCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new _3DView(group);
            viewContainer.Children.Add(element);
        }
        public void ProfileCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new ProfileView();
            viewContainer.Children.Add(element);
        }

        public static string GetAnecdote()
        {
            FindPath.FindFile(ref pathAccueil);
            string date = DateTime.Now.DayOfYear.ToString();
            int jour = Int32.Parse(date);
            int nbAnecdote = File.ReadLines(pathAccueil).Count() - 1;
            int anecdoteJour = 0;
            if (nbAnecdote > jour)
            {
                anecdoteJour = nbAnecdote % jour;
            }
            else
            {
                anecdoteJour = jour % nbAnecdote;
            }
            string res = "";
            using (StreamReader sr = new StreamReader(pathAccueil))
            {
                for (int i = 0; i <= anecdoteJour; i++)
                {
                    res = sr.ReadLine();
                }
            }
            return res;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            toggle_button.Width = this.ActualHeight / 10;
            toggle_button.Height = this.ActualHeight / 10;
        }

        private void ListViewItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (toggle_button.IsChecked == true)
            {
                tooltip_home.Visibility = Visibility.Collapsed;
                tooltip_profil.Visibility = Visibility.Collapsed;
                tooltip_liste_exercices.Visibility = Visibility.Collapsed;
                tooltip_liste_graphique.Visibility = Visibility.Collapsed;
                tooltip_corps.Visibility = Visibility.Collapsed;
                tooltip_parametres.Visibility = Visibility.Collapsed;
            }
            else
            {
                tooltip_home.Visibility = Visibility.Visible;
                tooltip_profil.Visibility = Visibility.Visible;
                tooltip_liste_exercices.Visibility = Visibility.Visible;
                tooltip_liste_graphique.Visibility = Visibility.Visible;
                tooltip_corps.Visibility = Visibility.Visible;
                tooltip_parametres.Visibility = Visibility.Visible;
            }
        }

        private void FirstStartCommand()
        {
            string prenom = UserProfile.Get_firstName();
            if (prenom == "First name =")
            {
                FirstStartView view = new FirstStartView();
                view.OpenDialog();
            }
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            FirstStartCommand();
        }
    }
}
