using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Windows.Graphics.Display;
using Windows.UI.Xaml;

namespace SDUniversalDemo.ViewModel
{
    public class SplashScreenViewModel : BaseViewModel
    {
        public override void Init(params object[] args)
        {
            base.Init(args);
        }
        private void sizeOfImage()
        {

            //double scaleFactor = Windows.Graphics.Display.DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
        }
    }
}
