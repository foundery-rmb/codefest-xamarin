﻿using System.Collections.Generic;
using CodeFest.Models;
using Xamarin.Forms;

namespace CodeFest.Components
{
    internal class ClientProfile : ContentView
    {
        private readonly ClientModel _clientModel;
        private readonly List<FundModel> _funds;

        public ClientProfile(ClientModel clientModel, List<FundModel> funds)
        {
            _clientModel = clientModel;
            _funds = funds;

            Padding = new Thickness(8, 1);

            var stack = new StackLayout();

            var screenType = new Label
            {
                Text = "Corporate Profile",
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Start
            };

            var clientName = new Label
            {
                Text = ClientModel.ClientName,
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 30,
                FontAttributes = FontAttributes.Bold
            };

            var clientDetailsGrid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection {new RowDefinition()},
                ColumnDefinitions = new ColumnDefinitionCollection {new ColumnDefinition(), new ColumnDefinition()}
            };
            clientDetailsGrid.Children.Add(new Label {Text = ClientModel.LegalPersona, HorizontalTextAlignment = TextAlignment.Start}, 0, 0);

            clientDetailsGrid.Children.Add(new Label {Text = "Reg #: " + ClientModel.RegNumber, HorizontalTextAlignment = TextAlignment.Start}, 1, 0);
            clientDetailsGrid.Children.Add(new Label {Text = ClientModel.ClientCatagory, HorizontalTextAlignment = TextAlignment.Start }, 0, 1);
            clientDetailsGrid.Children.Add(new Label {Text = "FSP#: " + ClientModel.FspNumber, HorizontalTextAlignment = TextAlignment.Start }, 1, 1);
            clientDetailsGrid.Children.Add(
                new Label {Text = ClientModel.Risk, HorizontalTextAlignment = TextAlignment.Start}, 0, 2);


            stack.Children.Add(screenType);
            stack.Children.Add(clientName);

            var clientDetailsFrame = new Frame();
            clientDetailsFrame.OutlineColor = Color.Gray;
            clientDetailsFrame.Content = clientDetailsGrid;
//            clientDetailsFrame.BackgroundColor = col

            stack.Children.Add(clientDetailsFrame);

            var scroll = new ScrollView();
            scroll.Content = stack;
            Content = scroll;
        }

        public ClientModel ClientModel
        {
            get { return _clientModel; }
        }
    }
}