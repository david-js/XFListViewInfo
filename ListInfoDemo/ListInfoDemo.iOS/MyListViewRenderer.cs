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
        private MyListView _myListView;

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == _myListView)
                _myListView = null;

            if (e.NewElement is MyListView)
            {
                _myListView = Element as MyListView;

                _myListView.LastScrollDirection = MyListView.NoPreviousScroll;
                _myListView.AtStartOfList = true;

                _offsetObserver = Control.AddObserver("contentOffset", Foundation.NSKeyValueObservingOptions.New, HandleAction);
            }
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            if (_myListView != null)
                _myListView.AtEndOfList = IsAtEndOfList();
        }

        private bool IsAtEndOfList()
        {
            // Strictly speaking, the '- 10' is not necessary, but gives a little better experience,
            // since it generally means that the last element is visible. It is possible to more directly
            // check for that condition, or to remove the '- 10' entirely, depending on needs.
            return Control.Frame.Height + Control.ContentOffset.Y >= Control.ContentSize.Height - 10;
        }

        private static bool CloseTo(double x, double y)
        {
            return Math.Abs(x - y) < 0.1;
        }

        private void HandleAction(Foundation.NSObservedChange obj)
        {
            var effectiveY = Math.Max(Control.ContentOffset.Y, 0);
            if (!CloseTo(effectiveY, _prevYOffset) && _myListView != null)
            {
                var direction = effectiveY > _prevYOffset ? MyListView.ScrollToEnd : MyListView.ScrollToStart;
                _myListView.LastScrollDirection = direction;
                _prevYOffset = effectiveY;

                _myListView.AtStartOfList = CloseTo(effectiveY, 0);
                _myListView.AtEndOfList = IsAtEndOfList();
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
