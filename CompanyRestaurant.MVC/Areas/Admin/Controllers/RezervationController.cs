using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.Entities.Entities;
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

    }
}
