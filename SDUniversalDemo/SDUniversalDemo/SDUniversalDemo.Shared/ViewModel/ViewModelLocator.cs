using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SDUniversalDemo.ViewModel
{
    public class ViewModelLocator
    {
        private static Dictionary<string, BaseViewModel> _vmStore = new Dictionary<string, BaseViewModel>();
        private static T GetViewModelFromDictionary<T>(string guid = null)
        {
            if (guid == null)
            {
                return _vmStore.Values.OfType<T>().FirstOrDefault();
            }
            else
            {
                return _vmStore.Values.OfType<T>().Where((p) => (p as BaseViewModel).Guid.ToString().Equals(guid)).FirstOrDefault();
            }
        }

        public BaseViewModel BaseVM
        {
            get
            {
                var value = GetViewModelFromDictionary<BaseViewModel>();
                if (value == null)
                {
                    value = new BaseViewModel();
                    _vmStore.Add(Guid.NewGuid().ToString(), value);
                }
                return value;
            }
        }

        public HomePageViewModel HomePageVM
        {
            get
            {
                var value = GetViewModelFromDictionary<HomePageViewModel>();
                if (value == null)
                {
                    value = new HomePageViewModel();
                    _vmStore.Add(Guid.NewGuid().ToString(), value);
                }
                return value;
            }
        }

        public SplashScreenViewModel SplashVM
        {
            get
            {
                var value = GetViewModelFromDictionary<SplashScreenViewModel>();
                if (value == null)
                {
                    value = new SplashScreenViewModel();
                    _vmStore.Add(Guid.NewGuid().ToString(), value);
                }
                return value;
            }
        }

    }
}
