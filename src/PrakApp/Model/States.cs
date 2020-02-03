using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PrakApp.Model
{
	public class States : BaseClass
	{
		public States(SqlDataReader reader)
		{
			ID = reader.GetInt("ID");
			code = reader.GetString("code");
			Name = reader.GetString("name");
		}

		private int _ID;
		public int ID
		{
			get { return _ID; }
			set { _ID = value; RaisePropertyChanged(nameof(ID)); }
		}

		private string _code;
		public string code
		{
			get { return _code; }
			set { _code = value; RaisePropertyChanged(nameof(code)); }
		}

		private string _Name;
		public string Name
		{
			get { return _Name; }
			set { _Name = value; RaisePropertyChanged(nameof(Name)); }
		}

		public override string ToString()
		{
			return $"{code} - {Name}";
		}
	}
}
