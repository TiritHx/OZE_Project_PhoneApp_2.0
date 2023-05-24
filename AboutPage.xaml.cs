using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Xml.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace OZE_2._0.Views
{
    public partial class AboutPage : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // to pobiera odpowiedz z bazy
            string devicesResponse = await Connekszyn.GetDevices();   

            Device devices = JsonSerializer.Deserialize<Device>(devicesResponse);

            foreach (Device device in devices)
            {
                string id = device._id;
                string name = device.name;
                string userID = device.userID;
                DateTime dateOfProduction = device.dateOfProduction;
                decimal power = device.Power.powerdecimal;
                decimal powerDaily = device.PowerDaily.powerdailydecimal;
                decimal powerMonthly = device.PowerMonthly.powermonthlydecimal;
                int version = device.__v;

                devicePowerLabel.Text = power.ToString();
                deviceIdLabel.Text = id;
                deviceNameLabel.Text = name;
                deviceDataLabel.Text = dateOfProduction.ToString();
            }
        }
        public AboutPage()
        {
            InitializeComponent();
        }
    }
}