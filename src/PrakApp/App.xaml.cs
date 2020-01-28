using PrakApp.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PrakApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Settings.Default.Save();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Settings.Default.PropertyChanged += Settings_PropertyChanged;
        }

        private void Settings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "ConnectionString":
                    Init_ViewModel();
                    break;
                default:
                    break;
            }
        }


        private void Init_ViewModel()
        {
            PrakApp.Model.ViewModel.GetParkAndDockItems();
        }

    }
}
