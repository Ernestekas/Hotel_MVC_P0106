using HotelApp.Dtos.Hotels;
using HotelApp.Models.Custormers;
using HotelApp.Models.Employees;
using HotelApp.Models.Hotels;
using HotelApp.Repositories;
using HotelApp.Repositories.Customers;
using HotelApp.Repositories.Employees;
using HotelApp.Repositories.Hotels;
using System;
using System.Collections.Generic;

namespace HotelApp.Services
{
    public class RoomsService
    {
        private RoomsRepository _roomsRepository;
        private HotelsRepository _hotelsRepository;
        private CustomersRepository _customerRepository;
        private EmployeesRepository _employeesRepository;

        public RoomsService(RoomsRepository roomsRepository, HotelsRepository hotelsRepository, CustomersRepository customerRepository, EmployeesRepository employeesRepository)
        {
            _roomsRepository = roomsRepository;
            _hotelsRepository = hotelsRepository;
            _customerRepository = customerRepository;
            _employeesRepository = employeesRepository;
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

        public int AssignCleaner(int roomId)
        {
            Random random = new Random();

            int hotelId = _roomsRepository.GetHotelByRoomId(roomId);
            Room room = _roomsRepository.GetById(roomId);
            List<Cleaner> cleaners = _employeesRepository.GetCleanersByHotel(hotelId);

            room.CleanerId = cleaners[random.Next(cleaners.Count)].Id;
            room.CleanerAssigned = true;

            _roomsRepository.Update(room);

            return hotelId;
        }

        public int MarkCleaned(int roomId)
        {
            int hotelId = _roomsRepository.GetHotelByRoomId(roomId);
            Room room = _roomsRepository.GetById(roomId);

            room.Cleaned = true;
            room.CleanerAssigned = false;
            room.CleanerId = null;

            _roomsRepository.Update(room);

            return hotelId;
        }
    }
}
