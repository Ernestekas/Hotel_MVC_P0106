using HotelApp.Models.Generic;
using System.Collections.Generic;

namespace HotelApp.Models.Location
{
    public class Country : NamedEntity
    {
        public List<City> Cities { get; set; }
    }
}
