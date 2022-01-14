namespace HotelApp.Dtos.Hotels
{
    public class BookRoomViewModel
    {
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerRequests { get; set; }
    }
}
