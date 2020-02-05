using MahApps.Metro.Controls;
using PrakApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PrakApp.Views
{
    
    /// <summary>
    /// Interaction logic for EditLogItem.xaml
    /// </summary>
    public partial class EditLogItem : MetroWindow
    {

        LogItem LogItem => this.DataContext as LogItem;
        public EditLogItem()
        {
            InitializeComponent();
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveAndCloseClick(object sender, RoutedEventArgs e)
        {
            ViewModel.LogItems.Add(LogItem);
            LogItem.ParkPosition.ParkedVehicle = LogItem?.ParkedVehicle;
            // Do some Save And Test Stuff here
            Close();
        }

    }
}
