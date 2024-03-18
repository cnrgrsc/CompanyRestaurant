using AutoMapper;
using CompanyRestaurant.BLL.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyRestaurant.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeController(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var recipes = await _recipeRepository.GetAll();
            return View(recipes);
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}
