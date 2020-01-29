using PrakApp.Properties;
using PrakApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace PrakApp.Model
{
    public class ViewModel :BaseClass
    {
        public ViewModel()
        {
            AddTruckCommand = new RelayCommand((param) => AddTruckCommand_Execute(param as string), (param) => AddTruckCommand_CanExecute(param as string));
        }

        public static void InitViewModel()
        {
            GetCompanies();
            GetTruckLogs();
            GetParkAndDockItems();
        }

        public static void GetCompanies()
        {
            Companies.Clear();

            using var conn = new SqlConnection(Properties.Settings.Default.ConnectionString);

            conn.Open();
            string qry = "SELECT * FROM Company;";
            var cmd = new SqlCommand(qry, conn);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Companies.Add(new Company(reader));
            }
        }


        public static void GetTruckLogs()
        {
            TruckLog.Clear();

            using var conn = new SqlConnection(Properties.Settings.Default.ConnectionString);

            conn.Open();
            string qry = "SELECT * FROM dbo.TruckLog WHERE status=0;";
            var cmd = new SqlCommand(qry, conn);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                TruckLog.Add(new Truck(reader));
            }
        }

        public static void GetParkAndDockItems()
        {
            ParkItems.Clear();
            DockItems.Clear();

            using var conn = new SqlConnection(Properties.Settings.Default.ConnectionString);

            conn.Open();
            string qry = "SELECT * FROM Parking;";
            var cmd = new SqlCommand(qry, conn);

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var parkItem = new ParkItem(reader);

                // Place item based on Type
                switch (reader["slotType"].ToString())
                {
                    case "P":
                        ParkItems.Add(parkItem);
                        break;
                    case "D":
                        DockItems.Add(parkItem);
                        break;
                    default:
                        break;
                }
            }
        }

        // Let's make these Items static, so we can access them from everywhere
        public static ObservableCollection<ParkItem> ParkItems { get; set; } = new ObservableCollection<ParkItem>();
        public static ObservableCollection<ParkItem> DockItems { get; set; } = new ObservableCollection<ParkItem>();

        public static ObservableCollection<Vehicle> Vehicles { get; set; } = new ObservableCollection<Vehicle>();
        public static ObservableCollection<Truck> TruckLog { get; set; } = new ObservableCollection<Truck>();
        public static ObservableCollection<Company> Companies { get; set; } = new ObservableCollection<Company>();

        public static ObservableCollection<LogItem> LogItems { get; set; } = new ObservableCollection<LogItem>();

        private int _UserAccessLevel = 5;  //Methods.getAccess(user);
        public int UserAccessLevel
        {
            get { return _UserAccessLevel; }
            set { _UserAccessLevel = value; RaisePropertyChanged("UserAccessLevel"); }
        }


        public RelayCommand AddTruckCommand { get; }

        private void AddTruckCommand_Execute(string param)
        {
            if (param == "Domestic" && UserAccessLevel >= 4)
            {
                // Do Stuff for Domestic Truck here
            }
            else if (param == "International" && UserAccessLevel >= 5)
            {
                
            }
            MessageBox.Show($"You Clicked: {param}", "Congratulation");
        }

        private bool AddTruckCommand_CanExecute(string param)
        {
            if (param == "Domestic" && UserAccessLevel >= 4)
            {
                return true;
            }
            else if (param == "International" && UserAccessLevel >= 5)
            {
                return true;
            }
            return false;
        }
    }
}
