using Android.Support.V7.Widget;
using Android.Text;
using Android.Views;
using Android.Widget;
using CodeFest;
using CodeFest.Droid.ComponentRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NativeClientProfile), typeof(NativeClientProfileRenderer))]
namespace CodeFest.Droid.ComponentRenderers
{
    class NativeClientProfileRenderer : ViewRenderer<NativeClientProfile, CardView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NativeClientProfile> elementChangedEventArgs)
        {
            var view = new CardView(Context);
//            view.SetCardBackgroundColor(0x00000000);
            SetNativeControl(view);
        }
    }
}