using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFest.Components;
using CodeFest.Models;
using Xamarin.Forms;

namespace CodeFest.Query
{
    public class VoiceQuery : View
    {
        public ActivityIndicator ActivityIndicator;

        public VoiceQuery(ActivityIndicator activityIndicator)
        {
            ActivityIndicator = activityIndicator;
        }

        public async Task DisplayResult(QueryServiceResponse data)
        {
            if (data.queryResponse.intentName == "Show Client Profile")
            {
                await Navigation.PushAsync(new ResultPage(data.clientModel));
            }
        }
    }
}
