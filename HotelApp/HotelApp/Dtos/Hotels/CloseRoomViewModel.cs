using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Dtos.Hotels
{
    public class CloseRoomViewModel
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string HotelName { get; set; }
        public string RoomName { get; set; }
        public string CloseReason { get; set; }
    }
}
