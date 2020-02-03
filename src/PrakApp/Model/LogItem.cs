using System;
using System.Collections.Generic;
using System.Text;

namespace PrakApp.Model
{
	public class LogItem :BaseClass
	{

		private DateTime _LogTime;
		public DateTime LogTime
		{
			get { return _LogTime; }
			set { _LogTime = value; RaisePropertyChanged("LogTime"); }
		}

		private TimeSpan _ElapsedTime;
		public TimeSpan ElapsedTime
		{
			get { return _ElapsedTime; }
			set { _ElapsedTime = value; RaisePropertyChanged("ElapsedTime"); }
		}

		private bool _IsPark;
		public bool IsPark
		{
			get { return _IsPark; }
			set 
			{ 
				_IsPark = value; RaisePropertyChanged("IsPark");
				// Do not allow Park and Dock
				if (value == true) IsDock = false;
			}
		}

		private bool _IsDock;
		public bool IsDock
		{
			get { return _IsDock; }
			set 
			{ 
				_IsDock = value; 
				RaisePropertyChanged("IsDock"); 
				// Do not allow Park and Dock
				if (value == true) IsPark = false; 
			}
		}

		private bool _IsLoaded;
		public bool IsLoaded
		{
			get { return _IsLoaded; }
			set
			{
				_IsLoaded = value; RaisePropertyChanged("Loaded");
				// Do not allow Load and unloaded
				if (value == true) IsLoaded = false;
			}
		}

		private bool _IsUnloaded;
		public bool IsUnloaded
		{
			get { return _IsUnloaded; }
			set
			{
				_IsUnloaded = value;
				RaisePropertyChanged("IsUnloaded");
				// Do not allow load and Unloaded
				if (value == true) IsUnloaded = false;
			}
		}

		private ParkItem _ParkPosition;
		public ParkItem ParkPosition
		{
			get { return _ParkPosition; }
			set { _ParkPosition = value; RaisePropertyChanged("ParkPosition"); }
		}

		public Truck _ParkedVehicle;

		public Truck ParkedVehicle
		{
			get { return _ParkedVehicle; }
			set { _ParkedVehicle = value; RaisePropertyChanged("ParkedVehicle"); }
		}


	}
}
