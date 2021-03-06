﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using CodeFest.Components;
using Xamarin.Forms;

namespace CodeFest
{
    public class ResultPage : ContentPage
    {
        public ResultPage(ClientModel clientModel)
        {
            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        new ClientProfile(clientModel)
                    }
                }
            };
        }
    }
}
