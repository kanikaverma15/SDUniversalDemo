using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SDUniversalDemo.Model
{
    public class BaseDataModel : INotifyPropertyChanged
    {
        public BaseDataModel() { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { PropertyChanged += value; }
            remove { PropertyChanged -= value; }
        }
    }
}
