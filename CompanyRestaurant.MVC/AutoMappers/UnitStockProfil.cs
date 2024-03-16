using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.UnitStockVM;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class UnitStockProfil:Profile
    {
        public UnitStockProfil()
        {
            CreateMap<UnitStock, CreateUnitStockVM>().ReverseMap();   //Tam tersi de olabilir demek=ReverseMap.
            CreateMap<UnitStock, UpdateUnitStockVM>().ReverseMap();
            CreateMap<UnitStock, DeleteUnitStockVM>().ReverseMap();

        }
    }
}
