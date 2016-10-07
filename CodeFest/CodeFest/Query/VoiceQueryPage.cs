using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CodeFest.Query
{
    public class VoiceQueryPage : NavigationPage
    {
        public VoiceQueryPage()
        {
            Navigation.PushAsync(new ContentPage {Content = new VoiceQuery(null)});
        }
    }
}
