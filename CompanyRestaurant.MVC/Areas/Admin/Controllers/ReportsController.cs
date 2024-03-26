using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProductRepository _productRepository;
        private readonly IRezervationRepository _rezervationRepository;
        private readonly IPerformanceReviewRepository _performanceReviewRepository;
        private readonly IStockMovementRepository _stockMovementRepository;
        private readonly IMapper _mapper;

        public ReportsController(IOrderRepository orderRepository,
                                 IMaterialRepository materialRepository,
                                 IEmployeeRepository employeeRepository,
                                 IProductRepository productRepository,
                                 IRezervationRepository rezervationRepository,
                                 IPerformanceReviewRepository performanceReviewRepository,
                                 IStockMovementRepository stockMovementRepository,
                                 IMapper mapper)
        {
            _orderRepository = orderRepository;
            _materialRepository = materialRepository;
            _employeeRepository = employeeRepository;
            _productRepository = productRepository;
            _rezervationRepository = rezervationRepository;
            _performanceReviewRepository = performanceReviewRepository;
            _stockMovementRepository = stockMovementRepository;
            _mapper = mapper;
        }

        // Example: Sales Report by Date Range
        public async Task<IActionResult> SalesReportByDateRange(DateTime startDate, DateTime endDate)
        {
            var orders = await _orderRepository.GetOrdersByDateRange(startDate, endDate);
            // Map to ViewModel if needed, then pass to view
            return View(orders);
        }

        // Example: Stock Report
        public async Task<IActionResult> StockReport()
        {
            var materials = await _materialRepository.GenerateStockReport();
            // Map to ViewModel if needed, then pass to view
            return View(materials);
        }

        // Example: Employee Performance Report
        public async Task<IActionResult> EmployeePerformanceReport()
        {
            var employees = await _employeeRepository.GetAllEmployeePerformances();
            // Map to ViewModel if needed, then pass to view
            return View(employees);
        }
        public async Task<IActionResult> ReservationReport()
        {
            var rezervations = await _rezervationRepository.GetAllAsync(); // Assuming GetAllAsync exists or similar
            // Map to ViewModel and return view
            return View(rezervations);
        }

        public async Task<IActionResult> StockMovementReport(DateTime startDate, DateTime endDate)
        {
            var movements = await _stockMovementRepository.GetStockMovementsForPeriod(startDate, endDate);
            // Map to ViewModel and return view

            return View(movements);
        }
    }
}
