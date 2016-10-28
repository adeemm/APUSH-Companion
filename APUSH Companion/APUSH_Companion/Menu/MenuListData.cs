using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace APUSH_Companion
{
    public class MenuListData : List<MenuItem>
    {
        public MenuListData()
        {
            this.Add(new MenuItem()
            {
                Title = "Home",
                IconSource = "home.png",
                TargetType = typeof(Pages.AboutPage),
            });

            this.Add(new MenuItem()
            {
                Title = "Document Resources",
                IconSource = "book.png",
                TargetType = typeof(Pages.DocumentResourcesPage),
            });

            this.Add(new MenuItem()
            {
                Title = "Vocabulary & ID's",
                IconSource = "vocab.png",
                TargetType = typeof(Pages.VocabPage),
            });

            this.Add(new MenuItem()
            {
                Title = "Video Resources",
                IconSource = "video.png",
                TargetType = typeof(Pages.VideoPage),
            });

            this.Add(new MenuItem()
            {
                Title = "About Page",
                IconSource = "info.png",
                TargetType = typeof(Pages.InfoPage),
            });
        }
    }
}
