using PrakApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrakApp.Model
{
	public class ParkItem : BaseClass
	{

		private int _ID;
		public int ID
		{
			get { return _ID; }
			set { _ID = value; RaisePropertyChanged("ID"); }
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
			return $"{ID.ToString("00")}: {Name}";
		}

	}
}
