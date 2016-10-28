using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace APUSH_Companion.Pages
{
    public class VideoPage : ContentPage
    {
        public VideoPage()
        {
            Title = "Video Resources";
            Icon = "video.png";

            NavigationPage.SetBackButtonTitle(this, "Back");

            var crashcourse = new Image()
            {
                Source = ImageSource.FromFile("crashCourse.jpg"),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var adamnorris = new Image()
            {
                Source = ImageSource.FromFile("adamNorris.jpg"),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var jcoz = new Image()
            {
                Source = ImageSource.FromFile("jocz.jpg"),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var khan = new Image()
            {
                Source = ImageSource.FromFile("khan.jpg"),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var gilderlehrman = new Image()
            {
                Source = ImageSource.FromFile("gilderlehrman.jpg"),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var tomrichey = new Image()
            {
                Source = ImageSource.FromFile("tomRichey.jpg"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            var ccTapped = new TapGestureRecognizer();
            ccTapped.Tapped += (sender, e) => { Navigation.PushAsync(new BrowserPage("https://www.youtube.com/playlist?list=PL8dPuuaLjXtMwmepBjTSG593eG7ObzO7s", "Crash Course")); };

            var anTapped = new TapGestureRecognizer();
            anTapped.Tapped += (sender, e) => { Navigation.PushAsync(new BrowserPage("https://www.youtube.com/channel/UC223Rd7yCfDo9fv6ENdNp9Q/videos", "Adam Norris")); };

            var jcozTapped = new TapGestureRecognizer();
            jcozTapped.Tapped += (sender, e) => { Navigation.PushAsync(new BrowserPage("https://www.youtube.com/user/JoczProductions/videos?sort=p", "JoczProductions")); };

            var khanTapped = new TapGestureRecognizer();
            khanTapped.Tapped += (sender, e) => { Navigation.PushAsync(new BrowserPage("https://www.khanacademy.org/humanities/us-history", "Khan Academy")); };

            var glTapped = new TapGestureRecognizer();
            glTapped.Tapped += (sender, e) => { Navigation.PushAsync(new BrowserPage("https://ap.gilderlehrman.org/", "Gilder Lehrman")); };

            var trTapped = new TapGestureRecognizer();
            trTapped.Tapped += (sender, e) => { Navigation.PushAsync(new BrowserPage("https://www.youtube.com/playlist?list=PLfzs_X6OQBOy2rs4mrV2O9t3vNB4RF_Es", "Tom Richey")); };

            crashcourse.GestureRecognizers.Add(ccTapped);
            adamnorris.GestureRecognizers.Add(anTapped);
            jcoz.GestureRecognizers.Add(jcozTapped);
            khan.GestureRecognizers.Add(khanTapped);
            gilderlehrman.GestureRecognizers.Add(glTapped);
            tomrichey.GestureRecognizers.Add(trTapped);

            StackLayout layout = new StackLayout { Children = { crashcourse, new Image { Source = ImageSource.FromFile("divider.png") }, adamnorris, new Image { Source = ImageSource.FromFile("divider.png") }, jcoz, new Image { Source = ImageSource.FromFile("divider.png") }, khan, new Image { Source = ImageSource.FromFile("divider.png") }, gilderlehrman, new Image { Source = ImageSource.FromFile("divider.png") } } };

            /*if (App.deviceHeight > 1140)
                layout.Children.Add(tomrichey);       TODO
            */

            Content = layout;
        }
    }
}
