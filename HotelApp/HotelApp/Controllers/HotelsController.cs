using HotelApp.Dtos;
using HotelApp.Dtos.Hotels;
using HotelApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers
{
    public class HotelsController : Controller
    {
        private readonly HotelsService _hotelsService;
        private readonly LocationsService _locationsService;

        public HotelsController(HotelsService hotelsService, LocationsService locationsService)
        {
            _hotelsService = hotelsService;
            _locationsService = locationsService;
        }

        public IActionResult All(string errorMessage = "")
        {
            DisplayHotels viewModel = _hotelsService.GetAll();
            ViewBag.ErrorMessage = errorMessage;
            return View(viewModel);
        }

        public IActionResult Add()
        {
            HotelViewModel newHotel = new HotelViewModel()
            {
                AllCities = _locationsService.GetAllCities()
            };

            return View(newHotel);
        }

        [HttpPost]
        public IActionResult Add(HotelViewModel viewModel)
        {
            if(viewModel.TotalRooms > viewModel.FloorsCount * viewModel.RoomsPerFloor)
            {
                ModelState.AddModelError("TotalRooms", "This building can't fit this much rooms.");
            }

            if (!ModelState.IsValid)
            {
                viewModel.AllCities = _locationsService.GetAllCities();
                return View(viewModel);
            }

            _hotelsService.Add(viewModel);
            return RedirectToAction(nameof(All));
        }

        public IActionResult Update(int hotelId)
        {
            HotelViewModel viewModel = _hotelsService.GetById(hotelId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(HotelViewModel viewModel)
        {
            if (viewModel.TotalRooms > viewModel.FloorsCount * viewModel.RoomsPerFloor)
            {
                ModelState.AddModelError("TotalRooms", "This building can't fit this much rooms.");
            }

            if (!ModelState.IsValid)
            {
                viewModel.AllCities = _locationsService.GetAllCities();
                return View(viewModel);
            }

            _hotelsService.Update(viewModel);
            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int hotelId)
        {
            bool result = _hotelsService.Remove(hotelId);
            if (!result)
            {
                string message = "Hotel not removed. There is still employees assigned to this hotel.";
                return RedirectToAction(nameof(All), message);
            }
            return RedirectToAction(nameof(All));
        }
    }
}
