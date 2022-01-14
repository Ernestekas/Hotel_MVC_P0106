using HotelApp.Dtos.Hotels;
using HotelApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers
{
    public class HotelManagerController : Controller
    {
        private readonly HotelsService _hotelsService;
        private readonly LocationsService _locationsService;
        private readonly RoomsService _roomsService;
        private readonly CustomersService _customersService;

        public HotelManagerController(HotelsService hotelsService, LocationsService locationsService, RoomsService roomsService, CustomersService customersService)
        {
            _hotelsService = hotelsService;
            _locationsService = locationsService;
            _roomsService = roomsService;
            _customersService = customersService;
        }

        public IActionResult HotelManager(int hotelId)
        {
            HotelManagerViewModel viewModel = _hotelsService.GetHotelData(hotelId);
            return View(viewModel);
        }
        public IActionResult OpenRoom(int roomId)
        {
            int hotelId = _roomsService.Open(roomId);
            HotelManagerViewModel viewModel = _hotelsService.GetHotelData(hotelId);

            ViewBag.moveToLocation = "Closed";

            return View("HotelManager", viewModel);
        }

        public IActionResult CloseRoom(int roomId)
        {
            CloseRoomViewModel viewModel = _roomsService.GetCloseModel(roomId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CloseRoom(CloseRoomViewModel viewModel)
        {
            int hotelId = _roomsService.Update(viewModel);
            HotelManagerViewModel vm = _hotelsService.GetHotelData(hotelId);

            ViewBag.moveToLocation = "BookRoom";

            return View("HotelManager", vm);
        }

        public IActionResult BookRoom(int roomId)
        {
            BookRoomViewModel viewModel = _customersService.GetBookRoomModel(roomId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult BookRoom(BookRoomViewModel viewModel)
        {
            _customersService.BookRoom(viewModel);
            HotelManagerViewModel vm = _hotelsService.GetHotelData(viewModel.HotelId);

            ViewBag.moveToLocation = "BookRoom";

            return View("HotelManager", vm);
        }

        public IActionResult FreeTheRoom(int roomId)
        {
            int hotelId = _roomsService.FreeRoom(roomId);
            HotelManagerViewModel vm = _hotelsService.GetHotelData(hotelId);

            ViewBag.moveToLocation = "BookedRooms";

            return View("HotelManager", vm);
        }

        public IActionResult AssignCleaner(int roomId)
        {
            int hotelId = _roomsService.AssignCleaner(roomId);
            HotelManagerViewModel vm = _hotelsService.GetHotelData(hotelId);

            ViewBag.moveToLocation = "CleanIt";

            return View("HotelManager", vm);
        }

        public IActionResult MarkCleaned(int roomId)
        {
            int hotelId = _roomsService.MarkCleaned(roomId);
            HotelManagerViewModel vm = _hotelsService.GetHotelData(hotelId);

            ViewBag.moveToLocation = "CleanIt";

            return View("HotelManager", vm);
        }
    }
}
