using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Dtos
{
    public class DisplayHotels
    {
        public List<int> HotelsIds { get; set; }
        public List<string> HotelsNames { get; set; }
    }
}
