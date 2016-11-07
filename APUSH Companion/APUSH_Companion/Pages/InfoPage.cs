using System;
using Xamarin.Forms;

namespace APUSH_Companion.Pages
{
    public class InfoPage : ContentPage
    {
        public InfoPage()
        {
            Title = "About";
            Icon = "info.png";

            Padding = new Thickness(0, 20, 0, 100);

            var title = new Label
            {
                Text = "APUSH Companion App",
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            var logo = new Image
            {
                Source = ImageSource.FromFile("IconTransparentLarge.png"),
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 10)
            };

            var me = new Label
            {
                Text = "Created By: Adeem Mawani",
                HorizontalTextAlignment = TextAlignment.Center
            };

            var ver = new Label
            {
                Text = "Version 1.1",
                HorizontalTextAlignment = TextAlignment.Center
            };

            var icons = new Label
            {
                Text = "Icons Designed By Freepik",
                TextColor = Color.Gray,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };

            Content = new StackLayout
            {
                Children = 
                {
                    title, logo, me, ver, icons
                }
            };
        }
    }
}
