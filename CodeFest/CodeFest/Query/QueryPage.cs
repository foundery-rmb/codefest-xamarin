using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using CodeFest.Components;
using Xamarin.Forms;

namespace CodeFest.Query
{
    public class QueryPage : ContentPage
    {
        private Label _label;

        public QueryPage()
        {
            _label = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center
            };
            Content = new StackLayout
            {
                Children = {
                    _label,
                    new SpeechSearchBar
                    {
                        Placeholder = "Query"
                    }
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ping();
        }

        private async Task ping()
        {
            await Task.Delay(5000);
            _label.Text = await new PingService().ping();
        }
    }
}
