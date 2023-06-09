﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZE_2._0
{
    class Device
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string userID { get; set; }
        public DateTime dateOfProduction { get; set; }
        public Power Power { get; set; }
        public PowerDaily PowerDaily { get; set; }
        public PowerMonthly PowerMonthly { get; set; }
        public int __v { get; set; }

    }

    //niżej jakieś takie wygibasy bo jest objekt w objekcie
    public class Power
    {
        [JsonProperty("$numberDecimal")]
        public decimal powerdecimal { get; set; }
    }
    public class PowerDaily
    {
        [JsonProperty("$numberDecimal")]
        public decimal powerdailydecimal { get; set; }
    }
    public class PowerMonthly
    {
        [JsonProperty("$numberDecimal")]
        public decimal powermonthlydecimal { get; set; }
    }

    public class DeviceResponse
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string userID { get; set; }
        public DateTime dateOfProduction { get; set; }
        public Power Power { get; set; }
        public PowerDaily PowerDaily { get; set; }
        public PowerMonthly PowerMonthly { get; set; }
        public int __v { get; set; }
    }

}