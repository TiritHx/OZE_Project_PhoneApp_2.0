using OZE_2._0.Services;
using OZE_2._0.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OZE_2._0
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell(); // to musi być żeby działało ehhhhh
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
