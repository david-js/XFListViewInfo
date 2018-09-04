# XFListViewInfo
Show how to get information about how a user is scrolling a ListView in real time.

See ListInfoDemo/ListInfoDemo/MyListView.cs for the added bindable properties that are made available to the Forms code.

For the custom renderers, see:
- ListInfoDemo/ListInfoDemo.Android/MyListViewRenderer.cs
- ListInfoDemo/ListInfoDemo.iOS/MyListViewRenderer.cs
- ListInfoDemo/ListInfoDemo.UWP/MyListViewRenderer.cs

For a writeup of the techniques used, see http://criticalhittech.com/2017/11/14/observing-listview-scrolling-in-xamarin-forms/

This now includes a SearchBar, which appears and disappears above the ListView as the user is scrolling. The SearchBar doesn't actually do anything, but it does show how to make a SearchBar behave visually in this way. See http://criticalhittech.com/2017/12/07/disappearing-searchbar-for-xamarin-forms/ for explanation, and virtually all of the interesting code for this is in ListInfoDemo/ListInfoDemo/MyListView.cs.

The code in the master branch really cuts things down the bare essentials to demonstrate how to make this work. In the [useviewmodel branch](https://github.com/david-js/XFListViewInfo/tree/useviewmodel), there is a view model with properties that get updated based on how the user is scrolling, and is probably closer to what you'd want in your code.
