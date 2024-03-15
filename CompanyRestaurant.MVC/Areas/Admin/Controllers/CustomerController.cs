using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.Entities.Enums;
using CompanyRestaurant.MVC.Models.ViewModels.CurrentVM;
using CompanyRestaurant.MVC.Models.ViewModels.CustomerVM;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var customers = await _customerRepository.GetAll();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerVM model)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(model);
                var result = await _customerRepository.Create(customer);
                TempData["Result"] = result;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var customer = await _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            UpdateCustomerVM updateCustomerVM = _mapper.Map<UpdateCustomerVM>(customer);
            return View(updateCustomerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCustomerVM model)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(model);

                var result = await _customerRepository.Update(customer);
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
            var customer = await _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            DeleteCustomerVM deleteCustomerVM=_mapper.Map<DeleteCustomerVM>(customer);

            return View(deleteCustomerVM);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _customerRepository.GetById(id);
                await _customerRepository.Destroy(customer);
                TempData["Message"] = "Müşteri başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
