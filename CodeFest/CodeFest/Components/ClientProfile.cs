using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodeFest
{
    public class ClientProfile : Frame
    {
        public ClientProfile()
        {
            Content = new StackLayout
            {
                Children =
                { 
                    new Label {Text = "Hello"}
                }
            };
        }
    }
}
