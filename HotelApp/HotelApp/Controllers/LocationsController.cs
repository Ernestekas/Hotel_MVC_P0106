using HotelApp.Dtos.Location;
using HotelApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers
{
    public class LocationsController : Controller
    {
        private readonly LocationsService _locationsService;

        public LocationsController(LocationsService locationsService)
        {
            _locationsService = locationsService;
        }
        public IActionResult Manage()
        {
            LocationsModel locViewModel = _locationsService.GetAll();
            return View(locViewModel);
        }

        public IActionResult AddCountry()
        {
            CountryViewModel countryViewModel = new CountryViewModel();
            return View(countryViewModel);
        }

        [HttpPost]
        public void AddCountry(CountryViewModel viewModel)
        {
            _locationsService.Create(viewModel);
        }
    }
}
