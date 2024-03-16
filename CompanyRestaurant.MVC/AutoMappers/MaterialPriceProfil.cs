using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.MaterialPriceVM;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class MaterialPriceProfil:Profile
    {
        public MaterialPriceProfil()
        {
            CreateMap<MaterialPrice, CreateMaterialPriceVM>().ReverseMap();   //Tam tersi de olabilir demek=ReverseMap.
            CreateMap<MaterialPrice, UpdateMaterialPriceVM>().ReverseMap();
            CreateMap<MaterialPrice, DeleteMaterialPriceVM>().ReverseMap();

        }
    }
}
