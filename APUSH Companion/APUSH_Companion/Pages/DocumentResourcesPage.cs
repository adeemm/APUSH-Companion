using System;
using Xamarin.Forms;

namespace APUSH_Companion.Pages
{
    public class DocumentResourcesPage : ContentPage
    {
        public DocumentResourcesPage()
        {
            Title = "Document Resources";
            Icon = "book.png";

            NavigationPage.SetBackButtonTitle(this, "Back");

            var table = new TableView()
            {
                Root = new TableRoot
                {
                    new TableSection("AP US History Framework")
                    {
                        new Models.ExtendedTextCell { Text = "Semester One Outline", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Semester 1 Outline", "S1Outline.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Semester Two Outline", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Semester 2 Outline", "S2Outline.pdf"))) }
                    },

                    new TableSection("Review Material")
                    {
                        new Models.ExtendedTextCell { Text = "Collective Outline", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Collective Outline", "collectiveOutline.pdf"))) },
                        //new Models.ExtendedTextCell { Text = "Crash Course 2nd Edition", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Crash Course 2nd Ed", "CrashCourse.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Review Of Presidents", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Presidential Review", "presidents.pdf"))) }
                    },

                    new TableSection("The American Pageant Textbook Outline")
                    {
                        new Models.ExtendedTextCell { Text = "Chapter 1 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 1", "ch1.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 2 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 2", "ch2.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 3 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 3", "ch3.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 4 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 4", "ch4.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 5 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 5", "ch5.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 6 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 6", "ch6.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 7 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 7", "ch7.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 8 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 8", "ch8.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 9 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 9", "ch9.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 10 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 10", "ch10.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 11 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 11", "ch11.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 12 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 12", "ch12.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 13 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 13", "ch13.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 14 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 14", "ch14.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 15 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 15", "ch15.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 16 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 16", "ch16.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 17 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 17", "ch17.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 18 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 18", "ch18.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 19 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 19", "ch19.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 20 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 20", "ch20.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 21 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 21", "ch21.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 22 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 22", "ch22.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 23 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 23", "ch23.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 24 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 24", "ch24.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 25 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 25", "ch25.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 26 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 26", "ch26.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 27 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 27", "ch27.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 28 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 28", "ch28.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 29 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 29", "ch29.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 30 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 30", "ch30.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 31 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 31", "ch31.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 32 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 32", "ch32.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 33 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 33", "ch33.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 34 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 34", "ch34.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 35 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 35", "ch35.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 36 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 36", "ch36.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 37 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 37", "ch37.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 38 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 38", "ch38.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 39 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 39", "ch39.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 40 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 40", "ch40.pdf"))) },
                        new Models.ExtendedTextCell { Text = "Chapter 41 Summary", ShowDisclosure = true, Command = new Command(() => Navigation.PushAsync(new PDFPage("Chapter 41", "ch41.pdf"))) },
                    },
                },
                Intent = TableIntent.Menu
            };

            Content = table;
        }
    }
}
