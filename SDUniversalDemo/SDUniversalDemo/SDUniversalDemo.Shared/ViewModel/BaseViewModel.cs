using SDUniversalDemo.Common.NavigationHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace SDUniversalDemo.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {
            Guid = Guid.NewGuid();
        }

        public virtual void Init(params object[] args)
        { }

        public Guid Guid
        {
            get;
            set;
        }


        #region navigation methods
        public void SendPageNavigationRequest(string uri, params object[] args)
        {
            NavigationService.NavigationServiceInstance.Navigate(uri, args);
        }
        public void SendPageNavigationRequest(Type uri, string args)
        {
            NavigationService.NavigationServiceInstance.Navigate(uri, args);
        }
        public void SendBackNavigationRequest()
        {
            NavigationService.NavigationServiceInstance.GoBack();
        }
        #endregion

        #region UI notification methods
        public void NotifyPropertyChanged(string propertyName)
        {
            try
            {
                if (PropertyChanged != null)
                {
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    //UpdateOnDispatcher(() =>
                    //{
                    //    if (PropertyChanged != null)
                    //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    //});
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { PropertyChanged += value; }
            remove { PropertyChanged -= value; }
        }
        #endregion

        public void UpdateOnDispatcher(Action callback)
        {
            if (Windows.UI.Xaml.Window.Current.Dispatcher.HasThreadAccess)
            {
                callback();
            }
            else
            {
                Task.Run(async () =>
                {
                    await Windows.UI.Xaml.Window.Current.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        callback();
                    });
                });
            }
        }
    }
}
