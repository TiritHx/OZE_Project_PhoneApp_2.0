using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OZE_2._0.Views
{
    public partial class AboutPage : ContentPage
    {
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            string devicesJson = await FindDevice.Yo();

            //kolejna deserializacja
            List<Device> devices = JsonConvert.DeserializeObject<List<Device>>(devicesJson);

            devicePowerLabel.Text = devices[0].Power.powerdecimal.ToString();
            deviceIdLabel.Text = devices[0]._id;
            deviceNameLabel.Text = devices[0].name;
            deviceDataLabel.Text = devices[0].dateOfProduction.ToString();
            monthMoner.Text = "$"+(((double.Parse(devices[0].Power.powerdecimal.ToString()) * 24 * 30) / 500) * 0.24).ToString();
            yearMoner.Text = "$"+(((double.Parse(devices[0].Power.powerdecimal.ToString()) * 24 * 30 * 12) / 500) * 0.24).ToString();
            
        }
        public AboutPage()
        {
            InitializeComponent();
            //wyświetlanie svg
            string svgchart = "<svg width=\"20\" height=\"18\" viewBox=\"0 0 20 18\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">\r\n<path d=\"M0 0V18H20V15.4286H2.5V0H0ZM12.5 0V12.8571H17.5V0H12.5ZM5 5.14286V12.8571H10V5.14286H5Z\" fill=\"white\"/>\r\n</svg>";
            string svgchartHtml = $"<html><body style=\"background-color: #4DA7EA;\">{svgchart}</body></html>";

            string svgpower = "<svg width=\"17\" height=\"27\" viewBox=\"0 0 17 30\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">\r\n<path d=\"M10.2 0L0 16.875H6.8V27L17 10.125H10.2V0Z\" fill=\"white\"/>\r\n</svg>";
            string svgpowerHtml = $"<html><body style=\"background-color: #4DA7EA;\">{svgpower}</body></html>";

            string svgbattery = "<svg width=\"21\" height=\"15\" viewBox=\"0 0 25 15\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">\r\n<path d=\"M0.236546 0.025C0.0788486 0.025 0 0.125 0 0.25V14.775C0 14.9 0.105131 15 0.236546 15H18.1352C18.2666 15 18.3717 14.9 18.3717 14.775V10H21V5H18.3717V0.225C18.3717 0.075 18.2666 0 18.1352 0H0.236546V0.025ZM2.62829 2.525H15.7697V12.525H2.62829V2.525Z\" fill=\"white\"/>\r\n</svg>";
            string svgbatteryHtml = $"<html><body style=\"background-color: #4DA7EA;\">{svgbattery}</body></html>";

            string svgdollar = "<svg width=\"17\" height=\"26\" viewBox=\"0 0 17 26\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">\r\n<path d=\"M6.46983 0V3.21882H4.05571C1.86692 3.21882 0.0321882 5.05355 0.0321882 7.24235V8.85176C0.0321882 11.0406 1.44847 12.8431 3.5407 13.3903L11.7809 15.5147C12.2315 15.6435 12.8753 16.4482 12.8753 16.931V18.5404C12.8753 18.991 12.5212 19.3451 12.0706 19.3451H4.02353C3.63727 19.3451 3.34757 19.2164 3.21882 19.152V16.1263H0V19.3451C0 20.4395 0.643764 21.373 1.41628 21.8558C2.15661 22.3708 3.09007 22.5639 4.02353 22.5639H6.43764V25.7828H9.65646V22.5639H12.0706C14.2916 22.5639 16.0941 20.7614 16.0941 18.5404V16.931C16.0941 14.7422 14.6778 12.9397 12.5856 12.3925L4.34541 10.268C3.89477 10.1393 3.25101 9.33458 3.25101 8.85176V7.24235C3.25101 6.79171 3.60508 6.43764 4.05571 6.43764H12.1028C12.4568 6.43764 12.7787 6.56639 12.9075 6.63077V9.65646H16.1263V6.43764C16.1263 5.34324 15.4825 4.40978 14.71 3.92696C13.9697 3.41195 13.0362 3.21882 12.1028 3.21882H9.68865V0L6.46983 0Z\" fill=\"white\"/>\r\n</svg>";
            string svgdollarHtml = $"<html><body style=\"background-color: #62C060;\">{svgdollar}</body></html>";

            string svgcalendar = "<svg width=\"17\" height=\"19\" viewBox=\"0 0 17 19\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">\r\n<path d=\"M0.0242511 0V4.75H17V0H0.0242511ZM0.0242511 7.125V18.7862C0.0242511 18.905 0.121255 19 0.242511 19H16.7575C16.8787 19 16.9757 18.905 16.9757 18.7862V7.125H0H0.0242511ZM2.44936 9.5H4.87446V11.875H2.44936V9.5ZM7.29957 9.5H9.72468V11.875H7.29957V9.5ZM12.1498 9.5H14.5749V11.875H12.1498V9.5ZM2.44936 14.25H4.87446V16.625H2.44936V14.25ZM7.29957 14.25H9.72468V16.625H7.29957V14.25Z\" fill=\"white\"/>\r\n</svg>";
            string svgcalendarHtml = $"<html><body style=\"background-color: #62C060;\">{svgcalendar}</body></html>";
            string svgcalendar2Html = $"<html><body style=\"background-color: #8C5DA1;\">{svgcalendar}</body></html>";

            string svgkey = "<svg width=\"20\" height=\"20\" viewBox=\"0 0 25 20\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">\r\n<path d=\"M13.75 0C10.3 0 7.5 2.8 7.5 6.25C7.5 6.65 7.5 7.05 7.575 7.425L0 15V20H7.5V15H12.5V12.5L12.575 12.425C12.95 12.5 13.35 12.5 13.75 12.5C17.2 12.5 20 9.7 20 6.25C20 2.8 17.2 0 13.75 0ZM15 2.5C16.375 2.5 17.5 3.625 17.5 5C17.5 6.375 16.375 7.5 15 7.5C13.625 7.5 12.5 6.375 12.5 5C12.5 3.625 13.625 2.5 15 2.5Z\" fill=\"white\"/>\r\n</svg>";
            string svgkeyHtml = $"<html><body style=\"background-color: #8C5DA1;\">{svgkey}</body></html>";

            string svglist = "<svg width=\"20\" height=\"20\" viewBox=\"0 0 25 20\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">\r\n<path d=\"M7.5 0C6.125 0 5 1.125 5 2.5V16.25C5 16.95 4.45 17.5 3.75 17.5C3.05 17.5 2.5 16.95 2.5 16.25V12.5H0V17.5C0 18.875 1.125 20 2.5 20H15C16.375 20 17.5 18.875 17.5 17.5V10H7.5V3.75C7.5 3.05 8.05 2.5 8.75 2.5C9.45 2.5 10 3.05 10 3.75V7.5H20V2.5C20 1.125 18.875 0 17.5 0H7.5Z\" fill=\"white\"/>\r\n</svg>";
            string svglistHtml = $"<html><body style=\"background-color: #8C5DA1;\">{svglist}</body></html>";

            string svgsettings = "<svg width=\"23\" height=\"23\" viewBox=\"0 0 32 23\" fill=\"none\" xmlns=\"http://www.w3.org/2000/svg\">\r\n<path d=\"M10.0661 0L8.63217 3.41272C8.34539 3.49875 8.08728 3.64214 7.82918 3.78554L4.41646 2.35162L2.35162 4.41646L3.78554 7.82918C3.64214 8.11596 3.52743 8.34539 3.41272 8.63217L0 10.0661V12.9339L3.41272 14.3678C3.52743 14.6546 3.64214 14.884 3.78554 15.1708L2.35162 18.5835L4.41646 20.6484L7.82918 19.2145C8.08728 19.3292 8.34539 19.4726 8.63217 19.5873L10.0661 23H12.9339L14.3678 19.5873C14.6259 19.4726 14.9127 19.3579 15.1708 19.2145L18.5835 20.6484L20.6484 18.5835L19.2145 15.1708C19.3292 14.9127 19.4726 14.6259 19.5873 14.3678L23 12.9339V10.0661L19.5873 8.63217C19.5012 8.37406 19.3579 8.08728 19.2145 7.82918L20.6484 4.41646L18.5835 2.35162L15.1708 3.78554C14.9127 3.67082 14.6259 3.52743 14.3678 3.41272L12.9339 0L10.0661 0ZM11.5 7.16958C13.8803 7.16958 15.8017 9.09102 15.8017 11.4713C15.8017 13.8516 13.8803 15.7731 11.5 15.7731C9.1197 15.7731 7.19825 13.8516 7.19825 11.4713C7.19825 9.09102 9.1197 7.16958 11.5 7.16958Z\" fill=\"white\"/>\r\n</svg>";
            string svgsettingsHtml = $"<html><body style=\"background-color: #8C5DA1;\">{svgsettings}</body></html>";

            chart.Source = new HtmlWebViewSource { Html = svgchartHtml };
            power.Source = new HtmlWebViewSource { Html = svgpowerHtml };
            battery.Source = new HtmlWebViewSource { Html = svgbatteryHtml };
            dollar.Source = new HtmlWebViewSource { Html = svgdollarHtml };
            calendar.Source = new HtmlWebViewSource { Html = svgcalendarHtml };
            calendar1.Source = new HtmlWebViewSource { Html = svgcalendarHtml };
            calendar2.Source = new HtmlWebViewSource { Html = svgcalendar2Html };
            key.Source = new HtmlWebViewSource { Html = svgkeyHtml };
            list.Source = new HtmlWebViewSource { Html = svglistHtml };
            settings.Source = new HtmlWebViewSource { Html = svgsettingsHtml };
        }
    }
}