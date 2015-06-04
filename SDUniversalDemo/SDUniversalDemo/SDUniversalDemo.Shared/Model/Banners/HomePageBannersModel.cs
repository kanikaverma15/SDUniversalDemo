using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace SDUniversalDemo.Model.Banners
{
    public class HomePageBannersModel : BaseDataModel
    {
        public bool successful { get; set; }
        public ObservableCollection<Banner> banners { get; set; }
    }
    public class Banner : BaseDataModel
    {
        public long id { get; set; }
        public string imagePath { get; set; }
        public string pageUrl { get; set; }
        public string modPageUrl { get; set; }
        public ObservableCollection<string> cityPageUrl { get; set; }
        public string type { get; set; }
        public string dealCat { get; set; }
        public string altText { get; set; }
        public string legend { get; set; }
        public string newsletterSubject { get; set; }
        public ObservableCollection<string> linksInsideImageArr { get; set; }
        public long priority { get; set; }
        public long startDate { get; set; }
        public long endDate { get; set; }
        public long created { get; set; }
        public long updated { get; set; }

         #region Banner Images
        public Banner()
        {
        }
        public Banner(string name)
        {
            PanImages = name;
        }
        public string PanImages { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj != null) && (obj.GetType() == typeof(HubSection)))
            {
                var thePanoItem = (HubSection)obj;

                return base.Equals(thePanoItem.Header);
            }
            else
            {
                return base.Equals(obj);
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
