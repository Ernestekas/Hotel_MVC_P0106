using HotelApp.Dtos;
using HotelApp.Dtos.Hotel;
using HotelApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Controllers
{
    public class HotelsController : Controller
    {
        private readonly HotelsService _hotelsService;

        public HotelsController(HotelsService hotelsService)
        {
            _hotelsService = hotelsService;
        }

        public IActionResult All()
        {
            DisplayHotels viewModel = _hotelsService.GetAll();
            return View(viewModel);
        }

        public IActionResult Add()
        {
            CreateHotel newHotel = new CreateHotel();
            return View(newHotel);
        }

        [HttpPost]
        public IActionResult Add(CreateHotel viewModel)
        {
            _hotelsService.Add(viewModel);
            return RedirectToAction(nameof(All));
        }
    }
}
