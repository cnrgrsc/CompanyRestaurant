using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.SupplierVM;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class SupplierProfil:Profile
    {
        public SupplierProfil()
        {
            CreateMap<Supplier, CreateSupplierVM>().ReverseMap();   //Tam tersi de olabilir demek=ReverseMap.
            CreateMap<Supplier, UpdateSupplierVM>().ReverseMap();
            CreateMap<Supplier, DeleteSupplierVM>().ReverseMap();

        }
    }
}
