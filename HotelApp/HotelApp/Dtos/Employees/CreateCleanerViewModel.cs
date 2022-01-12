using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Models.Hotels;

namespace HotelApp.Dtos.Employees
{
    public class CreateCleanerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SelectedHotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
