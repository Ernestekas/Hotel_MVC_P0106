using HotelApp.Models.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Dtos.Hotels
{
    public class HotelViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Hotel name is too short.")]
        public string Name { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Address ir required.")]
        public string Address { get; set; }
        public int TotalRooms { get; set; } = 1;
        public int SelectedCityId { get; set; }
        public List<City> AllCities { get; set; }
        public int FloorsCount { get; set; } = 1;
        public int RoomsPerFloor { get; set; } = 1;
    }
}
