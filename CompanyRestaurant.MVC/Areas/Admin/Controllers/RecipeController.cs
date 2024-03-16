using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.RecipeVM;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var recipes = await _recipeRepository.GetAll();
            return View(recipes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeVM model)
        {
            if (ModelState.IsValid)
            {

                string fileName = null;

                // Dosya yükleme işlemleri
                if (model.RecipeImage != null && model.RecipeImage.Length > 0)
                {
                    fileName = Guid.NewGuid().ToString() + "_" + model.RecipeImage.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/recipe", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.RecipeImage.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    // Dosya yükleme hatası için bir hata mesajı ekle
                    ModelState.AddModelError("RecipeImage", "Reçete resmi yüklenmedi.");
                    return View(model);
                }

                var recipe = _mapper.Map<Recipe>(model);

                await _recipeRepository.Create(recipe);

                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var recipe = await _recipeRepository.GetById(id);
            if (recipe == null)
            {
                return NotFound();
            }

            UpdateRecipeVM updateRecipeVM = _mapper.Map<UpdateRecipeVM>(recipe);
            return View(updateRecipeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRecipeVM model)
        {
            if (ModelState.IsValid)
            {
                var recipe = _mapper.Map<Recipe>(model);

                if (recipe == null)
                {
                    return NotFound();
                }

                string fileName = recipe.ImageUrl; // Mevcut resim adını koru

                // Dosya yükleme işlemleri
                if (model.RecipeImage != null && model.RecipeImage.Length > 0)
                {
                    fileName = Guid.NewGuid().ToString() + "_" + model.RecipeImage.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/recipe", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.RecipeImage.CopyToAsync(fileStream);
                    }
                }

                var result = await _recipeRepository.Update(recipe);
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
            var recipe = await _recipeRepository.GetById(id);
            if (recipe == null)
            {
                return NotFound();
            }

            DeleteRecipeVM deleteRecipeVM = _mapper.Map<DeleteRecipeVM>(recipe);

            return View(deleteRecipeVM);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _recipeRepository.GetById(id);
            await _recipeRepository.Destroy(recipe);
            TempData["Message"] = "Reçete başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }


    }
}
