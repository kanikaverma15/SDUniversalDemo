using SDUniversalDemo.API;
using SDUniversalDemo.Common;
using SDUniversalDemo.Model;
using SDUniversalDemo.Model.Banners;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Windows.Graphics.Display;
using Windows.UI.Xaml;

namespace SDUniversalDemo.ViewModel
{
    public class SplashScreenViewModel : BaseViewModel
    {
        private DispatcherTimer quickTimer;
        private DispatcherTimer delayedTimer;
        private bool dataLoaded = false;

        public SplashScreenViewModel()
        {
            this.startTimers();
        }
        private void startTimers()
        {
            if (this.quickTimer == null)
            {
                this.quickTimer = new DispatcherTimer();
                this.quickTimer.Interval = TimeSpan.FromSeconds(3);
                this.quickTimer.Start();
                this.quickTimer.Tick+=quickTimer_Tick;
            }
            FecthBannersData();
            FetchProductFeed();
            //if (this.delayedTimer == null)
            //{
            //    this.delayedTimer = new DispatcherTimer();
               
            //        this.delayedTimer.Interval = TimeSpan.FromSeconds(5);


            //        this.delayedTimer.Tick+=delayedTimer_Tick;
            //}


        }

        private void quickTimer_Tick(object sender, object e)
        {
            if (quickTimer != null)
            {
                quickTimer.Stop();
                //if (dataLoaded)
                {
                    if (delayedTimer != null)
                    {
                        delayedTimer.Stop();
                    }

                    delayedTimer = null;
                    quickTimer = null;
                    DoNavigation();
                }
            }
        }

        private void delayedTimer_Tick(object sender, object e)
        {
            if (delayedTimer != null)
            {
                if (quickTimer != null)
                {
                    quickTimer.Stop();
                }

                quickTimer = null;
                delayedTimer.Stop();
                DoNavigation();
            }
        }

        private void DoNavigation()
        {
            SDUniversalDemo.Common.NavigationHelper.NavigationService.NavigationServiceInstance.Navigate("SDUniversalDemo.Views.HomeView.HomePageView");
        }
        public override void Init(params object[] args)
        {
            base.Init(args);
        }
        private void sizeOfImage()
        {
            //double scaleFactor = Windows.Graphics.Display.DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
        }
        #region Network Calls
        private async void FecthBannersData()
        {
            var response = await API.BaseAPI.GetAsync(APIFactory.BASE_URL + "/service/get/widget/getBanners" + "?" +
               "responseProtocol=PROTOCOL_JSON&requestProtocol=PROTOCOL_JSON&start=0&noOfBanners=300&apiKey=snapdeal");

            try
            {
                var obj = JsonParser.ObjectDeserializer<HomePageBannersModel>(response);
                if (obj != null)
                {
                    GlobalVariables.BannerData = new ObservableCollection<object>();
                    foreach (var item in obj.banners)
                    {
                        if (item.priority == 1)
                        {
                            GlobalVariables.BannerData.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private async void FetchProductFeed()
        {
            var response = await API.BaseAPI.GetAsync(APIFactory.BASE_URL + "/service/get/home/getHomePageStructure" + "?" +
               "responseProtocol=PROTOCOL_JSON&requestProtocol=PROTOCOL_JSON&bucketId=-1");

            try
            {
                var obj = JsonParser.ObjectDeserializer<HomePageStructureModel>(response);
                if (obj != null)
                {
                    GlobalVariables.HomePageBucket = obj.buckets;
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
