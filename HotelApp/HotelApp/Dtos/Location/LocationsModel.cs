using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Dtos.Location
{
    public class LocationsModel
    {
        public List<int> CountriesIds { get; set; }
        public List<string> CountriesNames { get; set; }
        public List<int> CountriesCitiesCount { get; set; } = new List<int>();
        public List<int> CountriesTotalHotelsCount { get; set; } = new List<int>();
    }
}
