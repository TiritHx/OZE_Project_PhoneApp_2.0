using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OZE_2._0.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TurbinesPage : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            string devicesJson = await FindDevice.Yo();

            List<Device> devices = JsonConvert.DeserializeObject<List<Device>>(devicesJson);

            //Wyświetla wszystkie turbiny uzytkownika
            StackLayout stackLayout = new StackLayout();

            for (int i = 0; i < devices.Count; i++)
            {
                Label label = new Label
                {
                    Text = devices[i].name,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Padding = 20,
                    FontSize = 20
                };
                stackLayout.Children.Add(label);
            }

            Content = stackLayout;

        }
        public TurbinesPage()
        {
            InitializeComponent();
        }
    }
}