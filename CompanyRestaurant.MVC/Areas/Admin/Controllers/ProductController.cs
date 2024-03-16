using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Common.Image;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.ProductVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAll();
            var categories = await _categoryRepository.GetAll();
            //var categories = new SelectList(await _categoryRepository.GetAll(), "ID", "CategoryName");
            ViewBag.Categories = categories;
            return View(products);

        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryRepository.GetAll();
            ViewBag.CategoriesSelect = new SelectList(categories, "ID", "CategoryName");
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductVM model)
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
                    var categories = await _categoryRepository.GetAll();
                    ViewBag.CategoriesSelect = new SelectList(categories, "ID", "CategoryName");
                    return View(model);
                }


                var product = _mapper.Map<Product>(model);

                var result=await _productRepository.Create(product);
                TempData["Result"] = result;
                // Başarılı kayıttan sonra yönlendirme
                return RedirectToAction("Index");
            }

            // Form doğrulama başarısız olursa, kategorileri tekrar yükle
            var categoriesReloaded = await _categoryRepository.GetAll();
            ViewBag.CategoriesSelect = new SelectList(categoriesReloaded, "ID", "CategoryName");
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var categories = await _categoryRepository.GetAll();
            ViewBag.CategoriesSelect = new SelectList(categories, "ID", "CategoryName");
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            UpdateProductVM updateProductVM=_mapper.Map<UpdateProductVM>(product);

            return View(updateProductVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductVM model)
        {
            if (ModelState.IsValid)
            {

                var product = _mapper.Map<Product>(model);
                 await _productRepository.Update(product);
                if (product == null)
                {
                    return NotFound();
                }

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

                

                // İşlem başarılıysa, başka bir sayfaya yönlendir
                return RedirectToAction("Index");
            }

            // ModelState.IsValid false ise formu tekrar göster
            // Kategorileri tekrar yükle
            var categories = await _categoryRepository.GetAll();
            ViewBag.CategoriesSelect = new SelectList(categories, "ID", "CategoryName");

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            DeleteProductVM deleteProductVM=_mapper.Map<DeleteProductVM>(product);

            return View(deleteProductVM);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed (int id)
        {
            var product = await _productRepository.GetById(id);
                await _productRepository.Destroy(product);
                TempData["Message"] = "Ürün başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

    }
}
