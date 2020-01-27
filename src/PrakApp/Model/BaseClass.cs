using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PrakApp.Model
{
    public class BaseClass : INotifyPropertyChanged
    {
        // This event tells the UI to update 
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
