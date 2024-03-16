using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.MaterialVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public MaterialController(IMaterialRepository materialRepository, ISupplierRepository supplierRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var material = await _materialRepository.GetAll();
            var suppliers = await _supplierRepository.GetAll();
            ViewBag.Suppliers = suppliers;
            return View(material);
        }

        public async Task<IActionResult> Create()
        {
            var suppliers = await _supplierRepository.GetAll();
            ViewBag.SuppliersSelect = new SelectList(suppliers, "ID", "CompanyName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMaterialVM model)
        {
            if (ModelState.IsValid)
            {
                var material = _mapper.Map<Material>(model);
                await _materialRepository.Create(material);
                return RedirectToAction("Index");
            }
            var suppliersReloaded = await _supplierRepository.GetAll();
            ViewBag.SuppliersSelect = new SelectList(suppliersReloaded, "ID", "CompanyName");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var suppliers = await _supplierRepository.GetAll();
            ViewBag.SuppliersSelect = new SelectList(suppliers, "ID", "CompanyName");
            var material = await _materialRepository.GetById(id);
            if (material == null)
            {
                return NotFound();
            }
            UpdateMaterialVM updateMaterialVM = _mapper.Map<UpdateMaterialVM>(material);
            return View(updateMaterialVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateMaterialVM model)
        {
            if (ModelState.IsValid)
            {
                var material = _mapper.Map<Material>(model);
                var result = await _materialRepository.Update(material);
                if (result.Contains("Güncellendi"))
                {
                    TempData["Result"] = result;
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Bir hata oluştu: " + result);

            }

            var suppliers = await _supplierRepository.GetAll();
            ViewBag.SuppliersSelect = new SelectList(suppliers, "ID", "CompanyName");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var material = await _materialRepository.GetById(id);
            if (material == null)
            {
                return NotFound();
            }


            DeleteMaterialVM deleteMaterialVM = _mapper.Map<DeleteMaterialVM>(material);
            return View(Delete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var material = await _materialRepository.GetById(id);
            await _materialRepository.Destroy(material);
            TempData["Message"] = "Ürün başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }


    }
}
