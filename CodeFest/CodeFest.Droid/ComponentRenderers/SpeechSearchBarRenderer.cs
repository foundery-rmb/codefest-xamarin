using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using CodeFest.Components;
using CodeFest.Droid.ComponentRenderers;
using Java.Lang;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SpeechSearchBar), typeof(SpeechSearchBarRenderer))]
namespace CodeFest.Droid.ComponentRenderers
{
    class SpeechSearchBarRenderer : ViewRenderer<SpeechSearchBar, SearchView>, INoCopySpan, IJavaObject, IDisposable, SearchView.IOnQueryTextListener
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SpeechSearchBar> elementChangedEventArgs)
        {
            var control = LayoutInflater.From(Forms.Context).Inflate(Resource.Layout.SpeechSearchView, null, false);
            var searchView = (SearchView) control.FindViewById(Resource.Id.query);
            searchView.RemoveFromParent();
            searchView.SetOnQueryTextListener(this);
//            var searchableInfo = SearchManager.FromContext(Context).GetSearchableInfo(new ComponentName(Context, Class.FromType(typeof(ClientProvider))));
//            
//            searchView.SetSearchableInfo(searchableInfo);
            SetNativeControl(searchView);
        }

        public bool OnQueryTextChange(string newText)
        {
            if (string.IsNullOrEmpty(this.Element.Text) && string.IsNullOrEmpty(newText))
                return false;
            this.Element.SetValue(SearchBar.TextProperty, (object)newText);
            return true;
        }

        public bool OnQueryTextSubmit(string query)
        {
            ((ISearchBarController)this.Element).OnSearchButtonPressed();
            return true;
        }
    }
}