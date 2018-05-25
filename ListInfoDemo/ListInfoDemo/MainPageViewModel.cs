using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ListInfoDemo
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private bool _isAtStartOfList;
        public bool IsAtStartOfList
        {
            get
            {
                return _isAtStartOfList;
            }
            set
            {
                if (value != _isAtStartOfList)
                {
                    _isAtStartOfList = value;
                    NotifyChanged();
                    NotifyChanged(nameof(ShouldShowSearchBar));
                }
            }
        }

        private string _lastScrollDirection;
        public string ScrollingDirection
        {
            get
            {
                return _lastScrollDirection;
            }
            set
            {
                if (value != _lastScrollDirection)
                {
                    _lastScrollDirection = value;
                    NotifyChanged();
                    NotifyChanged(nameof(ShouldShowSearchBar));
                }
            }
        }

        // Keep track of previous state and when the next time the reported value might change.
        // _nextShowChange is stored to allow a delay before a change in the value is allowed to avoid a jittery look.
        private bool? _lastShowValue;
        private DateTime _nextShowChange;
        public bool ShouldShowSearchBar
        {
            get
            {
                var newValue = IsAtStartOfList || ScrollingDirection == MyListView.ScrollToStart;
                var shouldChange = (!_lastShowValue.HasValue) || (_lastShowValue.Value != newValue && _nextShowChange < DateTime.Now);

                if (shouldChange)
                {
                    _lastShowValue = newValue;
                    _nextShowChange = DateTime.Now.AddMilliseconds(250);
                }

                return shouldChange ? newValue : _lastShowValue.Value;
            }
        }

        public List<MovieRating> Movies
        {
            get
            {
                return MovieRatingData.Movies;
            }
        }
    }
}
