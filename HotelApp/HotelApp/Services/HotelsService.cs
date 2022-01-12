using HotelApp.Dtos;
using HotelApp.Dtos.Hotel;
using HotelApp.Models;
using HotelApp.Models.Hotels;
using HotelApp.Models.Location;
using HotelApp.Repositories;
using HotelApp.Repositories.Locations;
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
        private CitiesRepository _citiesRepository;

        public HotelsService(HotelsRepository hotelsRepository, CitiesRepository citiesRepository)
        {
            _hotelsRepository = hotelsRepository;
            _citiesRepository = citiesRepository;
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
                Address = hotel.Address,
                TotalRooms = hotel.TotalRooms,
                AllCities = _citiesRepository.GetAll(),
                SelectedCityId = hotel.CityId
            };
            
            return result;
            
        }

        public void Add(HotelViewModel viewModel)
        {
            Hotel hotel = new Hotel()
            {
                Name = viewModel.Name,
                Address = viewModel.Address,
                TotalRooms = viewModel.TotalRooms,
                CityId = viewModel.SelectedCityId
            };

            _hotelsRepository.Create(hotel);
        }

        public void Update(HotelViewModel viewModel)
        {
            City selected = _citiesRepository.GetById(viewModel.SelectedCityId);
            Hotel hotel = _hotelsRepository.GetById(viewModel.Id);

            hotel.Name = viewModel.Name;
            hotel.Address = viewModel.Address;
            hotel.TotalRooms = viewModel.TotalRooms;
            hotel.CityId = viewModel.SelectedCityId;
            hotel.City = selected;

            _hotelsRepository.Update(hotel);
        }

        public void Remove(int hotelId)
        {
            _hotelsRepository.Remove(hotelId);
        }
    }
}
