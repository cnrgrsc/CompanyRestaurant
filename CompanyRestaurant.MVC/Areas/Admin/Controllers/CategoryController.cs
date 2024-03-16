using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.Entities.Enums;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.CategoryVM;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAll();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVM model)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(model);

                var result = await _categoryRepository.Create(category);
                TempData["Result"] = result;
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            UpdateCategoryVM updateCategoryVM = _mapper.Map<UpdateCategoryVM>(category);
            return View(updateCategoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryVM model)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(model);

                var result = await _categoryRepository.Update(category);
                if (result.Contains("Güncellendi"))
                {
                    TempData["Result"] = result;
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Bir hata oluştu: " + result);
            }
            return View(model);
        }

        // GET metodu, silme onay sayfasını gösterir
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetById(id);
            DeleteCategoryVM deleteCategoryVM = _mapper.Map<DeleteCategoryVM>(category);
            return View(deleteCategoryVM);
        }

        // POST metodu, silme işlemini gerçekleştirir
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _categoryRepository.GetById(id);
            await _categoryRepository.Destroy(category);
            TempData["Message"] = "Kategori başarıyla silindi.";
            return RedirectToAction("Index");
        }

    }
}
