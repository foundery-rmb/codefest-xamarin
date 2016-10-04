using CodeFest.Components;
using CodeFest.iOS.Component;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SpeechSearchBar), typeof(SpeechSearchBarRenderer))]
namespace CodeFest.iOS.Component
{
    public class SpeechSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
        }
    }
}