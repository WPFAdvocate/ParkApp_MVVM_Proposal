using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PrakApp.Model
{
	public class Company : BaseClass
	{
		public Company(SqlDataReader reader)
		{
			ID = reader.GetInt("ID");
			Name = reader.GetString("Company");
		}

		private int _ID;
		public int ID
		{
			get { return _ID; }
			set { _ID = value; RaisePropertyChanged(nameof(ID)); }
		}

		private string _Name;
		public string Name
		{
			get { return _Name; }
			set { _Name = value; RaisePropertyChanged(nameof(Name)); }
		}

		public override string ToString()
		{
			return $"{Name}";
		}
	}
}