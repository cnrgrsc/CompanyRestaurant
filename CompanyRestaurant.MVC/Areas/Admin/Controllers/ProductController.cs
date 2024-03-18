using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAll();
            var categories = await _categoryRepository.GetAll();
            //var categories = new SelectList(await _categoryRepository.GetAll(), "ID", "CategoryName");
            ViewBag.Categories = categories;
            return View(products);

        }

        public async Task<IActionResult> Create()
        {
            var categories = await _categoryRepository.GetAll();
            ViewBag.CategoriesSelect = new SelectList(categories, "ID", "CategoryName");
            return View();

        }

        
    }
}
