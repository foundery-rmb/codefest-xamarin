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

namespace CodeFest.Droid.ComponentRenderers
{
    [Android.Runtime.Register("android/view/SpeechSearchView", DoNotGenerateAcw = true)]
    class SpeechSearchView : AutoCompleteTextView
    {
        public SpeechSearchView(Context context) : base(context)
        {
        }
    }
}