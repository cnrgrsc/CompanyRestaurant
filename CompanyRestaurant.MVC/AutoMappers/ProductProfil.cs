using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.ProductVM;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class ProductProfil:Profile
    {
        public ProductProfil()
        {
            CreateMap<Product, CreateProductVM>().ReverseMap();   //Tam tersi de olabilir demek=ReverseMap.
            CreateMap<Product, UpdateProductVM>().ReverseMap();
            CreateMap<Product, DeleteProductVM>().ReverseMap();

        }
    }
}
