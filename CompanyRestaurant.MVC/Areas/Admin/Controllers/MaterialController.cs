using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
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
            var material = await _materialRepository.GetAll();
            var suppliers = await _supplierRepository.GetAll();
            ViewBag.Suppliers = suppliers;
            return View(material);
        }


    }
}
