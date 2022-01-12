using HotelApp.Dtos.Employees;
using HotelApp.Models.Employees;
using HotelApp.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Services
{
    public class EmployeesService
    {
        private EmployeesRepository _employeesRepository;

        public EmployeesService(EmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public AllEmployeesViewModel GetAll()
        {
            AllEmployeesViewModel result = new AllEmployeesViewModel()
            {
                Cleaners = _employeesRepository.GetAll()
            };
            
            return result;
        }

        public CreateCleanerViewModel Add()
        {
            CreateCleanerViewModel result = new CreateCleanerViewModel()
            {

            };

            return result;
        }

    }
}
