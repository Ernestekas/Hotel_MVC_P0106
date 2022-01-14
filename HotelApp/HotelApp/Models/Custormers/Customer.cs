using HotelApp.Models.Generic;
using HotelApp.Models.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Models.Custormers
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Requests { get; set; }
    }
}
