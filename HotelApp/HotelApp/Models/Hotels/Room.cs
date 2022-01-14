using HotelApp.Models.Custormers;
using HotelApp.Models.Employees;
using HotelApp.Models.Generic;

namespace HotelApp.Models.Hotels
{
    public class Room : NamedEntity
    {
        public int FloorId { get; set; }
        public Floor Floor { get; set; }
        public int? CleanerId { get; set; }
        public Cleaner Cleaner { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public bool Booked { get; set; } = false;
        public bool CleanerAssigned { get; set; } = false;
        public bool Cleaned { get; set; } = true;
        public bool ClosedForCustomers { get; set; } = true;
        public string ClosedReason { get; set; } = "Ready to be opened. Need user confirmation.";
    }
}
