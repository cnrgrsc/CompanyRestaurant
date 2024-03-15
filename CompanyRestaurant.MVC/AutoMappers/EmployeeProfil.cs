using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;
using CompanyRestaurant.MVC.Models.ViewModels.EmployeeVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class EmployeeProfil:Profile
    {
        public EmployeeProfil()
        {
            CreateMap<Employee, CreateEmployeeVM>().ReverseMap();   //Tam tersi de olabilir demek=ReverseMap.
            CreateMap<Employee, UpdateEmployeeVM>().ReverseMap();
            CreateMap<Employee, DeleteEmployeeVM>().ReverseMap();

        }
    }
}
