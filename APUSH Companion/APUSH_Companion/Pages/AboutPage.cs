using System;
using Xamarin.Forms;

namespace APUSH_Companion.Pages
{
    public class AboutPage : ContentPage
    {
        public AboutPage()
        {
            Title = "Home";
            Icon = "home.png";

            Padding = new Thickness(0, 20);

            var title = new Label
            {
                Text = "Welcome To The \nAPUSH Companion App",
                HorizontalTextAlignment = TextAlignment.Center,
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Margin = new Thickness(0, 20)
            };

            var logo = new Image
            {
                Source = ImageSource.FromFile("Icon-Transparent-Large.png"),
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 0, 0, 20)
            };

            var info = new Label
            {
                Text = "✓ 1500+ Vocab & ID's \n\n✓ 41 Chapter Summaries \n\n✓ Helpful Review Videos \n\n✓ Outlines & Documents",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.FromRgb(64, 64, 64)
            };

            Content = new StackLayout{ Children = { title, logo, info } };
        }
    }
}
