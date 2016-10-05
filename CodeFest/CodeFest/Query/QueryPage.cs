using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using CodeFest.Components;
using Xamarin.Forms;

namespace CodeFest.Query
{
    public class QueryPage : NavigationPage
    {
        private Label _label;
        private ActivityIndicator _activityIndicator;

        public QueryPage()
        {
            _label = new Label
            {
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            var speechSearchBar = new SpeechSearchBar
            {
                Placeholder = "Query"
            };
            speechSearchBar.TextChanged += (sender, args) =>
            {
                _label.Text = args.NewTextValue;
            };
            speechSearchBar.SearchButtonPressed += async (sender, args) =>
            {
                _activityIndicator.IsRunning = true;
                await Task.Delay(500);
                _activityIndicator.IsRunning = false;
                await Navigation.PushAsync(new ResultPage());
            };
            _activityIndicator = new ActivityIndicator();
            Navigation.PushAsync(new ContentPage
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        _label,
                        speechSearchBar,
                        _activityIndicator
                    }
                }
            });
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
