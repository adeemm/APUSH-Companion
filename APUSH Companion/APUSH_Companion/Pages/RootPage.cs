using System;
using Xamarin.Forms;

namespace APUSH_Companion
{
    public class RootPage : MasterDetailPage
    {
        MenuPage menuPage;

        public RootPage()
        {
            menuPage = new MenuPage();

            menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);

            Master = menuPage;
            Detail = new NavigationPage(new Pages.AboutPage());

            NavigationPage navDocRes = new NavigationPage(new Pages.DocumentResourcesPage());
            NavigationPage navVocab = new NavigationPage(new Pages.VocabPage());
            NavigationPage navVideo = new NavigationPage(new Pages.VideoPage());
        }

        void NavigateTo(MenuItem menu)
        {
            if (menu == null)
                return;

            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);

            Detail = new NavigationPage(displayPage);

            menuPage.Menu.SelectedItem = null;
            IsPresented = false;
        }
    }
}
