using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace APUSH_Companion.Models
{
    public class ExtendedTextCell : TextCell
    {
        public static readonly BindableProperty ShowDisclosureProperty = BindableProperty.Create<ExtendedTextCell, bool>(p => p.ShowDisclosure, default(bool));

        public bool ShowDisclosure
        {
            get { return (bool)GetValue(ShowDisclosureProperty); }
            set { SetValue(ShowDisclosureProperty, value); }
        }
    }
}
