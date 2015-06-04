using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;

namespace SDUniversalDemo.Common.TemplateSelector.HomeTemplateSelector
{
    public class HomePivotTemplateSelector : TemplateSelector
    {
        public DataTemplate Home
        {
            get;
            set;
        }
        public DataTemplate Categories
        {
            get;
            set;
        }
        public DataTemplate RecentlyViewed
        {
            get;
            set;
        }
        public DataTemplate MyAccount
        {
            get;
            set;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //if (item is HomeSegmentDataModel)
            //{
            //    return Home;
            //}
            //else if (item is ObservableCollection<NavigationMenuDataModel>)
            //{
            //    return Categories;
            //}
            //else if (item is NavigationMenuFooterDataModel)
            //{
            //    return MyAccount;
            //}

            return base.SelectTemplate(item, container);
        }
    }
}
