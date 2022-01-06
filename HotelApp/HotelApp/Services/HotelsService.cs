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

        public void Add(CreateHotel viewModel)
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
    }
}
