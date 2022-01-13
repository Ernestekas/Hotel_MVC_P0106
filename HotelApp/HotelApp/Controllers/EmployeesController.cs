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
            CleanerViewModel viewModel = _employeesService.CreateViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(CleanerViewModel viewModel)
        {
            _employeesService.Create(viewModel);

            return RedirectToAction(nameof(All));
        }

        public IActionResult Update(int empId)
        {
            CleanerViewModel viewModel = _employeesService.CreateViewModel(empId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(CleanerViewModel viewModel)
        {
            _employeesService.Update(viewModel);
            return RedirectToAction(nameof(All));
        }

        public IActionResult Delete(int empId)
        {
            _employeesService.Delete(empId);
            return RedirectToAction(nameof(All));
        }
    }
}
