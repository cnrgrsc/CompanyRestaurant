using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaterialPriceController : Controller
    {
        private readonly IMaterialPriceRepository _materialPriceRepository;
        private readonly IMapper _mapper;

        public MaterialPriceController(IMaterialPriceRepository materialPriceRepository, IMapper mapper)
        {
            _materialPriceRepository = materialPriceRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var materialPrice = await _materialPriceRepository.GetAllAsync();
            return View(materialPrice);
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}
