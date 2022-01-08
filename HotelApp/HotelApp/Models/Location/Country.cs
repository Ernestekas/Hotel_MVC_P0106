using HotelApp.Models.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Models.Location
{
    public class Country : NamedEntity
    {
        public List<City> Cities { get; set; }
    }
}
