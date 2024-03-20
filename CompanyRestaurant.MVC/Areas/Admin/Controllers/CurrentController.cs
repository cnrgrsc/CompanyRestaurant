using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.CurrentVM;
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
            var currents = await _currentRepository.GetAllActiveAsync();
            var model = _mapper.Map<IEnumerable<CurrentViewModel>>(currents);
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var current = await _currentRepository.GetByIdAsync(id);
            if (current == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<CurrentViewModel>(current);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CurrentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var current = _mapper.Map<Current>(model);
                await _currentRepository.CreateAsync(current);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var current = await _currentRepository.GetByIdAsync(id);
            if (current == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<CurrentViewModel>(current);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CurrentViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var current = _mapper.Map<Current>(model);
                await _currentRepository.UpdateAsync(current);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var current = await _currentRepository.GetByIdAsync(id);
            if (current == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<CurrentViewModel>(current);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var current = await _currentRepository.GetByIdAsync(id);
            if (current == null)
            {
                return NotFound();
            }
            await _currentRepository.DeleteAsync(current);
            return RedirectToAction(nameof(Index));
        }
    }
}
