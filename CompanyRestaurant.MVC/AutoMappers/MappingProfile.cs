using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.AppRoleVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.AppUserVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.CategoryVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.CurrentVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.CustomerVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.EmployeeVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.MaterialPriceVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.MaterialVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.OrderVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.PerformanceReviewVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.ProductVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.RecipeVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.RezervationVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.StockMovementVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.SupplierVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.TableVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.UnitStockVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Entity'den ViewModel'e
            CreateMap<AppRole, AppRoleViewModel>().ReverseMap();
            CreateMap<AppUser, AppUserViewModel>().ReverseMap();
            // Diğer ViewModel'ler için CreateMap metotları...
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Current, CurrentViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Material, MaterialViewModel>().ReverseMap();
            CreateMap<MaterialPrice, MaterialPriceViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<PerformanceReview, PerformanceReviewViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Recipe, RecipeViewModel>().ReverseMap();
            CreateMap<Rezervation, RezervationViewModel>().ReverseMap();
            CreateMap<StockMovement, StockMovementViewModel>().ReverseMap();
            CreateMap<Supplier, SupplierViewModel>().ReverseMap();
            CreateMap<Table, TableViewModel>().ReverseMap();
            CreateMap<UnitStock, UnitStockViewModel>().ReverseMap();
            // Diğer eşlemeler buraya eklenebilir...
        }
    }
}
