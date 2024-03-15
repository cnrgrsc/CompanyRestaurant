using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;
using CompanyRestaurant.MVC.Models.ViewModels.UnitStockVM;

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
