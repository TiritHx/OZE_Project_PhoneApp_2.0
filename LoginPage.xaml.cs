using OZE_2._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OZE_2._0.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
         HttpClient httpClient = new HttpClient();
        bool isRegister = false;

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        private void Reg_Button_Clicked(object sender, EventArgs e)
        {
            if (isRegister)
            {
                // tu rejestracja i przechodzi dalej, sprawdx czy nie ma już użytkownika z takim emailem

                //LoginHandler.Command.Execute(null);
            }
            else
            {
                frameRePass.IsVisible = true;
                labelRePass.IsVisible = true;
                SecondPasswordEntry.IsVisible = true;
                isRegister = true;
                justText.Text = "Register";
            }
        }

        private void Log_Button_Clicked(object sender, EventArgs e)
        {
            if (isRegister)
            {
                frameRePass.IsVisible = false;
                labelRePass.IsVisible = false;
                SecondPasswordEntry.IsVisible = false;
                isRegister = false;
                justText.Text = "Login";
            }
            else
            {
                // tu sprawdź czy dobry login i przejdź dalej
                string query = $"https://hydrospar.onrender.com/devices/getUserData";    // pobieranie listy użytkowników
                HttpResponseMessage response = new HttpResponseMessage();
                Task.Run(async () => { response = await httpClient.SendAsync(new HttpRequestMessage(new HttpMethod("POST"), new Uri(query))); });

                //LoginHandler.Command.Execute(null);
            }
        }
    }
}