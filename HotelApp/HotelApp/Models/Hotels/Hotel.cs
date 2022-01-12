using HotelApp.Models.Employees;
using HotelApp.Models.Generic;
using HotelApp.Models.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Models.Hotels
{
    public class Hotel : NamedEntity
    {
        public int CityId { get; set; }
        public City City{ get; set; }
        public string Address { get; set; }
        public int TotalRooms { get; set; }
        public List<Floor> Floors { get; set; }
        public List<Cleaner> Cleaners { get; set; }
    }
}
