using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Models.Hotels;

namespace HotelApp.Dtos.Employees
{
    public class CleanerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SelectedHotelId { get; set; }
        public List<Hotel> AllHotels { get; set; }
    }
}
