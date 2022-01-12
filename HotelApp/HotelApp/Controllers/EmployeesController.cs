using HotelApp.Dtos.Employees;
using HotelApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeesService _employeesService;

        public EmployeesController(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public IActionResult All()
        {
            AllEmployeesViewModel viewModel = _employeesService.GetAll();
            return View(viewModel);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
