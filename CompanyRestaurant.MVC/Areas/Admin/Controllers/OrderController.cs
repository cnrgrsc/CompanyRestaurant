using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.OrderVM;
using CompanyRestaurant.MVC.Models.ViewModels.EmployeeVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository,ITableRepository tableRepository,IEmployeeRepository employeeRepository,IMapper mapper)
        {
            _orderRepository = orderRepository;
            _tableRepository = tableRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var tables = await _tableRepository.GetAll();
            ViewBag.Tables = tables;
            var employees = await _employeeRepository.GetAll();
            ViewBag.Employees = employees;
            var order = await _orderRepository.GetAll();
            return View(order);
        }


        public async Task<IActionResult> Create()
        {
            var tables=await _tableRepository.GetAll();
            ViewBag.tablesSelect = new SelectList(tables, "ID", "TableNo");
            var employees = await _employeeRepository.GetAll();
            ViewBag.employeesSelect = new SelectList(employees, "ID", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderVM model)
        {
            if (ModelState.IsValid)
            {
                var order=_mapper.Map<Order>(model);
                await _orderRepository.Create(order);
                return RedirectToAction("Index");
            }

            var tablesReloaded=await _tableRepository.GetAll();
            ViewBag.tablesSelect = new SelectList(tablesReloaded, "ID", "TableNo");
            var employeesReloaded=await _employeeRepository.GetAll();
            ViewBag.employeesSelect = new SelectList(employeesReloaded, "ID", "Name");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var tablesReloaded = await _tableRepository.GetAll();
            ViewBag.tablesSelect = new SelectList(tablesReloaded, "ID", "TableNo");
            var employeesReloaded = await _employeeRepository.GetAll();
            ViewBag.employeesSelect = new SelectList(employeesReloaded, "ID", "Name");
            var order = await _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            UpdateOrderVM updateOrderVM=_mapper.Map<UpdateOrderVM>(order);
            return View(updateOrderVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateOrderVM model)
        {
            if (ModelState.IsValid)
            {
                var order = _mapper.Map<Order>(model);
                var result = await _orderRepository.Update(order);
                if (result.Contains("Güncellendi"))
                {
                    TempData["Result"] = result;
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Bir hata oluştu: " + result);
            }
            var tablesReloaded = await _tableRepository.GetAll();
            ViewBag.tablesSelect = new SelectList(tablesReloaded, "ID", "TableNo");
            var employeesReloaded = await _employeeRepository.GetAll();
            ViewBag.employeesSelect = new SelectList(employeesReloaded, "ID", "Name");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
          
            var order = await _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            DeleteOrderVM deleteOrderVM = _mapper.Map<DeleteOrderVM>(order);
            return View(deleteOrderVM);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _orderRepository.GetById(id);
            await _orderRepository.Destroy(order);
            TempData["Message"] = "Sipariş başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

    }
}
