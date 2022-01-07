using HotelApp.Dtos;
using HotelApp.Dtos.Hotel;
using HotelApp.Models;
using HotelApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Services
{
    public class HotelsService
    {
        private HotelsRepository _hotelsRepository;

        public HotelsService(HotelsRepository hotelsRepository)
        {
            _hotelsRepository = hotelsRepository;
        }

        public DisplayHotels GetAll()
        {
            List<Hotel> hotels = _hotelsRepository.GetAll();

            DisplayHotels result = new DisplayHotels()
            {
                HotelsIds = hotels.Select(h => h.Id).ToList(),
                HotelsNames = hotels.Select(h => h.Name).ToList()
            };

            return result;
        }

        public HotelViewModel GetById(int hotelId)
        {
            Hotel hotel = _hotelsRepository.GetById(hotelId);
            HotelViewModel result = new HotelViewModel()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                City = hotel.City,
                Address = hotel.Address,
                TotalRooms = hotel.TotalRooms
            };
            
            return result;
            
        }

        public void Add(HotelViewModel viewModel)
        {
            Hotel hotel = new Hotel()
            {
                Name = viewModel.Name,
                City = viewModel.City,
                Address = viewModel.Address,
                TotalRooms = viewModel.TotalRooms
            };

            _hotelsRepository.Create(hotel);
        }

        public void Update(HotelViewModel viewModel)
        {
            Hotel hotel = _hotelsRepository.GetById(viewModel.Id);
            hotel.Name = viewModel.Name;
            hotel.City = viewModel.City;
            hotel.Address = viewModel.Address;
            hotel.TotalRooms = viewModel.TotalRooms;

            _hotelsRepository.Update(hotel);
        }

        public void Remove(int hotelId)
        {
            _hotelsRepository.Remove(hotelId);
        }
    }
}
