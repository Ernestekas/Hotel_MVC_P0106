using HotelApp.Models.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Dtos.Hotel
{
    public class CityJsonModel : NamedEntity
    {
        public int CountryId { get; set; }
    }
}
