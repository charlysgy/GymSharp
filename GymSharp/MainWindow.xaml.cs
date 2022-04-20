using System;
using System.Windows;
using GymSharp.MVVM.View;
using System.IO;
using GymSharp.ressources.enums;
using System.Linq;

namespace GymSharp
{
    public partial class MainWindow : Window
    {
        private const string Path = "../../ressources/text/messages_accueil.txt";

        public MainWindow()
        {
            InitializeComponent();
            Anecdote.Text = GetAnecdote();
            toggle_button.Width = this.Height/10;
            toggle_button.Height = this.Height/10;
        }

        private void HomeCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
        }

        private void ExercicesCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new ListeExerciceView();
            viewContainer.Children.Add(element);
        }

        private void ParametreCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new parametres();
            viewContainer.Children.Add(element);
        }

        private void GraphiqueCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new RepRMChartView();
            viewContainer.Children.Add(element);
        }

        private void ModelCommand(object sender, RoutedEventArgs e)
        {
            viewContainer.Children.Clear();
            UIElement element = new _3DView();
            viewContainer.Children.Add(element);
        }

        public static string GetAnecdote()
        {
            string date = DateTime.Now.DayOfYear.ToString();
            int jour = Int32.Parse(date);
            int nbAnecdote = File.ReadLines(Path).Count() - 1;
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
            using (StreamReader sr = new StreamReader(Path))
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
    }
}
