using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.Entities.Enums;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.MaterialPriceVM;
using CompanyRestaurant.MVC.Models.ViewModels.CurrentVM;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaterialPriceController : Controller
    {
        private readonly IMaterialPriceRepository _materialPriceRepository;
        private readonly IMapper _mapper;

        public MaterialPriceController(IMaterialPriceRepository materialPriceRepository, IMapper mapper)
        {
            _materialPriceRepository = materialPriceRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var materialPrice = await _materialPriceRepository.GetAll();
            return View(materialPrice);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMaterialPriceVM model)
        {
            if (ModelState.IsValid)
            {
                var materialPrice = _mapper.Map<MaterialPrice>(model);
                var result = await _materialPriceRepository.Create(materialPrice);
                TempData["Result"] = result;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var materialPrice = await _materialPriceRepository.GetById(id);
            if (materialPrice == null)
            {
                return NotFound();
            }

            UpdateMaterialPriceVM updateMaterialPriceVM = _mapper.Map<UpdateMaterialPriceVM>(materialPrice);
            return View(updateMaterialPriceVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMaterialPriceVM model)
        {
            if (ModelState.IsValid)
            {

                var materialPrice = _mapper.Map<MaterialPrice>(model);

                var result = await _materialPriceRepository.Update(materialPrice);
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
            var materialPrice = await _materialPriceRepository.GetById(id);
            if (materialPrice == null)
            {
                return NotFound();
            }

            DeleteMaterialPriceVM deleteMaterialPriceVM = _mapper.Map<DeleteMaterialPriceVM>(materialPrice);
            return View(deleteMaterialPriceVM);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialPrice = await _materialPriceRepository.GetById(id);
            await _materialPriceRepository.Destroy(materialPrice);
            TempData["Message"] = "Malzeme-Fiyat başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
