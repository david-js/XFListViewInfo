using ListInfoDemo;
using ListInfoDemo.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

[assembly: ExportRenderer(typeof(MyListView), typeof(MyListViewRenderer))]

namespace ListInfoDemo.UWP
{
    // This implementation owes a debt to:
    // https://stackoverflow.com/questions/36421674/uwp-catch-list-view-scroll-event
    public class MyListViewRenderer : ListViewRenderer
    {
        private double _prevVerticalOffset;
        private ScrollViewer _scrollViewer;
        private MyListView _myListView;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == _myListView)
                _myListView = null;

            if (e.NewElement is MyListView)
            {
                _myListView = Element as MyListView;

                _myListView.LastScrollDirection = MyListView.NoPreviousScroll;
                _myListView.AtStartOfList = true;

                List.PointerEntered += List_PointerEntered;
            }
        }

        private void List_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            _scrollViewer = GetScrollViewer(List);
            if (_scrollViewer != null)
            {
                _myListView.AtEndOfList = (_scrollViewer.ViewportHeight + _scrollViewer.VerticalOffset) >= _scrollViewer.ExtentHeight;
                _scrollViewer.ViewChanged += ScrollViewer_ViewChanged;
            }
        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (_myListView != null)
            {
                if (_prevVerticalOffset != _scrollViewer.VerticalOffset)
                {
                    var direction = _scrollViewer.VerticalOffset > _prevVerticalOffset ? MyListView.ScrollToEnd : MyListView.ScrollToStart;
                    _myListView.LastScrollDirection = direction;
                    _myListView.AtStartOfList = (_scrollViewer.VerticalOffset == 0);
                    // Because of the way that UWP measures sizes, it's difficult to get to *exactly* the end,
                    // but the measures end up being close, so add a small adjustment (we use 5, but YMMV).
                    _myListView.AtEndOfList = (_scrollViewer.ViewportHeight + _scrollViewer.VerticalOffset + 5) >= _scrollViewer.ExtentHeight;
                    _prevVerticalOffset = _scrollViewer.VerticalOffset;
                }
            }
        }

        private static ScrollViewer GetScrollViewer(DependencyObject depObj)
        {
            if (depObj is ScrollViewer)
                return depObj as ScrollViewer;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = GetScrollViewer(child);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}
