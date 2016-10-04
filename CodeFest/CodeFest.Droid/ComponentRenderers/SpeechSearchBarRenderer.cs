using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using CodeFest.Components;
using CodeFest.Droid.ComponentRenderers;
using Java.Lang;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SpeechSearchBar), typeof(SpeechSearchBarRenderer))]
namespace CodeFest.Droid.ComponentRenderers
{
    class SpeechSearchBarRenderer : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            var control = LayoutInflater.From(Forms.Context).Inflate(Resource.Layout.SpeechSearchView, null, false);
            var searchView = (SearchView) control.FindViewById(Resource.Id.query);
            var searchableInfo = SearchManager.FromContext(Context).GetSearchableInfo(new ComponentName(Context, Class.FromType(typeof(ClientProvider))));
            searchView.SetSearchableInfo(searchableInfo);
            SetNativeControl(control);
        }
    }
}