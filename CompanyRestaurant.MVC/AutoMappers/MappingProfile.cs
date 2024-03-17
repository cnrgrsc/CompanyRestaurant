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
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.PaymentVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.PerformanceReviewVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.ProductOrderVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.ProductVM;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.RecipeMaterialVM;
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
            CreateMap<AppRole, AppRoleViewModel>();
            CreateMap<AppUser, AppUserViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Current, CurrentViewModel>();
            CreateMap<Customer, CustomerViewModel>();
            //CreateMap<Dashboard, DashboardViewModel>();
            CreateMap<Employee, EmployeeViewModel>();
            CreateMap<MaterialPrice, MaterialPriceViewModel>();
            CreateMap<Material, MaterialViewModel>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<Payment, PaymentViewModel>();
            CreateMap<PerformanceReview, PerformanceReviewViewModel>();
            CreateMap<ProductOrder, ProductOrderViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<RecipeMaterial, RecipeMaterialViewModel>();
            CreateMap<Recipe, RecipeViewModel>();
            CreateMap<Rezervation, RezervationViewModel>();
            CreateMap<StockMovement, StockMovementViewModel>();
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<Table, TableViewModel>();
            CreateMap<UnitStock, UnitStockViewModel>();
            //CreateMap<RolePermissions, RolePermissionsViewModel>(); // Varsayılan bir RolePermissions entity'niz yoksa, bu satır düzenlenmelidir.
            //CreateMap<Permission, PermissionViewModel>(); // Varsayılan bir Permission entity'niz yoksa, bu satır düzenlenmelidir.

            // ViewModel'den Entity'e (Eğer gerekliyse)
            CreateMap<AppRoleViewModel, AppRole>();
            CreateMap<AppUserViewModel, AppUser>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<CurrentViewModel, Current>();
            CreateMap<CustomerViewModel, Customer>();
            //CreateMap<DashboardViewModel, Dashboard>(); // Dashboard için bir entity'niz yoksa, bu satırı kaldırın veya düzenleyin.
            CreateMap<EmployeeViewModel, Employee>();
            CreateMap<MaterialPriceViewModel, MaterialPrice>();
            CreateMap<MaterialViewModel, Material>();
            CreateMap<OrderViewModel, Order>();
            CreateMap<PaymentViewModel, Payment>();
            CreateMap<PerformanceReviewViewModel, PerformanceReview>();
            CreateMap<ProductOrderViewModel, ProductOrder>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<RecipeMaterialViewModel, RecipeMaterial>();
            CreateMap<RecipeViewModel, Recipe>();
            CreateMap<RezervationViewModel, Rezervation>();
            CreateMap<StockMovementViewModel, StockMovement>();
            CreateMap<SupplierViewModel, Supplier>();
            CreateMap<TableViewModel, Table>();
            CreateMap<UnitStockViewModel, UnitStock>();
            //CreateMap<RolePermissionsViewModel, RolePermissions>(); // Varsayılan bir RolePermissions entity'niz yoksa, bu satır düzenlenmelidir.
            //CreateMap<PermissionViewModel, Permission>(); // Varsayılan bir Permission entity'niz yoksa, bu satır düzenlenmelidir.
        }
    }
}
