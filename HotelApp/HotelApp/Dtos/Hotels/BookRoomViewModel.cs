using System.ComponentModel.DataAnnotations;

namespace HotelApp.Dtos.Hotels
{
    public class BookRoomViewModel
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Customer First Name is required.")]
        public string CustomerFirstName { get; set; }
        [Required(ErrorMessage = "Customer Last Name is required.")]
        public string CustomerLastName { get; set; }
        public string CustomerRequests { get; set; }
    }
}
