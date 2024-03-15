using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;
using CompanyRestaurant.MVC.Models.ViewModels.MaterialUnitVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class MaterialUnitProfile:Profile
    {
        public MaterialUnitProfile()
        {
            CreateMap<MaterialUnit, CreateMaterialUnitVM>().ReverseMap();   //Tam tersi de olabilir demek=ReverseMap.
            CreateMap<MaterialUnit, UpdateMaterialUnitVM>().ReverseMap();
            CreateMap<MaterialUnit, DeleteMaterialUnitVM>().ReverseMap();

        }
    }
}
