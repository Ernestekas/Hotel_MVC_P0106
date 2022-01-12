using HotelApp.Models.Generic;
using HotelApp.Models.Location;
using HotelApp.Models.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Models.Employees
{
    public class Cleaner : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
