using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.UnitStockVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UnitStockController : Controller
    {
        private readonly IUnitStockRepoistory _unitStockRepoistory;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public UnitStockController(IUnitStockRepoistory unitStockRepoistory, IMaterialRepository materialRepository, IMapper mapper)
        {
            _unitStockRepoistory = unitStockRepoistory;
            _materialRepository = materialRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var unitStocks = await _unitStockRepoistory.GetAll();
            var materials = await _materialRepository.GetAll();
            ViewBag.Materials = materials;
            return View(unitStocks);
        }

        public async Task<IActionResult> Create()
        {
            var materials = await _materialRepository.GetAll();
            ViewBag.MaterialsSelect = new SelectList(materials, "ID", "MaterialName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUnitStockVM model)
        {
            if (ModelState.IsValid)
            {
                var unitStock = _mapper.Map<UnitStock>(model);
                var result = await _unitStockRepoistory.Create(unitStock);
                TempData["Result"] = result;
                return RedirectToAction("Index");
            }
            var materialsReloaded = await _materialRepository.GetAll();
            ViewBag.MaterialsSelect = new SelectList(materialsReloaded, "ID", "MaterialName");
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var materials = await _materialRepository.GetAll();
            ViewBag.MaterialsSelect = new SelectList(materials, "ID", "MaterialName");
            var unitStock = await _unitStockRepoistory.GetById(id);
            if (unitStock == null)
            {
                return NotFound();
            }

            UpdateUnitStockVM updateUnitStockVM = _mapper.Map<UpdateUnitStockVM>(unitStock);
            return View(updateUnitStockVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUnitStockVM model)
        {
            if (ModelState.IsValid)
            {
                var unitStock = _mapper.Map<UnitStock>(model);

                var result = await _unitStockRepoistory.Update(unitStock);
                if (result.Contains("Güncellendi"))
                {
                    TempData["Result"] = result;
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Bir hata oluştu: " + result);
            }
            var materials = await _materialRepository.GetAll();
            ViewBag.MaterialsSelect = new SelectList(materials, "ID", "MaterialName");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var materials = await _materialRepository.GetAll();
            ViewBag.MaterialsSelect = new SelectList(materials, "ID", "MaterialName");
            var unitStock = await _unitStockRepoistory.GetById(id);
            if (unitStock == null)
            {
                return NotFound();
            }

            DeleteUnitStockVM deleteUnitStockVM = _mapper.Map<DeleteUnitStockVM>(unitStock);

            return View(deleteUnitStockVM);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unitStock = await _unitStockRepoistory.GetById(id);
            await _unitStockRepoistory.Destroy(unitStock);
            TempData["Message"] = "Birim-Stok başarıyla silindi.";


            var materials = await _materialRepository.GetAll();
            ViewBag.MaterialsSelect = new SelectList(materials, "ID", "MaterialName");
            return RedirectToAction(nameof(Index));
        }
    }
}
