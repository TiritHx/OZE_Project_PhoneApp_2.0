using OZE_2._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                if((EmailEntry.Text != null) && (PasswordEntry.Text != null) && (SecondPasswordEntry.Text != null))
                {
                    if (PasswordEntry.Text == SecondPasswordEntry.Text)
                    {
                        // tu rejestracja i przechodzi dalej, sprawdx czy nie ma już użytkownika z takim emailem

                        string query = $"https://hydrospar.onrender.com/register/email/{EmailEntry.Text}/password/{PasswordEntry.Text}/reppassword/{SecondPasswordEntry.Text}";    // pobieranie listy użytkowników
                        HttpResponseMessage response = new HttpResponseMessage();
                        Task.Run(async () => { response = await httpClient.SendAsync(new HttpRequestMessage(new HttpMethod("POST"), new Uri(query))); });
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            infoLabel.Text = "Zarejestrowano pomyślnie";
                            infoFrame.IsVisible = true;
                            infoFrame.BackgroundColor = Color.Blue;
                            LoginHandler.Command.Execute(null);
                        }
                        else
                        {
                            infoLabel.Text = "Coś poszło nie tak";
                            infoFrame.IsVisible = true;
                        }
                    }
                    else
                    {
                        infoLabel.Text = "Hasła nie są takie same";
                        infoFrame.IsVisible = true;
                    }
                }
                else
                {
                    infoLabel.Text = "Uzupełnij wszystkie pola";
                    infoFrame.IsVisible = true;
                }
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
                if((EmailEntry.Text != null) && (PasswordEntry.Text != null))
                {
                    // tu sprawdź czy dobry login i przejdź dalej
                    string query = $"https://hydrospar.onrender.com/mobileLogin/email/{EmailEntry.Text}/password/{PasswordEntry.Text}";
                    HttpResponseMessage response = new HttpResponseMessage();
                    Task.Run(async () => { response = await httpClient.SendAsync(new HttpRequestMessage(new HttpMethod("POST"), new Uri(query))); });
                    //tests.Text = response.ToString();
                    LoginHandler.Command.Execute(null);
                }
                else
                {
                    infoLabel.Text = "Uzupełnij wszystkie pola";
                    infoFrame.IsVisible = true;
                } 
            }
        }
    }
}