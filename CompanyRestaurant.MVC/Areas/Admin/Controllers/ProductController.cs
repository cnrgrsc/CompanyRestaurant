using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.ProductVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize] // Yalnızca admin rolüne sahip kullanıcılar erişebilir.
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
		private readonly ICategoryRepository _categoryRepository;
		private readonly IRecipeRepository _recipeRepository;
		private readonly IMapper _mapper;
        
        public ProductController(IProductRepository productRepository,ICategoryRepository categoryRepository,IRecipeRepository recipeRepository,IMapper mapper)
        {
            _productRepository = productRepository;
			_categoryRepository = categoryRepository;
			_recipeRepository = recipeRepository;
			_mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
			var categories = await _categoryRepository.GetAllAsync();
			ViewBag.Categories = categories;
			var recipes = await _recipeRepository.GetAllAsync();
			ViewBag.Recipes = recipes;
			var model = _mapper.Map<IEnumerable<ProductViewModel>>(products);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
			// Kategori ve reçete seçeneklerini burada ViewBag ile view'a geçirebilirsiniz.
			var categories = await _categoryRepository.GetAllAsync();
			ViewBag.CategoriesSelect = new SelectList(categories, "ID", "CategoryName");
			var recipes = await _recipeRepository.GetAllAsync();
			ViewBag.EmployeesSelect = new SelectList(recipes, "ID", "RecipeName");
			return View(new ProductViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName = null;

                // Dosya yükleme işlemleri
                if (model.ProductImage != null && model.ProductImage.Length > 0)
                {
                    fileName = Guid.NewGuid().ToString() + "_" + model.ProductImage.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/product", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ProductImage.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    // Dosya yükleme hatası için bir hata mesajı ekle
                    ModelState.AddModelError("ProductImage", "Ürün resmi yüklenmedi.");
                    // Kategorileri tekrar yükle
                    var categories = await _categoryRepository.GetAllAsync();
                    ViewBag.CategoriesSelect = new SelectList(categories, "ID", "CategoryName");
                    var recipes = await _recipeRepository.GetAllAsync();
                    ViewBag.EmployeesSelect = new SelectList(recipes, "ID", "RecipeName");
                    return View(model);
                }


                var product = _mapper.Map<Product>(model);
                await _productRepository.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }

			var categoriesReloaded = await _categoryRepository.GetAllAsync();
			ViewBag.CategoriesSelect = new SelectList(categoriesReloaded, "ID", "CategoryName");
			var recipesReloaded = await _recipeRepository.GetAllAsync();
			ViewBag.RecipesSelect = new SelectList(recipesReloaded, "ID", "RecipeName");
			return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
			var categories = await _categoryRepository.GetAllAsync();
			ViewBag.CategoriesSelect = new SelectList(categories, "ID", "CategoryName");
			var recipes = await _recipeRepository.GetAllAsync();
			ViewBag.EmployeesSelect = new SelectList(recipes, "ID", "RecipeName");
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


                string fileName = product.ImageUrl; // Mevcut resim adını koru

                // Dosya yükleme işlemleri
                if (model.ProductImage != null && model.ProductImage.Length > 0)
                {
                    fileName = Guid.NewGuid().ToString() + "_" + model.ProductImage.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/product", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ProductImage.CopyToAsync(fileStream);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
			var categories = await _categoryRepository.GetAllAsync();
			ViewBag.CategoriesSelect = new SelectList(categories, "ID", "CategoryName");
			var recipes = await _recipeRepository.GetAllAsync();
			ViewBag.EmployeesSelect = new SelectList(recipes, "ID", "RecipeName");
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
