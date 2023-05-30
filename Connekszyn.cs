using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;


namespace OZE_2._0
{
    public static class Connekszyn
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task<string> GetDevices()
        {
            string userid = "646db60c947fef1ee881fd28";

            string apiUrl = "https://hydrospar.onrender.com/devices/" + userid + "/getDevices";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}