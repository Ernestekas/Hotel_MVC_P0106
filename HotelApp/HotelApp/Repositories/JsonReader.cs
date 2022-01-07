using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using HotelApp.Models;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace HotelApp.Repositories
{
    public class JsonReader
    {
        private readonly string _url = "https://raw.githubusercontent.com/russ666/all-countries-and-cities-json/master/countries.json";
        
        public void LithuanianCities()
        {
            string json = new WebClient().DownloadString(_url);
            var data = JObject.Parse(json);
            var test = data["Lithuania"];

        }
    }
}
