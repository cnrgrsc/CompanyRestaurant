using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
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
            var tables = await _tableRepository.GetAllAsync();
            ViewBag.Tables = tables;
            var employees = await _employeeRepository.GetAllAsync();
            ViewBag.Employees = employees;
            var order = await _orderRepository.GetAllAsync();
            return View(order);
        }


        public async Task<IActionResult> Create()
        {
            var tables=await _tableRepository.GetAllAsync();
            ViewBag.tablesSelect = new SelectList(tables, "ID", "TableNo");
            var employees = await _employeeRepository.GetAllAsync();
            ViewBag.employeesSelect = new SelectList(employees, "ID", "Name");
            return View();
        }

    }
}
