using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using PrakApp.Properties;
using System.Diagnostics;

namespace PrakApp.Model
{
    public class Truck : BaseClass
    {

        public Truck()
        {
            Validate();
        }

        public Truck(SqlDataReader reader) : this()
        {
            ID = reader.GetInt("ID");
            Company = ViewModel.Companies.FirstOrDefault(x => x.ID == reader.GetInt("Company", -1));
            DriverName = reader.GetString("DriverName");
            DLicenseState = reader.GetString("DLicenseState");
            TractorNum = reader.GetString("TractorNum");
            TrailerNum = reader.GetString("TrailerNum");
            SealNum = reader.GetString("SealNum");
            RemovedTrailerNum = reader.GetString("RemovedTrailerNum");
            BoxTruck = reader.GetLong("BoxTruck");
            status = reader.GetLong("status");
            TimeArrived = reader.GetDateTime("TimeArrived");
            TimeDeparted = reader.GetNullableDateTime("TimeDeparted");
            Loaded = reader.GetLong("Loaded");
        }

        

        private long _ID;
        public long ID
        {
            get { return _ID; }
            set { _ID = value; RaisePropertyChanged("ID"); }
        }

        private long _Loaded;
        public long Loaded
        {
            get { return _Loaded; }
            set { _Loaded = value; RaisePropertyChanged("Loaded"); }
        }

        // Todo: Replace This wih CompanyItem
        private Company _Company;
        public Company Company
        {
            get { return _Company; }
            set { _Company = value; RaisePropertyChanged("Company"); }
        }

        private string _DriverName;
        public string DriverName
        {
            get { return _DriverName; }
            set { _DriverName = value; RaisePropertyChanged("DriverName"); Validate(); }
        }



        // Todo: Replace this with State
        private string _DLicenseState;
        public string DLicenseState
        {
            get { return _DLicenseState; }
            set { _DLicenseState = value; RaisePropertyChanged("DLicenseState"); }
        }

        private string _TractorNum;
        public string TractorNum
        {
            get { return _TractorNum; }
            set { _TractorNum = value; RaisePropertyChanged("TractorNum"); }
        }


        private string _TrailerNum;
        public string TrailerNum
        {
            get { return _TrailerNum; }
            set { _TrailerNum = value; RaisePropertyChanged("TrailerNum"); }
        }

        private string _SealNum;
        public string SealNum
        {
            get { return _SealNum; }
            set { _SealNum = value; RaisePropertyChanged("SealNum"); Validate(); }
        }


        private string _RemovedTrailerNum;
        public string RemovedTrailerNum
        {
            get { return _RemovedTrailerNum; }
            set { _RemovedTrailerNum = value; RaisePropertyChanged("RemovedTrailerNum"); }
        }


        private long _BoxTruck;
        public long BoxTruck
        {
            get { return _BoxTruck; }
            set { _BoxTruck = value; RaisePropertyChanged("BoxTruck"); }
        }


        private long _status;

        public long status
        {
            get { return _status; }
            set { _status = value; RaisePropertyChanged("status"); }
        }

        private string _notes;
        public string notes
        {
            get { return _notes; }
            set { _notes = value; RaisePropertyChanged("Notes"); }
        }

        private DateTime _TimeArrived;
        public DateTime TimeArrived
        {
            get { return _TimeArrived; }
            set { _TimeArrived = value; RaisePropertyChanged("TimeArrived"); }
        }

        private DateTime? _TimeDeparted;
        public DateTime? TimeDeparted
        {
            get { return _TimeDeparted; }
            set { _TimeDeparted = value; RaisePropertyChanged("TimeDeparted"); }
        }

        public TimeSpan TimeElapsed
        {
            get
            {
                if (TimeDeparted is null)
                {
                    return DateTime.Now.Subtract(TimeArrived);
                }
                else
                {
                    return TimeDeparted?.Subtract(TimeArrived) ?? throw new ArgumentNullException(nameof(TimeDeparted));
                }
            }
        }


        public override string ToString()
        {
            return $"Trailer: {TrailerNum}";
        }
        #region Validation

        private void Validate()
        {
            ClearErrors(nameof(DriverName));
            ClearErrors(nameof(SealNum));
            ClearErrors(nameof(TractorNum));
            // Test if the drivers name is not Empty
            if (string.IsNullOrWhiteSpace(DriverName))
            {
                AddError(nameof(DriverName), "The Driver has no Name!");
            }

           if (string.IsNullOrEmpty(SealNum) || SealNum.Length > 10)
            {
                AddError(nameof(SealNum), "Invalid Seal number.");
            }
            if (string.IsNullOrEmpty(TractorNum) || TractorNum.Length > 10)
            {
                AddError(nameof(TractorNum), "Invalid Trailer number.");
            }
        }

        #endregion

    }
}
