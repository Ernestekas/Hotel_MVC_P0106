using HotelApp.Dtos;
using HotelApp.Dtos.Hotels;
using HotelApp.Models;
using HotelApp.Models.Hotels;
using HotelApp.Models.Location;
using HotelApp.Repositories;
using HotelApp.Repositories.Employees;
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
        private EmployeesRepository _employeesRepository;

        public HotelsService(
            HotelsRepository hotelsRepository, 
            CitiesRepository citiesRepository, 
            FloorsRepository floorsRepository, 
            RoomsRepository roomsRepository, 
            EmployeesRepository employeesRepository)
        {
            _hotelsRepository = hotelsRepository;
            _citiesRepository = citiesRepository;
            _floorsRepository = floorsRepository;
            _roomsRepository = roomsRepository;
            _employeesRepository = employeesRepository;
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

        public bool Remove(int hotelId)
        {
            bool result = false;
            Hotel selected = _hotelsRepository.GetHotelWithEmployess(hotelId);

            if (selected.Cleaners.Any())
            {
                _hotelsRepository.Remove(hotelId);
                result = true;
            }
            
            return result;
        }

        public HotelManagerViewModel GetHotelData(int hotelId)
        {
            Hotel hotel = _hotelsRepository.GetById(hotelId);
            hotel.City = _hotelsRepository.GetHotelLocation(hotelId);
            List<Room> hotelRooms = _hotelsRepository.GetHotelRooms(hotelId);

            HotelManagerViewModel viewModel = new HotelManagerViewModel()
            {
                HotelId = hotel.Id,
                HotelName = hotel.Name,
                HotelAddress = $"{hotel.Address}, {hotel.City.Name}, {hotel.City.Country.Name}.",
                Cleaners = _employeesRepository.GetCleanersByHotel(hotelId)
            };

            foreach(var room in hotelRooms)
            {
                if (room.ClosedForCustomers)
                {
                    viewModel.RoomsClosedForOtherReasons.Add(room);
                }
                else if (room.Booked)
                {
                    viewModel.RoomsBooked.Add(room);
                }
                else if (room.Cleaned)
                {
                    viewModel.ReadyRooms.Add(room);
                }
                else
                {
                    viewModel.RoomsNeedsCleaning.Add(room);
                }
            }

            return viewModel;
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
