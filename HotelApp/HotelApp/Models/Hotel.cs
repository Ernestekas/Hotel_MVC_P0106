﻿using HotelApp.Models.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Models
{
    public class Hotel : Entity
    {
        [Required]
        [MinLength(2, ErrorMessage = "Hotel name is too short.")]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "City name is too short.")]
        public string City { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Address ir required.")]
        public string Address { get; set; }
        public int TotalRooms { get; set; }
        public bool UpdateInProgress { get; set; }
    }
}