using HotelApp.Dtos.Location;
using HotelApp.Models.Location;
using HotelApp.Repositories.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Services
{
    public class LocationsService
    {
        private CountriesRepository _countriesRepository;
        private CitiesRepository _citiesRepository;

        public LocationsService(CountriesRepository countriesRepository, CitiesRepository citiesRepository)
        {
            _countriesRepository = countriesRepository;
            _citiesRepository = citiesRepository;
        }

        public LocationsModel GetAll()
        {
            List<Country> countries = _countriesRepository.GetAll();
            return new LocationsModel() 
            { 
                CountriesIds = countries.Select(x => x.Id).ToList(), 
                CountriesNames = countries.Select(x => x.Name).ToList()
            };
        }
    }
}
