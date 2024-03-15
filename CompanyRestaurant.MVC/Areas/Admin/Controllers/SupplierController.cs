using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;
using CompanyRestaurant.MVC.Models.ViewModels.SupplierVM;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var supplier = await _supplierRepository.GetAll();
            return View(supplier);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSupplierVM model)
        {
            if (ModelState.IsValid)
            {
                var supplier = _mapper.Map<Supplier>(model);
                var result = await _supplierRepository.Create(supplier);
                TempData["Result"] = result;
                return RedirectToAction("Index");

            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var supplier = await _supplierRepository.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }

            UpdateSupplierVM updateSupplierVM = _mapper.Map<UpdateSupplierVM>(supplier);
            return View(updateSupplierVM);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateSupplierVM model)
        {
            if (ModelState.IsValid)
            {
                var supplier = _mapper.Map<Supplier>(model);
                var result = await _supplierRepository.Update(supplier);
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
            var supplier = await _supplierRepository.GetById(id);
            if (supplier == null)
            {
                return NotFound();
            }

            DeleteSupplierVM deleteSupplierVM = _mapper.Map<DeleteSupplierVM>(supplier);
            return View(deleteSupplierVM);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier = await _supplierRepository.GetById(id);
            await _supplierRepository.Destroy(supplier);
            TempData["Message"] = "Ürün başarıyla silindi.";
            return RedirectToAction(nameof(Index));

        }

    }
}
