using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using GymSharp.MVVM.ViewModel;
using GymSharp.ressources.enums;

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

        public ListeExerciceView(int numMuscle)
        {
            Muscles muscle = (Muscles)numMuscle;
            switch (muscle)
            {
                case Muscles.Ischios:
                case Muscles.Mollets:
                    muscle = Muscles.Quadriceps;
                    break;
            }
            InitializeComponent();
            ListeExerciceViewModel.View = this;
            ListeExerciceViewModel.ChangeInfoAboutMuscle((int)muscle);
            scrollViewerText.MaxHeight = ActualHeight - title.ActualHeight;
        }

        public void ExoChecked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            ListeExerciceViewModel.ChangeInfoAboutMuscle(int.Parse(radio.Name.Replace("_", "")));
            scrollViewerText.MaxHeight = ActualHeight - title.ActualHeight;
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            imageExo.Height = ActualHeight/2.8;
            scrollViewerText.MaxHeight = ActualHeight - title.ActualHeight;
        }

	}
}
