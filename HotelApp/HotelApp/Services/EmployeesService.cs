using HotelApp.Dtos.Employees;
using HotelApp.Models.Employees;
using HotelApp.Models.Hotels;
using HotelApp.Repositories;
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
        private HotelsRepository _hotelsRepository;

        public EmployeesService(EmployeesRepository employeesRepository, HotelsRepository hotelsRepository)
        {
            _employeesRepository = employeesRepository;
            _hotelsRepository = hotelsRepository;
        }

        public AllEmployeesViewModel GetAll()
        {
            AllEmployeesViewModel result = new AllEmployeesViewModel()
            {
                Cleaners = _employeesRepository.GetAllIncluedeHotel()
            };
            
            return result;
        }

        public CleanerViewModel CreateViewModel(int empId = 0)
        {
            Cleaner cleaner = _employeesRepository.GetById(empId);
            List<Hotel> hotels = _hotelsRepository.GetAllWithLocations();
            
            CleanerViewModel result = new CleanerViewModel()
            {
                AllHotels = hotels
            };

            if (cleaner != null)
            {
                result.Id = cleaner.Id;
                result.FirstName = cleaner.FirstName;
                result.LastName = cleaner.LastName;
                result.SelectedHotelId = cleaner.HotelId;
            }

            return result;
        }

        public void Create(CleanerViewModel viewModel)
        {
            Cleaner newCleaner = new Cleaner()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                HotelId = viewModel.SelectedHotelId
            };

            _employeesRepository.Create(newCleaner);
        }

        public void Update(CleanerViewModel viewModel)
        {
            Cleaner cleaner = _employeesRepository.GetById(viewModel.Id);
            cleaner.FirstName = viewModel.FirstName;
            cleaner.LastName = viewModel.LastName;
            cleaner.HotelId = viewModel.SelectedHotelId;

            _employeesRepository.Update(cleaner);
        }

        public void Delete(int empId)
        {
            _employeesRepository.Remove(empId);
        }
    }
}
