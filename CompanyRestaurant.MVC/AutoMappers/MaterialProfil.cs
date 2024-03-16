using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.MaterialVM;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;

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
