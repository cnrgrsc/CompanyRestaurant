using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;
using CompanyRestaurant.MVC.Models.ViewModels.TableVM;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TableController : Controller
    {
        private readonly ITableRepository _tableRepository;
        private readonly IMapper _mapper;

        public TableController(ITableRepository tableRepository, IMapper mapper)
        {
            _tableRepository = tableRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var table = await _tableRepository.GetAll();
            return View(table);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTableVM model)
        {
            if (ModelState.IsValid)
            {
                var table = _mapper.Map<Table>(model);
                var result = await _tableRepository.Create(table);
                TempData["Result"] = result;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var table = await _tableRepository.GetById(id);
            if (table == null)
            {
                return NotFound();
            }

            UpdateTableVM updateTableVM = _mapper.Map<UpdateTableVM>(table);

            return View(updateTableVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTableVM model)
        {
            if (ModelState.IsValid)
            {
                var table = _mapper.Map<Table>(model);
                var result = await _tableRepository.Update(table);
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
            var table = await _tableRepository.GetById(id);
            if (table == null)
            {
                return NotFound();
            }

            DeleteTableVM deleteTableVM = _mapper.Map<DeleteTableVM>(table);
            return View(deleteTableVM);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var table = await _tableRepository.GetById(id);
            await _tableRepository.Destroy(table);
            TempData["Message"] = "Ürün başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
