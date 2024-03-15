using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;
using CompanyRestaurant.MVC.Models.ViewModels.CustomerVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class CustomerProfil:Profile
    {
        public CustomerProfil()
        {
            CreateMap<Customer, CreateCustomerVM>().ReverseMap();   //Tam tersi de olabilir demek=ReverseMap.
            CreateMap<Customer, UpdateCustomerVM>().ReverseMap();
            CreateMap<Customer, DeleteCustomerVM>().ReverseMap();

        }
    }
}
