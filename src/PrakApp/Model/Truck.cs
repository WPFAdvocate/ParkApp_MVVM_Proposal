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
            DLicenseNum = reader.GetString("DLicenseNum");
            ContainerNum = reader.GetString("ContainerNum");
            DLicenseState = reader.GetString("DLicenseState");
            TractorNum = reader.GetString("TractorNum");
            TrailerNum = reader.GetString("TrailerNum");
            SealNum = reader.GetString("SealNum");
            RemovedTrailerNum = reader.GetString("RemovedTrailerNum");
            BoxTruck = reader.GetBool("BoxTruck", false);
            status = reader.GetString("status");
            TimeArrived = reader.GetDateTime("TimeArrived");
            TimeDeparted = reader.GetNullableDateTime("TimeDeparted");
        }

        private long _ID;
        public long ID
        {
            get { return _ID; }
            set { _ID = value; RaisePropertyChanged("ID"); }
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


        private string _DLicenseNum;
        public string DLicenseNum
        {
            get { return _DLicenseNum; }
            set { _DLicenseNum = value; RaisePropertyChanged("DLicenseNum"); }
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
            set { _SealNum = value; RaisePropertyChanged("SealNum"); }
        }


        private string _RemovedTrailerNum;
        public string RemovedTrailerNum
        {
            get { return _RemovedTrailerNum; }
            set { _RemovedTrailerNum = value; RaisePropertyChanged("RemovedTrailerNum"); }
        }


        private bool _BoxTruck;
        public bool BoxTruck
        {
            get { return _BoxTruck; }
            set { _BoxTruck = value; RaisePropertyChanged("BoxTruck"); }
        }


        private string _status;

        public string status
        {
            get { return _status; }
            set { _status = value; RaisePropertyChanged("status"); }
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


        private string _ContainerNum;
        public string ContainerNum
        {
            get { return _ContainerNum; }
            set { _ContainerNum = value; RaisePropertyChanged("ContainerNum"); Validate(); }
        }

        public override string ToString()
        {
            return $"Trailer: {TrailerNum}";
        }
        #region Validation

        private void Validate()
        {
            ClearErrors(nameof(DriverName));
            ClearErrors(nameof(ContainerNum));
            // Test if the drivers name is not Empty
            if (string.IsNullOrWhiteSpace(DriverName))
            {
                AddError(nameof(DriverName), "The Driver has no Name?!");
            }
        }

        #endregion

    }
}
