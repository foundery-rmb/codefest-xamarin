using Xamarin.Forms;

namespace CodeFest.Components
{
    internal class ClientProfile : ContentView
    {
        public ClientProfile()
        {
            Padding = new Thickness(8, 1);
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
                        new AbsoluteLayout
                        {
                            Children = { new Label { Text = "FSP No" }, new Label { Text = "12345" } }
                        }
                    }
                }
            };
        }
    }
}