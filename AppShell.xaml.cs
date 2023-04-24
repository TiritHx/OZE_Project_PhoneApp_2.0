using OZE_2._0.ViewModels;
using OZE_2._0.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace OZE_2._0
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Navigation.PushAsync(new LoginPage()); // bez tego odpala sie AboutPage jako uno
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
