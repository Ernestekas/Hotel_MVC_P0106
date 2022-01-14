using HotelApp.Models.Generic;

namespace HotelApp.Models.Custormers
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Requests { get; set; }
    }
}
