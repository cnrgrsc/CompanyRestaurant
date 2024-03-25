using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.MVC.Models.DashboardVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMaterialRepository _materialRepository;
        private readonly IRezervationRepository _rezervationRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPerformanceReviewRepository _performanceReviewRepository;

        // Kullanılan repository'lerin constructor üzerinden enjekte edilmesi
        public DashboardController(IOrderRepository orderRepository,
                                   IMaterialRepository materialRepository,
                                   IRezervationRepository rezervationRepository,
                                   IProductRepository productRepository,
                                   IPerformanceReviewRepository performanceReviewRepository)
        {
            _orderRepository = orderRepository;
            _materialRepository = materialRepository;
            _rezervationRepository = rezervationRepository;
            _productRepository = productRepository;
            _performanceReviewRepository = performanceReviewRepository;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new DashboardViewModel();

            // Burada dökümantasyonda belirttiğiniz metrikler ve listeler için
            // ilgili repository metodlarından verileri çekerek viewModel içerisine doldurun.
            // Örnek olarak:

            // Toplam satış miktarı
            var orders = await _orderRepository.GetAllAsync();
            viewModel.TotalSales = orders.Sum(o => o.Price);

            // Bugünkü satış miktarı
            var today = DateTime.Today;
            viewModel.TodaySales = orders.Where(o => o.CreatedDate.Value.Date == today).Sum(o => o.Price);

            // Aktif rezervasyon sayısı
            var rezervations = await _rezervationRepository.GetAllAsync();
            viewModel.ActiveReservations = rezervations.Count(r => r.ReservationDate >= today);

            // Stokta azalan ürün sayısı
            var materials = await _materialRepository.GenerateStockReport();
            viewModel.LowStockProductsCount = materials.Count();

            // Yeni müşteriler, toplam çalışan sayısı gibi diğer metriklerin hesaplanması
            // ve LatestProducts, RecentOrders, LatestPerformanceReviews listelerinin doldurulması
            // ilgili repository metodlarınız ve iş mantığınıza göre değişiklik gösterebilir.

            return View(viewModel);
        }
    }
}
