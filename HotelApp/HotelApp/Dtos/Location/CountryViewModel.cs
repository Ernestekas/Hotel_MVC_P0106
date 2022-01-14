using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Dtos.Location
{
    public class CountryViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
        public List<int> CitiesIds { get; set; }
        public string[] CitiesNames { get; set; }
    }
}
