using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GymSharp
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Uri startupUri;

        public App()
        {
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private void LookForFirstStart(object sender, StartupEventArgs e)
        {
            
        }
    }
}
