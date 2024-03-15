using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;
using CompanyRestaurant.MVC.Models.ViewModels.RecipeVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class RecipeProfil:Profile
    {
        public RecipeProfil()
        {
            CreateMap<Recipe, CreateRecipeVM>().ReverseMap();   //Tam tersi de olabilir demek=ReverseMap.
            CreateMap<Recipe, UpdateRecipeVM>().ReverseMap();
            CreateMap<Recipe, DeleteRecipeVM>().ReverseMap();

        }
    }
}
