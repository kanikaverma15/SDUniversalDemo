using SDUniversalDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SDUniversalDemo.Common.NavigationHelper
{
    public class NavigationService
    {
        public Frame _mainFrame = Window.Current.Content as Frame;

        private NavigationService() { }

        private static NavigationService _navigationServiceInstance;
        public static NavigationService NavigationServiceInstance
        {
            get
            {
                if (_navigationServiceInstance == null)
                {
                    _navigationServiceInstance = new NavigationService();
                }
                return _navigationServiceInstance;
            }
        }

        public void Navigate(Type type)
        {
            _mainFrame.Navigate(type);

            var page = (Page)_mainFrame.Content;
            if (page.DataContext != null)
            {
                ((BaseViewModel)page.DataContext).Init();
            }
        }

        public void Navigate(Type type, params object[] parameter)
        {
            _mainFrame.Navigate(type, parameter);
            var page = (Page)_mainFrame.Content;
            if (page.DataContext != null)
            {
                ((BaseViewModel)page.DataContext).Init(parameter);
            }
        }

        public void Navigate(string type, params object[] parameter)
        {
            _mainFrame.Navigate(Type.GetType(type), parameter);

            var page = (Page)_mainFrame.Content;
            if (page.DataContext != null)
            {
                ((BaseViewModel)page.DataContext).Init(parameter);
            }
        }
        public void Navigate(Type PageName, string parameter)
        {
            _mainFrame.Navigate(PageName, parameter);
            //var page = (Page)_mainFrame.Content;
            //if (page.DataContext != null)
            //{
            //    ((BaseViewModel)page.DataContext).Init(parameter);
            //}
        }
        public void Navigate(string type)
        {
            _mainFrame.Navigate(Type.GetType(type));

            var page = (Page)_mainFrame.Content;
            if (page.DataContext != null)
            {
                ((BaseViewModel)page.DataContext).Init();
            }
        }

        public void GoBack()
        {
            if (_mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
        }

        public void GoForward()
        {
            if (_mainFrame.CanGoForward)
            {
                _mainFrame.GoForward();
            }
        }
    }
}
