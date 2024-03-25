using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.ProductVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] // Yalnızca admin rolüne sahip kullanıcılar erişebilir.
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<ProductViewModel>>(products);
            return View(model);
        }

        public IActionResult Create()
        {
            // Kategori ve reçete seçeneklerini burada ViewBag ile view'a geçirebilirsiniz.
            return View(new ProductViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                await _productRepository.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<ProductViewModel>(product);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = _mapper.Map<Product>(model);
                await _productRepository.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<ProductViewModel>(product);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productRepository.DestroyAsync(product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<ProductViewModel>(product);
            return View(model);
        }

        // Ürün satışı için ekstra metod
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SellProduct(int productId, int quantity)
        {
            try
            {
                await _productRepository.SellProduct(productId, quantity);
                // Satış işlemi başarılıysa kullanıcıyı bilgilendir
                // Bu örnekte doğrudan Index sayfasına yönlendirme yapılmıştır, gerekirse başarılı işlem bilgisi de gösterilebilir.
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                // Hata yönetimi
                ModelState.AddModelError("", ex.Message);
                return View("Error"); // Hata mesajını gösterecek bir Error view'ınız olduğunu varsayıyorum.
            }
        }
    }
}
