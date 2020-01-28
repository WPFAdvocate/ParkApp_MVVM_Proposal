using PrakApp.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace PrakApp.Model
{
	public class ParkItem : BaseClass
	{


public ParkItem(SqlDataReader reader)
{
	ID = reader.GetInt("Number");
	Number = reader.GetInt("Number");
	Name = reader.GetString("Name");
	ParkedVehicle = ViewModel.Vehicles.FirstOrDefault(x => x.Number == reader.GetLong("ParkedVehicle", -1));
			
}

		private long _ID;
		public long ID
		{
			get { return _ID; }
			set { _ID = value; RaisePropertyChanged("ID"); }
		}

		private int _Number;
		public int Number
		{
			get { return _Number; }
			set { _Number = value; RaisePropertyChanged("Number"); }
		}


		private string _Name;
		public string Name
		{
			get { return _Name; }
			set { _Name = value; RaisePropertyChanged("Name"); }
		}


		private Vehicle _ParkedVehicle;
		public Vehicle ParkedVehicle
		{
			get { return _ParkedVehicle; }
			set { _ParkedVehicle = value; RaisePropertyChanged("ParkedVehicle"); RaisePropertyChanged("IsFree"); }
		}

		// This Property changes the view everytime ParkedVehicle changed
		public bool IsFree => ParkedVehicle is null;


		// Add a Command to insert a new Log event
		public RelayCommand Park_Command { get; } = new RelayCommand((param) =>
		{
			if (param is ParkItem parkItem)
			{
				var newLogItem = new LogItem()
				{
					ParkPosition = parkItem,
					ElapsedTime = new TimeSpan(1, 20, 30),
					LogTime = DateTime.Now,
					IsPark = true
				};

				var dlg = new EditLogItem() { DataContext = newLogItem };
				
				dlg.ShowDialog();
			}
		});

		public RelayCommand Dock_Command { get; } = new RelayCommand((param) =>
		{
			if (param is ParkItem parkItem)
			{
				var newLogItem = new LogItem()
				{
					ParkPosition = parkItem,
					ElapsedTime = new TimeSpan(1, 20, 30),
					LogTime = DateTime.Now,
					IsDock = true
				};

				var dlg = new EditLogItem() { DataContext = newLogItem };

				dlg.ShowDialog();
			}
		});


		public override string ToString()
		{
			return $"{Number.ToString("00")}: {Name}";
		}

	}
}
