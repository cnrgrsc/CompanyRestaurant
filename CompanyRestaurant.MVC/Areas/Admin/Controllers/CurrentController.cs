using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Services;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.Entities.Enums;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;
using CompanyRestaurant.MVC.Models.ViewModels.CurrentVM;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CurrentController : Controller
    {
        private readonly ICurrentRepository _currentRepository;
        private readonly IMapper _mapper;

        public CurrentController(ICurrentRepository currentRepository, IMapper mapper)
        {
            _currentRepository = currentRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var currents = await _currentRepository.GetAll();
            return View(currents);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCurrentVM model)
        {
            if (ModelState.IsValid)
            {
                var current = _mapper.Map<Current>(model);
                var result = await _currentRepository.Create(current);
                TempData["Result"] = result;
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var current = await _currentRepository.GetById(id);
            if (current == null)
            {
                return NotFound();
            }
            UpdateCurrentVM updateCurrentVM = _mapper.Map<UpdateCurrentVM>(current);
            return View(updateCurrentVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCurrentVM model)
        {
            if (ModelState.IsValid)
            {
                var current = _mapper.Map<Current>(model);

                var result = await _currentRepository.Update(current);
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
            var current = await _currentRepository.GetById(id);
            if (current == null)
            {
                return NotFound();
            }
            DeleteCurrentVM deleteCurrentVM = _mapper.Map<DeleteCurrentVM>(current);
            return View(deleteCurrentVM);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var current = await _currentRepository.GetById(id);
            await _currentRepository.Destroy(current);
            TempData["Message"] = "Cari başarıyla silindi.";
            return RedirectToAction("Index");
        }
    }
}
