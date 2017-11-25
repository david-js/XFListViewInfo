using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListInfoDemo
{
    public class MyListView : ListView
    {
        public const string NoPreviousScroll = "None";
        public const string ScrollToStart = "Towards start";
        public const string ScrollToEnd = "Towards end";

        public static readonly BindableProperty LastScrollDirectionProperty =
            BindableProperty.Create(nameof(LastScrollDirection), typeof(string), typeof(MyListView), null);
        public static readonly BindableProperty AtStartOfListProperty =
            BindableProperty.Create(nameof(AtStartOfList), typeof(bool), typeof(MyListView), false);

        public string LastScrollDirection
        {
            get { return (string)GetValue(LastScrollDirectionProperty); }
            set { SetValue(LastScrollDirectionProperty, value); }
        }

        public bool AtStartOfList
        {
            get { return (bool)GetValue(AtStartOfListProperty); }
            set { SetValue(AtStartOfListProperty, value); }
        }
    }
}
