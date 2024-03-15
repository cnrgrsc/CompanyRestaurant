using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.Entities.Enums;
using CompanyRestaurant.MVC.Models.ViewModels.CurrentVM;
using CompanyRestaurant.MVC.Models.ViewModels.MaterialUnitVM;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaterialUnitController : Controller
    {
        private readonly IMaterialUnitRepository _materialUnitRepository;
        private readonly IMapper _mapper;

        public MaterialUnitController(IMaterialUnitRepository materialUnitRepository, IMapper mapper)
        {
            _materialUnitRepository = materialUnitRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var materialUnits = await _materialUnitRepository.GetAll();
            return View(materialUnits);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMaterialUnitVM model)
        {
            if (ModelState.IsValid)
            {
                var materialUnit = _mapper.Map<MaterialUnit>(model);
                var result = await _materialUnitRepository.Create(materialUnit);
                TempData["Result"] = result;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var materialUnit = await _materialUnitRepository.GetById(id);
            if (materialUnit == null)
            {
                return NotFound();
            }

            UpdateMaterialUnitVM updateMaterialUnitVM = _mapper.Map<UpdateMaterialUnitVM>(materialUnit);
            return View(updateMaterialUnitVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMaterialUnitVM model)
        {
            if (ModelState.IsValid)
            {
                var materialUnit = _mapper.Map<MaterialUnit>(model);

                var result = await _materialUnitRepository.Update(materialUnit);
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
            var materialUnit = await _materialUnitRepository.GetById(id);
            if (materialUnit == null)
            {
                return NotFound();
            }
            DeleteMaterialUnitVM deleteMaterialUnitVM = _mapper.Map<DeleteMaterialUnitVM>(materialUnit);
            return View(deleteMaterialUnitVM);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialUnit = await _materialUnitRepository.GetById(id);
            await _materialUnitRepository.Destroy(materialUnit);
            TempData["Message"] = "Malzeme-Birim başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

    }
}
