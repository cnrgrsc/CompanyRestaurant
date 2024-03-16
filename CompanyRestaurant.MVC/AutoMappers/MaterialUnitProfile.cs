using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.MaterialUnitVM;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;

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
