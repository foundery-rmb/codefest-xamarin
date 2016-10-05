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
using CodeFest.Components;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SearchView = Android.Widget.SearchView;

namespace CodeFest.Droid.ComponentRenderers
{
    class ClientProfileRenderer : ViewRenderer<ClientProfile, CardView>, INoCopySpan, IJavaObject, IDisposable
    {
        public ClientProfileRenderer()
        {
            var control = LayoutInflater.From(Forms.Context).Inflate(Resource.Layout.ClientProfile, null, false);
            var clientProfileView = control.FindViewById<CardView>(Resource.Id.clientProfileCard);

            SetNativeControl(clientProfileView);
        }
    }
}