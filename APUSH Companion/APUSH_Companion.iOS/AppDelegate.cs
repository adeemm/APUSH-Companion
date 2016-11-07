using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
using RevmobAds;
using CoreGraphics;

namespace APUSH_Companion.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

            window = new UIWindow(UIScreen.MainScreen.Bounds);

            window.RootViewController = App.GetMainPage().CreateViewController();
            window.MakeKeyAndVisible();

            Action<NSError> actionError = revmobSessionDidNotStartWithError;
            Action action = revmobSessionDidStart;
            RevMobAds.StartSessionWithAppID("580bcf18751f5a7d14492dbc", action, actionError);

            App.deviceWidth = (int)UIScreen.MainScreen.Bounds.Width;
            App.deviceHeight = (int)UIScreen.MainScreen.Bounds.Height;

            return true;
        }

        public void revmobSessionDidStart()
        {
            if (RevMobAds.Session != null)
            {
                App.iOSbanner = RevMobAds.Session.Banner;
                App.iOSbanner.WeakDelegate = this;
                App.iOSbanner.Frame = new CGRect(0, (UIScreen.MainScreen.Bounds.GetMaxY() - 50), UIScreen.MainScreen.Bounds.Width, 50);
                App.iOSbanner.LoadAd();
                App.iOSbanner.ShowAd();

                loadVideoAdd();
            }
        }

        public void revmobSessionDidNotStartWithError(NSError a)
        {
            Console.WriteLine(a.ToString());
        }

        [Export("revmobVideoDidLoad:")]
        public void revmobVideoDidLoad(String placementId)
        {
            App.isiOSVideoReady = true;
        }

        [Export("revmobVideoDidFinish:")]
        public void revmobVideoDidFinish(String placementId)
        {
            loadVideoAdd();
        }

        public static void loadVideoAdd()
        {
            App.isiOSVideoReady = false;
            App.iOSfullscreen = null;
            App.iOSfullscreen = RevMobAds.Session.Fullscreen;
            App.iOSfullscreen.WeakDelegate = (AppDelegate)UIApplication.SharedApplication.Delegate;
            App.iOSfullscreen.LoadVideo();
        }
    }
}