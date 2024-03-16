using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.EmployeeVM;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;

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
