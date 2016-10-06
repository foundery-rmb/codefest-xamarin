using Xamarin.Forms;

namespace CodeFest
{
    public class NativeClientProfile : ContentView
    {
        public NativeClientProfile()
        {
            var grid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection {new RowDefinition()},
                ColumnDefinitions = new ColumnDefinitionCollection {new ColumnDefinition(), new ColumnDefinition()}
            };
            grid.Children.Add(new Label {Text = "FSP No"}, 0, 0);
            grid.Children.Add(new Label {Text = "12345", HorizontalTextAlignment = TextAlignment.Center}, 1, 0);
            grid.Children.Add(new Label {Text = "Risk"}, 0, 1);
            grid.Children.Add(
                new Label {Text = "Low", TextColor = Color.Green, HorizontalTextAlignment = TextAlignment.Center}, 1, 1);
            var item = new Label
            {
                Text = "Foo bar",
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 30,
                FontAttributes = FontAttributes.Bold
            }; 
            Content = new StackLayout
            {
                Children =
                {
                    item,
                    new Label
                    {
                        Text = "Financial Services Provider",
                        HorizontalTextAlignment = TextAlignment.Center
                    },
                    grid
                }
            };
        }
    }
}