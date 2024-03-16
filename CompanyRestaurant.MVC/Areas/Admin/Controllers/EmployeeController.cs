using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.EmployeeVM;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var employee = await _employeeRepository.GetAll();
            return View(employee);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeVM model)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(model);
                var result = await _employeeRepository.Create(employee);
                TempData["Result"] = result;
                return RedirectToAction("Index");

            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            UpdateEmployeeVM updateEmployeeVM = _mapper.Map<UpdateEmployeeVM>(employee);
            return View(updateEmployeeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateEmployeeVM model)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(model);
                var result = await _employeeRepository.Update(employee);
                if (result.Contains("Güncellendi"))
                {
                    TempData["Result"] = result;
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Bir hata oluştu: " + result);
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            DeleteEmployeeVM deleteEmployeeVM = _mapper.Map<DeleteEmployeeVM>(employee);
            return View(deleteEmployeeVM);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            await _employeeRepository.Destroy(employee);
            TempData["Message"] = "Ürün başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }


    }
}
