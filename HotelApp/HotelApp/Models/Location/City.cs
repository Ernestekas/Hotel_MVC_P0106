using HotelApp.Models.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Models.Location
{
    public class City : NamedEntity
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
