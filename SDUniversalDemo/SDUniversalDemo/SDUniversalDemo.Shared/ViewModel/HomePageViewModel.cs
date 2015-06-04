using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SDUniversalDemo.Common;
using SDUniversalDemo.Model;
using SDUniversalDemo.Model.Banners;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace SDUniversalDemo.ViewModel
{
    public class HomePageViewModel : BaseViewModel
    {
        public override void Init(params object[] args)
        {
            base.Init(args);
            GetBannersData();
        }

        private Bucket _bucketData;
        public Bucket BucketData
        {
            get { return _bucketData; }
            set
            {
                _bucketData = value;
                NotifyPropertyChanged("BucketData");
            }
        }
        #region HomeBanners
        private ObservableCollection<object> _banners;
        public ObservableCollection<object> Banners { 
            get { return _banners; }
            set
            {
                _banners = value;
                NotifyPropertyChanged("Banners");
            }
        }


        private int _panoramaItemIndex;
        public int PanoramaItemIndex
        {
            get { return _panoramaItemIndex; }
            set
            {

                _panoramaItemIndex = value;
                if (PanoramaItemIndex >= 0)
                {
                    SelectedItem = (Banner)Banners[PanoramaItemIndex];
                    SelectedItemIndex = PanoramaItemIndex;
                    CircleBinding = null;
                    CircleBinding = new ObservableCollection<string>();
                    for (SelectedItemIndex = 0; SelectedItemIndex <= Banners.Count - 1; SelectedItemIndex++)
                    {

                        if (SelectedItemIndex == value)
                        {
                            //CircleBinding[SelectedItemIndex] = "/Assets/SelectedItem.png";
                            CircleBinding.Add("/Assets/Banner/SelectedItem.png");
                        }
                        //else
                        //{
                        //    CircleBinding[SelectedItemIndex] = "/Assets/NonSelectedItem.png";
                        //}
                        else
                        {
                            CircleBinding.Add("/Assets/Banner/NonSelectedItem.png");
                        }
                    }
                }
                NotifyPropertyChanged("PanoramaItemIndex");
            }
        }

        private int _selectedItemIndex;
        public int SelectedItemIndex
        {
            get { return _selectedItemIndex; }
            set
            {
                _selectedItemIndex = value;
                NotifyPropertyChanged("SelectedItemIndex");
            }
        }

        private Banner _selectedItem;
        public Banner SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<string> _circleBinding;
        public ObservableCollection<string> CircleBinding
        {
            get
            {
                return _circleBinding;
            }
            set
            {
                _circleBinding = value;
                NotifyPropertyChanged("CircleBinding");
            }
        }

        private void DefaultCircle()
        {
            CircleBinding = new ObservableCollection<string>();
            if (Banners != null)
            {
                for (int i = 0; i < Banners.Count; i++)
                {
                    if (i == 0)
                    {
                        CircleBinding.Add("/Assets/Banner/SelectedItem.png");
                    }
                    else
                    {
                        CircleBinding.Add("/Assets/Banner/NonSelectedItem.png");
                    }
                }
            }
        }
        #endregion

        #region COMMANDS
        private ICommand _homeItemTapCommand;
        public ICommand HomeItemTapCommand
        {
            get
            {
                if (_homeItemTapCommand == null)
                {
                    _homeItemTapCommand = new DelegateCommand<Banner>((param) =>
                    {
                        if (param.pageUrl.Contains("app-page"))
                        {
                            //SendPageNavigationRequest(Constants.PAGE_URI_WEB_BROWSER, param.href);
                        }
                        else
                        {
                            //SendPageNavigationRequest(Constants.PAGE_URI_TOP_PRODUCTS, param.href);
                        }
                    });
                }

                return _homeItemTapCommand;
            }
        }
        private ICommand _flipViewSelectionChangedCommand;
        public ICommand FipViewSelectionChangedCommand
        {
            get
            {
                if (_flipViewSelectionChangedCommand == null)
                {
                    _flipViewSelectionChangedCommand = new DelegateCommand<int>((param) =>
                    {
                        PanoramaItemIndex = param;
                    });
                }
                return _flipViewSelectionChangedCommand;
            }
        }
        #endregion

        #region GET DATA
       private void GetBannersData()
       {
           Banners = GlobalVariables.BannerData;
           BucketData = GlobalVariables.HomePageBucket;
           DefaultCircle();
       }
        #endregion
    }
}
