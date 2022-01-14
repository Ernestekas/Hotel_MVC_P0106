using HotelApp.Models.Generic;

namespace HotelApp.Models.Location
{
    public class City : NamedEntity
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
