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

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement is MyListView)
            {
                var myList = Element as MyListView;

                myList.LastScrollDirection = MyListView.NoPreviousScroll;
                myList.AtStartOfList = true;

                List.PointerEntered += List_PointerEntered;
            }
        }

        private void List_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            _scrollViewer = GetScrollViewer(List);
            if (_scrollViewer != null)
                _scrollViewer.ViewChanged += ScrollViewer_ViewChanged;
        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (Element is MyListView)
            {
                var myList = Element as MyListView;

                if (_prevVerticalOffset != _scrollViewer.VerticalOffset)
                {
                    var direction = _scrollViewer.VerticalOffset > _prevVerticalOffset ? MyListView.ScrollToEnd : MyListView.ScrollToStart;
                    myList.LastScrollDirection = direction;
                    myList.AtStartOfList = (_scrollViewer.VerticalOffset == 0);
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
