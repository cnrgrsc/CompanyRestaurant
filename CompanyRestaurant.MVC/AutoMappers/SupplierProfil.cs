using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;
using CompanyRestaurant.MVC.Models.ViewModels.SupplierVM;

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
