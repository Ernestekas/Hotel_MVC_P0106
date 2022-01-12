using HotelApp.Models.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Models.Hotels
{
    public class Room : Entity
    {
        public int FloorId { get; set; }
        public Floor Floor { get; set; }
        public bool Booked { get; set; }
        public bool Cleaned { get; set; }
        public bool ClosedForCustomers { get; set; }
        public string ClosedReason { get; set; }
    }
}
