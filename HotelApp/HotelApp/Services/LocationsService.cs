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
            LocationsModel result = new LocationsModel();
            List<Country> countries = _countriesRepository.GetAllIncluded();

            result.CountriesIds = countries.Select(x => x.Id).ToList();
            result.CountriesNames = countries.Select(x => x.Name).ToList();

            foreach (var country in countries)
            {
                result.CountriesCitiesCount.Add(country.Cities.Count);
            }

            return result;
        }

        public void Create(CountryViewModel viewModel)
        {
            List<City> newCities = new List<City>();
            
            Country newCountry = new Country()
            {
                Name = viewModel.Name
            };
            
            int countryId = _countriesRepository.Create(newCountry);

            foreach (var cityName in viewModel.CitiesNames)
            {
                if(!string.IsNullOrWhiteSpace(cityName))
                {
                    City newCity = new City()
                    {
                        Name = cityName,
                        CountryId = countryId
                    };

                    newCities.Add(newCity);
                }
            }
            
            _citiesRepository.CreateRange(newCities);
        }

        public void DeleteCountry(int countryId)
        {
            Country selected = _countriesRepository.GetByIdIncluded(countryId);
            _citiesRepository.RemoveRange(selected.Cities);
            _countriesRepository.Remove(selected.Id);
        }

        public CountryViewModel GetUpdateViewModel(int countryId)
        {
            Country selected = _countriesRepository.GetByIdIncluded(countryId);
            CountryViewModel result = new CountryViewModel()
            {
                Id = selected.Id,
                Name = selected.Name,
                CitiesIds = selected.Cities.Select(ct => ct.Id).ToList(),
                CitiesNames = selected.Cities.Select(ct => ct.Name).ToArray()
            };

            return result;
        }

        public bool UpdateCountry(CountryViewModel viewModel)
        {
            bool success = false;
            Country selected = _countriesRepository.GetByIdIncluded(viewModel.Id);

            return success;
        }

        private bool UpdateCountryName(Country country, string name)
        {
            bool success = false;

            return success;
        }
    }
}
