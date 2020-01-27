using System;
using System.Collections.Generic;
using System.Text;

namespace PrakApp.Model
{
    public class Vehicle : BaseClass
    {

		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; RaisePropertyChanged("ID"); }
		}

		private string _RegistrationCode;
		public string RegistrationCode
		{
			get { return _RegistrationCode; }
			set { _RegistrationCode = value; RaisePropertyChanged("RegistrationCode"); }
		}


		private string _Name;
		public string Name
		{
			get { return _Name; }
			set { _Name = value; RaisePropertyChanged("Name"); }
		}

		public override string ToString()
		{
			return $"{ID.ToString("00")}: {RegistrationCode} ({Name})";
		}
	}
}
