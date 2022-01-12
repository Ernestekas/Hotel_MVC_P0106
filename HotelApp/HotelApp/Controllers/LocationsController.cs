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

        public IActionResult DeleteCountry(int countryId)
        {
            _locationsService.DeleteCountry(countryId);
            return RedirectToAction(nameof(Manage));
        }

        public IActionResult UpdateCountry(int countryId)
        {
            CountryViewModel viewModel = _locationsService.GetUpdateViewModel(countryId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateCountry(CountryViewModel viewModel)
        {
            _locationsService.UpdateCountry(viewModel);
            return RedirectToAction(nameof(Manage));
        }

        public IActionResult DeleteCity(int cityId)
        {
            int redirectId = _locationsService.DeleteCity(cityId);

            return RedirectToAction(nameof(UpdateCountry), new {countryId = redirectId});
        }
    }
}
