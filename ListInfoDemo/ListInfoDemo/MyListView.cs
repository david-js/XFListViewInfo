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

        // Keep track of previous state and when the next time the reported value might change.
        // _nextShowChange is stored to allow a delay before a change in the value is allowed to avoid a jittery look.
        private bool? _lastShowValue;
        private DateTime _nextShowChange;
        public bool ShouldShowSearchBar
        {
            get {
                var newValue = AtStartOfList || LastScrollDirection == ScrollToStart;
                var shouldChange = (!_lastShowValue.HasValue) || (_lastShowValue.Value != newValue && _nextShowChange < DateTime.Now);

                if (shouldChange)
                {
                    _lastShowValue = newValue;
                    _nextShowChange = DateTime.Now.AddMilliseconds(250);
                }

                return shouldChange ? newValue : _lastShowValue.Value;
            }
        }

        public string LastScrollDirection
        {
            get { return (string)GetValue(LastScrollDirectionProperty); }
            set {
                SetValue(LastScrollDirectionProperty, value);
                OnPropertyChanged(nameof(ShouldShowSearchBar));
            }
        }

        public bool AtStartOfList
        {
            get { return (bool)GetValue(AtStartOfListProperty); }
            set {
                SetValue(AtStartOfListProperty, value);
                OnPropertyChanged(nameof(ShouldShowSearchBar));
            }
        }
    }
}
