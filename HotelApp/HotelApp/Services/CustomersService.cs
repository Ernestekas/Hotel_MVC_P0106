using HotelApp.Dtos.Hotels;
using HotelApp.Models.Custormers;
using HotelApp.Models.Hotels;
using HotelApp.Repositories.Customers;
using HotelApp.Repositories.Hotels;

namespace HotelApp.Services
{
    public class CustomersService
    {
        CustomersRepository _customersRepository;
        RoomsRepository _roomsRepository;

        public CustomersService(CustomersRepository customersRepository, RoomsRepository roomsRepository)
        {
            _customersRepository = customersRepository;
            _roomsRepository = roomsRepository;
        }

        public BookRoomViewModel GetBookRoomModel(int roomId)
        {
            int hotelId = _roomsRepository.GetHotelByRoomId(roomId);
            Room room = _roomsRepository.GetById(roomId);

            BookRoomViewModel viewModel = new BookRoomViewModel()
            {
                HotelId = hotelId,
                RoomId = room.Id,
                RoomName = room.Name,
            };

            return viewModel;
        }

        public void BookRoom(BookRoomViewModel viewModel)
        {
            int customerId = Create(viewModel);
            Room room = _roomsRepository.GetById(viewModel.RoomId);
            room.Booked = true;
            room.CustomerId = customerId;

            _roomsRepository.Update(room);
        }

        private int Create(BookRoomViewModel viewModel)
        {
            Customer customer = new Customer()
            {
                FirstName = viewModel.CustomerFirstName,
                LastName = viewModel.CustomerLastName,
                Requests = viewModel.CustomerRequests
            };

            return _customersRepository.Create(customer);
        }
    }
}
