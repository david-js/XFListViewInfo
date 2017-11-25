using System;
using ListInfoDemo;
using ListInfoDemo.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyListView), typeof(MyListViewRenderer))]

namespace ListInfoDemo.iOS
{
    public class MyListViewRenderer : ListViewRenderer
    {
        private double _prevYOffset;
        private IDisposable _offsetObserver;

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement is MyListView)
            {
                var myList = Element as MyListView;

                myList.LastScrollDirection = MyListView.NoPreviousScroll;
                myList.AtStartOfList = true;

                _offsetObserver = Control.AddObserver("contentOffset", Foundation.NSKeyValueObservingOptions.New, HandleAction);
            }
        }

        private static bool CloseTo(double x, double y)
        {
            return Math.Abs(x - y) < 0.1;
        }

        private void HandleAction(Foundation.NSObservedChange obj)
        {
            var effectiveY = Math.Max(Control.ContentOffset.Y, 0);
            if (!CloseTo(effectiveY, _prevYOffset) && Element is MyListView)
            {
                var direction = effectiveY > _prevYOffset ? MyListView.ScrollToEnd : MyListView.ScrollToStart;
                var myList = Element as MyListView;
                myList.LastScrollDirection = direction;
                _prevYOffset = effectiveY;

                myList.AtStartOfList = CloseTo(effectiveY, 0);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && _offsetObserver != null)
            {
                _offsetObserver.Dispose();
                _offsetObserver = null;
            }
        }
    }
}
