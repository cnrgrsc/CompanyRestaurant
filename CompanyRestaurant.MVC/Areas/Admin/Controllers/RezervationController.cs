using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.ViewModels.EmployeeVM;
using CompanyRestaurant.MVC.Models.ViewModels.RezervationVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RezervationController : Controller
    {
        private readonly IRezervationRepository _rezervationRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public RezervationController(IRezervationRepository rezervationRepository, ITableRepository tableRepository, IAppUserRepository appUserRepository, IMapper mapper)
        {
            _rezervationRepository = rezervationRepository;
            _tableRepository = tableRepository;
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var rezervations = await _rezervationRepository.GetAll();
            var tables = await _tableRepository.GetAll();
            //var appUsers = await _appUserRepository.GetAll();
            ViewBag.Tables = tables;
            //ViewBag.AppUsers = appUsers;
            return View(rezervations);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var tables = await _tableRepository.GetAll();
            ViewBag.TablesSelect = new SelectList(tables, "ID", "TableNo");
            //var appUsers=await _appUserRepository.GetAll();
            //ViewBag.AppUsersSelect = new SelectList(appUsers, "ID", "UserName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRezervationVM model)
        {
            if (ModelState.IsValid)
            {
                var rezervation = _mapper.Map<Rezervation>(model);
                var result = await _rezervationRepository.Create(rezervation);
                TempData["Result"] = result;
                return RedirectToAction("Index");

            }

            var tablesReloaded = await _tableRepository.GetAll();
            ViewBag.TablesSelect = new SelectList(tablesReloaded, "ID", "TableNo");
            // var appUsersReloaded = await _appUserRepository.GetAll();
            //ViewBag.AppUsersSelect = new SelectList(appUsersReloaded, "ID", "UserName");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var tables = await _tableRepository.GetAll();
            ViewBag.TablesSelect = new SelectList(tables, "ID", "TableNo");
            //var appUsers = await _appUserRepository.GetAll();
            //ViewBag.AppUsersSelect = new SelectList(appUsers, "ID", "UserName");
            var rezervation = await _rezervationRepository.GetById(id);
            if (rezervation == null)
            {
                return NotFound();
            }

            UpdateRezervationVM updateRezervationVM = _mapper.Map<UpdateRezervationVM>(rezervation);
            return View(updateRezervationVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRezervationVM model)
        {
            if (ModelState.IsValid)
            {
                var rezervation = _mapper.Map<Rezervation>(model);

                var result = await _rezervationRepository.Update(rezervation);
                if (result.Contains("Güncellendi"))
                {
                    TempData["Result"] = result;
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Bir hata oluştu: " + result);

            }
            var tables = await _tableRepository.GetAll();
            ViewBag.TablesSelect = new SelectList(tables, "ID", "TableNo");
            //  var appUsers = await _appUserRepository.GetAll();
            // ViewBag.AppUsersSelect = new SelectList(appUsers, "ID", "UserName");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var rezervation = await _rezervationRepository.GetById(id);
            if (rezervation == null)
            {
                return NotFound();
            }

            DeleteRezervationVM deleteRezervationVM = _mapper.Map<DeleteRezervationVM>(rezervation);
            return View(deleteRezervationVM);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var rezervation = await _rezervationRepository.GetById(id);
            await _rezervationRepository.Destroy(rezervation);
            TempData["Message"] = "Rezervasyon başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }

    }
}
