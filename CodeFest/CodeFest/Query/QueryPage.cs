using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CodeFest.Query
{
    public class QueryPage : ContentPage
    {
        public QueryPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label
                    {
                        Text = "Hello ContentPage",
                        HorizontalTextAlignment = TextAlignment.Center
                    },
                    new Entry
                    {
                        
                    }
                }
            };
        }
    }
}
