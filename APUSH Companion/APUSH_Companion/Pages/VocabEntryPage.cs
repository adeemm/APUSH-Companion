using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace APUSH_Companion.Pages
{
    public class VocabEntryPage : ContentPage
    {
        public VocabEntryPage(string word, string def)
        {
            Title = "";
            Icon = "vocab.png";

            var layout = new StackLayout()
            {
                Padding = new Thickness(5, 10)
            };

            var term = new Label
            {
                Text = word,
                FontSize = 32,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            var meaning = new Label
            {
                Text = def,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(5, 10, 5, 0)
            };

            layout.Children.Add(term);
            layout.Children.Add(meaning);
            Content = layout;
        }
    }
}
