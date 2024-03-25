using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.OrderVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] // Yalnızca admin rolüne sahip kullanıcılar erişebilir.
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<OrderViewModel>>(orders);
            return View(model);
        }

        public IActionResult Create()
        {
            // Burada gerekirse kategori, masa ve çalışan seçeneklerini ViewBag ile view'a geçirebilirsiniz.
            return View(new OrderViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = _mapper.Map<Order>(model);
                await _orderRepository.CreateAsync(order);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<OrderViewModel>(order);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = _mapper.Map<Order>(model);
                await _orderRepository.UpdateAsync(order);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<OrderViewModel>(order);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            await _orderRepository.DestroyAsync(order);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<OrderViewModel>(order);
            // Burada siparişe ilişkin detayları ve ödemeleri model'e ekleyebilirsiniz.
            return View(model);
        }

        // Siparişlerin tarih aralığına göre listelenmesi
        public async Task<IActionResult> ListOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            var orders = await _orderRepository.GetOrdersByDateRange(startDate, endDate);
            var model = _mapper.Map<IEnumerable<OrderViewModel>>(orders);
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            return View("Index", model); // Veya uygun bir View'a yönlendirme yapın.
        }

        // Satış raporları oluşturma
        public async Task<IActionResult> GenerateSalesReport(DateTime startDate, DateTime endDate)
        {
            var orders = await _orderRepository.GenerateSalesReport(startDate, endDate);
            // Burada, dönen siparişlerin işlenmesi ve raporun hazırlanması işlemleri gerçekleştirilebilir.
            // Örneğin, toplam satış tutarı hesaplanabilir veya siparişler bir modele dönüştürülüp gösterilebilir.
            var totalSales = orders.Sum(order => order.Price); // Toplam satış tutarını hesapla.
            ViewBag.TotalSales = totalSales;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            var model = _mapper.Map<IEnumerable<OrderViewModel>>(orders);
            return View("SalesReport", model); // Satış raporu için uygun bir View'a yönlendirme yapın.
        }
    }
}
