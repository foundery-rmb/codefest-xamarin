using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using CodeFest.Components;
using Xamarin.Forms;

namespace CodeFest
{
    public class FundsPage : ContentPage
    {
        public FundsPage(ClientModel clientModel)
        {
            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new FundList(clientModel)
                    }
                }
            };
        }
    }
}
