using HotelApp.Dtos.Hotel;
using HotelApp.Dtos.Location;
using HotelApp.Models.Location;
using HotelApp.Repositories.Locations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        public List<City> GetAllCities()
        {
            return _citiesRepository.GetAll();
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

        public void UpdateCountry(CountryViewModel viewModel)
        {
            Country selected = _countriesRepository.GetByIdIncluded(viewModel.Id);

            selected.Name = viewModel.Name;

            for (int i = 0; i < viewModel.CitiesNames.Length; i++)
            {
                selected.Cities[i].Name = viewModel.CitiesNames[i];
            }

            _countriesRepository.Update(selected);
        }

        public int DeleteCity(int cityId)
        {
            int redirectToCountryId;
            City city = _citiesRepository.GetById(cityId);

            redirectToCountryId = city.CountryId;
            
            _citiesRepository.Remove(cityId);

            return redirectToCountryId;
        }
    }
}
