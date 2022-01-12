using HotelApp.Dtos;
using HotelApp.Dtos.Hotel;
using HotelApp.Models;
using HotelApp.Models.Hotels;
using HotelApp.Models.Location;
using HotelApp.Repositories;
using HotelApp.Repositories.Hotels;
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
        private FloorsRepository _floorsRepository;
        private RoomsRepository _roomsRepository;

        public HotelsService(HotelsRepository hotelsRepository, CitiesRepository citiesRepository, FloorsRepository floorRepository, RoomsRepository roomsRepository)
        {
            _hotelsRepository = hotelsRepository;
            _citiesRepository = citiesRepository;
            _floorsRepository = floorRepository;
            _roomsRepository = roomsRepository;
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
            Hotel hotel = _hotelsRepository.GetByIdIncludeFloors(hotelId);
            HotelViewModel result = new HotelViewModel()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Address = hotel.Address,
                TotalRooms = hotel.TotalRooms,
                AllCities = _citiesRepository.GetAll(),
                SelectedCityId = hotel.CityId,
                FloorsCount = hotel.Floors.Count,
                RoomsPerFloor = hotel.Floors[0].Rooms.Count
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

            int hotelId = _hotelsRepository.Create(hotel);

            List<Floor> floors = CreateFloors(viewModel.FloorsCount, hotelId);

            CreateRooms(viewModel.TotalRooms, viewModel.RoomsPerFloor, floors);
        }

        public void Update(HotelViewModel viewModel)
        {
            City selected = _citiesRepository.GetById(viewModel.SelectedCityId);
            Hotel hotel = _hotelsRepository.GetById(viewModel.Id);

            hotel.Name = viewModel.Name;
            hotel.Address = viewModel.Address;
            hotel.CityId = viewModel.SelectedCityId;
            hotel.City = selected;

            _hotelsRepository.Update(hotel);
        }

        public void Remove(int hotelId)
        {
            _hotelsRepository.Remove(hotelId);
        }

        private List<Floor> CreateFloors(int totalFloors, int hotelId)
        {
            List<Floor> floors = new List<Floor>();
            
            for(int f = 1; f <= totalFloors; f++)
            {
                Floor floor = new Floor()
                {
                    HotelId = hotelId,
                    BuildingFloor = f
                };
                floors.Add(floor);
            }

            _floorsRepository.CreateRange(floors);
            return _floorsRepository.GetAllByHotelId(hotelId);
        }

        private void CreateRooms(int totalRooms, int roomsPerFloor, List<Floor> hotelFloors)
        {
            foreach(Floor floor in hotelFloors)
            {
                List<Room> rooms = new List<Room>();
                for(int r = 1; r <= roomsPerFloor && totalRooms > 0; r++)
                {
                    Room room = new Room()
                    {
                        Name = floor.BuildingFloor.ToString() + r.ToString(),
                        FloorId = floor.Id
                    };
                    
                    rooms.Add(room);
                    totalRooms--;
                }
                _roomsRepository.CreateRange(rooms);
            }
        }
    }
}
