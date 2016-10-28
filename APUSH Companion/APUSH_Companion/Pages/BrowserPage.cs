using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace APUSH_Companion.Pages
{
    public class BrowserPage : ContentPage
    {
        public BrowserPage(string url, string title)
        {
            Title = title;
            Icon = "video.png";

            var browser = new WebView()
            {
                Source = url
            };

#if __IOS__
            if(App.isiOSVideoReady)
            {
                App.iOSfullscreen.ShowVideo();          
            }        
#endif

            Content = browser;
        }
    }
}
