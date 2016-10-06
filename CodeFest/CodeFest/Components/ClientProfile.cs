using System.Collections.Generic;
using System.Linq;
using CodeFest.Models;
using Xamarin.Forms;

namespace CodeFest.Components
{
    internal class ClientProfile : ContentView
    {
        private readonly ClientModel _clientModel;

        public ClientProfile(ClientModel clientModel)
        {
            _clientModel = clientModel;

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
                ColumnDefinitions = new ColumnDefinitionCollection {new ColumnDefinition()}
            };
            clientDetailsGrid.Children.Add(new Label {Text = ClientModel.LegalPersona, HorizontalTextAlignment = TextAlignment.Start}, 0, 0);

            clientDetailsGrid.Children.Add(new Label {Text = "Reg #: " + ClientModel.RegNumber, HorizontalTextAlignment = TextAlignment.Start}, 0, 3);
            clientDetailsGrid.Children.Add(new Label {Text = ClientModel.ClientCatagory, HorizontalTextAlignment = TextAlignment.Start }, 0, 1);
            clientDetailsGrid.Children.Add(new Label {Text = "FSP#: " + ClientModel.FspNumber, HorizontalTextAlignment = TextAlignment.Start }, 0, 4);

            var riskColor = Color.Black;

            if (ClientModel.Risk.ToLower() == "high risk")
            {
                riskColor = Color.Red;
            }
            else if (ClientModel.Risk.ToLower() == "low risk")
            {
                riskColor = Color.Green;
            }

            clientDetailsGrid.Children.Add(
                new Label {Text = ClientModel.Risk, HorizontalTextAlignment = TextAlignment.Start, TextColor = riskColor}, 0, 2);


            stack.Children.Add(screenType);
            stack.Children.Add(clientName);

            var clientDetailsFrame = new Frame();
            clientDetailsFrame.OutlineColor = Color.Gray;
            clientDetailsFrame.Content = clientDetailsGrid;

            stack.Children.Add(clientDetailsFrame);

            var fundsGrid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection { new RowDefinition() },
                ColumnDefinitions = new ColumnDefinitionCollection { new ColumnDefinition(), new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) } }
            };

            var funds = clientModel.FundCounts().OrderByDescending(f => f.Value).ToArray();
            var fundTotal = clientModel.FundCounts().Sum(f => f.Value);

            fundsGrid.Children.Add(new Label { Text = "All Funds", HorizontalTextAlignment = TextAlignment.Start, FontAttributes = FontAttributes.Bold}, 0, 1);
            fundsGrid.Children.Add(new Label { Text = fundTotal.ToString(), HorizontalTextAlignment = TextAlignment.End, FontAttributes = FontAttributes.Bold }, 1, 0);

            for (int i = 1; i < funds.Length+1; i ++)
            {
                fundsGrid.Children.Add(new Label {Text = funds[i].Key, HorizontalTextAlignment = TextAlignment.Start}, 0, i);
                fundsGrid.Children.Add(new Label {Text = funds[i].Value.ToString(), HorizontalTextAlignment = TextAlignment.End}, 1, i);
            }

            var fundsFrame = new Frame();
            fundsFrame.OutlineColor = Color.Gray;
            fundsFrame.Content = fundsGrid;

            stack.Children.Add(fundsFrame);

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