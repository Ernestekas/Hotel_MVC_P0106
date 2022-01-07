﻿using HotelApp.Dtos;
using HotelApp.Dtos.Hotel;
using HotelApp.Repositories;
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
            JsonReader test = new JsonReader();
            test.LithuanianCities();

            DisplayHotels viewModel = _hotelsService.GetAll();
            return View(viewModel);
        }

        public IActionResult Add()
        {
            HotelViewModel newHotel = new HotelViewModel();
            return View(newHotel);
        }

        [HttpPost]
        public IActionResult Add(HotelViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
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
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _hotelsService.Update(viewModel);
            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int hotelId)
        {
            _hotelsService.Remove(hotelId);
            return RedirectToAction(nameof(All));
        }

        public IActionResult Hotel(int hotelId)
        {
            // Implement more functionality when more details will be added.
            return View(hotelId);
        }
    }
}