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

            _clientModel = new ClientModel();
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
            stack.Children.Add(clientDetailsFrame);

            Content = stack;
        }

        public ClientModel ClientModel
        {
            get { return _clientModel; }
        }
    }
}