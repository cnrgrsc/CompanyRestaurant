using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.MaterialVM;
using CompanyRestaurant.MVC.Models.SupplierVM;
using Microsoft.AspNetCore.Mvc;

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
            var materials = await _materialRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<MaterialViewModel>>(materials); // Eğer MaterialViewModel kullanıyorsanız
                                                                                // ViewBag ile tedarikçi bilgilerini görünüme aktar
            var suppliers = await _supplierRepository.GetAllAsync();
            ViewBag.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(suppliers); // Eğer SupplierViewModel kullanıyorsanız
            return View(model);
        }

        // Malzeme ekleme sayfasını göster
        public IActionResult Create()
        {
            // Ekleme işlemi için gerekli olan tedarikçi bilgilerini ViewBag ile taşıyabiliriz.
            var suppliersTask = _supplierRepository.GetAllAsync();
            ViewBag.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(suppliersTask.Result); // Eğer SupplierViewModel kullanıyorsanız
            return View(new MaterialViewModel()); // Boş bir ViewModel örneği
        }

        // POST: Malzeme ekleme işlemi
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
            // İşlem başarısız olursa, formu ve hataları tekrar görüntüleyin
            return View(model);
        }
        // Malzeme detaylarını görüntüleme
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

        // Malzeme düzenleme sayfasını göster
        public async Task<IActionResult> Edit(int id)
        {
            var material = await _materialRepository.GetByIdAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<MaterialViewModel>(material);
            var suppliers = await _supplierRepository.GetAllAsync();
            ViewBag.Suppliers = _mapper.Map<IEnumerable<SupplierViewModel>>(suppliers); // Tedarikçi bilgilerini ViewBag ile taşı
            return View(model);
        }

        // POST: Malzeme düzenleme işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MaterialViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var material = _mapper.Map<Material>(model);
                await _materialRepository.UpdateAsync(material);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // Malzeme silme sayfasını göster
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

        // POST: Malzeme silme işlemi
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var material = await _materialRepository.GetByIdAsync(id);
            if (material == null)
            {
                return NotFound();
            }
            await _materialRepository.DestroyAsync(material); // Kalıcı olarak silinmesi
            return RedirectToAction(nameof(Index));
        }

    }
}
