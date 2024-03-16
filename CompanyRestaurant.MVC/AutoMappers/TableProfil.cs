using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.TableVM;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class TableProfil:Profile
    {
        public TableProfil()
        {
            CreateMap<Table, CreateTableVM>().ReverseMap();   //Tam tersi de olabilir demek=ReverseMap.
            CreateMap<Table, UpdateTableVM>().ReverseMap();
            CreateMap<Table, DeleteTableVM>().ReverseMap();

        }
    }
}
