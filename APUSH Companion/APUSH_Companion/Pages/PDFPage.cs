using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace APUSH_Companion.Pages
{
    public class PDFPage : ContentPage
    {
        public PDFPage(string title, string pdf)
        {
            Title = title;
            Icon = "book.png";

            NavigationPage.SetBackButtonTitle(this, "Back");

            Padding = new Thickness(0, 20, 0, 0);
            Content = new Models.CustomWebView
            {
                Uri = pdf,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
        }
    }
}
