using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.RezervationVM;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class RezervationProfil:Profile
    {
        public RezervationProfil()
        {
            CreateMap<Rezervation, CreateRezervationVM>().ReverseMap();   //Tam tersi de olabilir demek=ReverseMap.
            CreateMap<Rezervation, UpdateRezervationVM>().ReverseMap();
            CreateMap<Rezervation, DeleteRezervationVM>().ReverseMap();

        }
    }
}
