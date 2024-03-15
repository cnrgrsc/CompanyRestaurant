using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;
using CompanyRestaurant.MVC.Models.ViewModels.CurrentVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class CurrentProfil : Profile
    {
        public CurrentProfil()
        {
            CreateMap<Current, CreateCurrentVM>().ReverseMap();   //Tam tersi de olabilir demek=ReverseMap.
            CreateMap<Current, UpdateCurrentVM>().ReverseMap();
            CreateMap<Current, DeleteCurrentVM>().ReverseMap();

        }
    }
}
