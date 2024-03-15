using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;
using CompanyRestaurant.MVC.Models.ViewModels.MaterialVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class MaterialProfil:Profile
    {
        public MaterialProfil()
        {
            CreateMap<Material, CreateMaterialVM>().ReverseMap();   //Tam tersi de olabilir demek=ReverseMap.
            CreateMap<Material, UpdateMaterialVM>().ReverseMap();
            CreateMap<Material, DeleteMaterialVM>().ReverseMap();

        }
    }
}
