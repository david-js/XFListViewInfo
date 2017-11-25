using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using ListInfoDemo.Droid;
using Xamarin.Forms;
using ListInfoDemo;

[assembly:Xamarin.Forms.ExportRenderer(typeof(MyListView), typeof(MyListViewRenderer))]

namespace ListInfoDemo.Droid
{
    public class MyListViewRenderer : ListViewRenderer
    {
        private bool _attached;
        private int _prevFirstVisibleElement;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement is MyListView)
            {
                var myList = Element as MyListView;

                myList.LastScrollDirection = MyListView.NoPreviousScroll;
                myList.AtStartOfList = true;

                _attached = true;
                Control.Scroll += Control_Scroll;
            }
        }

        private void Control_Scroll(object sender, AbsListView.ScrollEventArgs e)
        {
            if (e.FirstVisibleItem != _prevFirstVisibleElement && Element is MyListView)
            {
                var direction = e.FirstVisibleItem > _prevFirstVisibleElement ? MyListView.ScrollToEnd : MyListView.ScrollToStart;
                var myList = Element as MyListView;
                myList.LastScrollDirection = direction;
                myList.AtStartOfList = (e.FirstVisibleItem == 0);
                _prevFirstVisibleElement = e.FirstVisibleItem;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing && _attached)
            {
                _attached = false;
                Control.Scroll -= Control_Scroll;
            }
        }
    }
}