﻿using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.MaterialVM;
using CompanyRestaurant.MVC.Models.RecipeVM;
using CompanyRestaurant.MVC.Models.SupplierVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] // Yalnızca admin rolüne sahip kullanıcılar erişebilir.
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public MaterialController(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var materials = await _materialRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<MaterialViewModel>>(materials);
            return View(model);
        }

        public IActionResult Create()
        {
            // Burada gerekirse malzeme birim tipi seçeneklerini ViewBag ile view'a geçirebilirsiniz.
            return View(new MaterialViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaterialViewModel model)
        {
            if (ModelState.IsValid)
            {
                var material = _mapper.Map<Material>(model);
                await _materialRepository.CreateAsync(material);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var material = await _materialRepository.GetByIdAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<MaterialViewModel>(material);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MaterialViewModel model)
        {
            if (ModelState.IsValid)
            {
                var material = _mapper.Map<Material>(model);
                await _materialRepository.UpdateAsync(material);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var material = await _materialRepository.GetByIdAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<MaterialViewModel>(material);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var models = await _materialRepository.GetByIdAsync(id);
            if (models == null)
            {
                return NotFound();
            }
            await _materialRepository.DestroyAsync(models);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var material = await _materialRepository.GetByIdAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<MaterialViewModel>(material);
            return View(model);
        }

        // Stok raporu ve malzeme stok seviyesi için ekstra işlevler
        public async Task<IActionResult> StockReport()
        {
            var materials = await _materialRepository.GenerateStockReport();
            var model = _mapper.Map<IEnumerable<MaterialViewModel>>(materials);
            return View(model);
        }

        public async Task<IActionResult> MaterialStockLevel(int id)
        {
            var stockLevel = await _materialRepository.GetMaterialStockLevel(id);
            ViewBag.StockLevel = stockLevel;
            // Burada, belirli bir malzemenin stok seviyesini göstermek için uygun bir View'a yönlendirme yapabilirsiniz.
            // Örneğin, malzemenin detay sayfasına geri dönebilirsiniz veya stok seviyesini ayrı bir sayfada gösterebilirsiniz.
            return View();
        }

        public async Task<IActionResult> RecipeDetails(int recipeId)
        {
            var materials = await _materialRepository.GetMaterialsForRecipe(recipeId);
            var model = new RecipeViewModel
            {

                // Reçetenin diğer detayları
                RecipeMaterials = (List<Models.RecipeMaterialVM.RecipeMaterialViewModel>)_mapper.Map<IEnumerable<MaterialViewModel>>(materials)
            };

            return View(model);
        }

    }
}
