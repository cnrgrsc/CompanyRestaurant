using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.CategoryVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class CategoryProfil : Profile
    {
        public CategoryProfil()
        {
            CreateMap<Category, CreateCategoryVM>().ReverseMap();   //Tam tersi de olabilir demek=ReverseMap.
            CreateMap<Category, UpdateCategoryVM>().ReverseMap();
            CreateMap<Category, DeleteCategoryVM>().ReverseMap();

        }
    }
}
