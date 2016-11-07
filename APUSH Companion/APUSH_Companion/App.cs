using System;
using Xamarin.Forms;

namespace APUSH_Companion
{
    public class App
    {
#if __IOS__
        public static RevmobAds.RevMobBanner iOSbanner;    
        public static RevmobAds.RevMobFullscreen iOSfullscreen;
        public static bool isiOSVideoReady = false;           
#endif

        public static int deviceWidth;
        public static int deviceHeight;

        public static Page GetMainPage()
        {
            return new RootPage();
        }
    }
}