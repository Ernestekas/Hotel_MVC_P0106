using HotelApp.Dtos.Hotels;
using HotelApp.Models.Custormers;
using HotelApp.Models.Hotels;
using HotelApp.Repositories;
using HotelApp.Repositories.Customers;
using HotelApp.Repositories.Hotels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Services
{
    public class RoomsService
    {
        private RoomsRepository _roomsRepository;
        private HotelsRepository _hotelsRepository;
        private CustomersRepository _customerRepository;

        public RoomsService(RoomsRepository roomsRepository, HotelsRepository hotelsRepository, CustomersRepository customerRepository)
        {
            _roomsRepository = roomsRepository;
            _hotelsRepository = hotelsRepository;
            _customerRepository = customerRepository;
        }

        public int Open(int roomId)
        {
            int hotelId = _roomsRepository.GetHotelByRoomId(roomId);
            Room room = _roomsRepository.GetById(roomId);
            room.ClosedForCustomers = false;
            room.ClosedReason = "";

            _roomsRepository.Update(room);
            return hotelId;
        }

        public CloseRoomViewModel GetCloseModel(int roomId)
        {
            CloseRoomViewModel viewModel = new CloseRoomViewModel()
            {
                HotelId = _roomsRepository.GetHotelByRoomId(roomId),
                RoomId = roomId,
                RoomName = _roomsRepository.GetById(roomId).Name,
                CloseReason = ""
            };

            Hotel hotel = _hotelsRepository.GetById(viewModel.HotelId);
            viewModel.HotelName = hotel.Name;

            return viewModel;
        }

        public int Update(CloseRoomViewModel viewModel)
        {
            Room room = _roomsRepository.GetById(viewModel.RoomId);
            room.ClosedReason = viewModel.CloseReason;
            room.ClosedForCustomers = true;

            _roomsRepository.Update(room);
            return viewModel.HotelId;
        }

        public int FreeRoom(int roomId)
        {
            int hotelId = _roomsRepository.GetHotelByRoomId(roomId);

            Room room = _roomsRepository.GetByIdIncludeCustomer(roomId);
            Customer customer = room.Customer;

            customer.Requests = "";
            room.Booked = false;
            room.Cleaned = false;

            _customerRepository.Remove(customer.Id);
            _roomsRepository.Update(room);
            return hotelId;
        }
    }
}
