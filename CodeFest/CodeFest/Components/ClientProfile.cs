using Xamarin.Forms;

namespace CodeFest.Components
{
    internal class ClientProfile : ContentView
    {
        public ClientProfile()
        {
            Padding = new Thickness(8, 1);
            var grid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection { new RowDefinition { } },
                ColumnDefinitions = new ColumnDefinitionCollection { new ColumnDefinition(), new ColumnDefinition() }
            };
            grid.Children.Add(new Label { Text = "FSP No" }, 0, 0);
            grid.Children.Add(new Label { Text = "12345", HorizontalTextAlignment = TextAlignment.Center }, 0, 1);
            grid.Children.Add(new Label { Text = "Risk" }, 1, 0);
            grid.Children.Add(new Label { Text = "Low", TextColor = Color.Green, HorizontalTextAlignment = TextAlignment.Center }, 1, 1);
            Content = new Frame
            {
                OutlineColor = Color.Black,
                HasShadow = true,
                Content = new StackLayout
                {
                    Children =
                    {
                        new Label
                        {
                            Text = "Allan Gray",
                            HorizontalTextAlignment = TextAlignment.Center,
                            FontSize = 30,
                            FontAttributes = FontAttributes.Bold
                        },
                        new Label
                        {
                            Text = "Financial Services Provider",
                            HorizontalTextAlignment = TextAlignment.Center
                        },
                        grid
                    }
                }
            };
        }
    }
}