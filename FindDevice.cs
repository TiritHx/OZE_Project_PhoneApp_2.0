using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace OZE_2._0
{
    public static class FindDevice
    {
        public static async Task<string> Yo()
        {
            // Pobieranie odpowiedzi z bazy
            string devicesResponse = await Connekszyn.GetDevices();

            // Deserializacja za pomocą Newtonsoft.Json
            List<DeviceResponse> deviceResponses = JsonConvert.DeserializeObject<List<DeviceResponse>>(devicesResponse);

            List<Device> devices = new List<Device>();

            foreach (DeviceResponse deviceResponse in deviceResponses)
            {
                Device device = new Device
                {
                    _id = deviceResponse._id,
                    name = deviceResponse.name,
                    userID = deviceResponse.userID,
                    dateOfProduction = deviceResponse.dateOfProduction,
                    Power = deviceResponse.Power,
                    PowerDaily = deviceResponse.PowerDaily,
                    PowerMonthly = deviceResponse.PowerMonthly,
                    __v = deviceResponse.__v
                };

                devices.Add(device);
            }

            string devicesJson = JsonConvert.SerializeObject(devices);

            return devicesJson;
        }
    }
}
