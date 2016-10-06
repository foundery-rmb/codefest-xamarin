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

            var fundsGrid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection { new RowDefinition() },
                ColumnDefinitions = new ColumnDefinitionCollection { new ColumnDefinition(), new ColumnDefinition() }
            };


            var funds = _clientModel.Funds;
            var fundCatagories = _clientModel.FundCounts();
            for (int i = 0; i < fundCatagories.Keys.Count; i ++)
            {
                var catagory = fundCatagories.Keys.ToArray()[i];
//                var count = fundCatagories.TryGetValue(catagory, out = 0).ToString();

                fundsGrid.Children.Add(new Label {Text = "Fund Type", HorizontalTextAlignment = TextAlignment.Start}, i, 0);
                fundsGrid.Children.Add(new Label {Text = "1", HorizontalTextAlignment = TextAlignment.Start}, i, 1);
            }

            var fundsFrame = new Frame();
            fundsFrame.OutlineColor = Color.Gray;
            fundsFrame.Content = clientDetailsGrid;
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