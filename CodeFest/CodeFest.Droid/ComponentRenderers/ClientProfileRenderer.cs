using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Text;
using Android.Views;
using CodeFest;
using CodeFest.Components;
using CodeFest.Droid.ComponentRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NativeClientProfile), typeof(ClientProfileRenderer))]
namespace CodeFest.Droid.ComponentRenderers
{
    class ClientProfileRenderer : ViewRenderer<NativeClientProfile, CardView>, INoCopySpan
    {
        protected override void OnElementChanged(ElementChangedEventArgs<NativeClientProfile> elementChangedEventArgs)
        {
            var view = (CardView)LayoutInflater.From(Forms.Context).Inflate(Resource.Layout.ClientProfile, null, false);
//            var clientProfileView = view.FindViewById<CardView>(Resource.Id.clientProfileCard);
            //clientProfileView.RemoveFromParent();
            SetNativeControl(view);
        }
    }
}