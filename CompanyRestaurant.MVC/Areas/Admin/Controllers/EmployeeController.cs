using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.EmployeeVM;
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
            var employees = await _employeeRepository.GetAll();
            var model = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(model);
                await _employeeRepository.Create(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<EmployeeViewModel>(employee);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employee>(model);
                await _employeeRepository.Update(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<EmployeeViewModel>(employee);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            await _employeeRepository.Delete(employee);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<EmployeeViewModel>(employee);
            return View(model);
        }
    }
}
