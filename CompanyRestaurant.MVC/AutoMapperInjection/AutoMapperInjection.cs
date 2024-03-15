using AutoMapper;
using CompanyRestaurant.MVC.AutoMappers;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CompanyRestaurant.MVC.AutoMapperInjection
{
    public static class AutoMapperInjection
    {
        public static void AddMapperService(this IServiceCollection services)
        {
            MapperConfiguration mapperConfiguration = new(opt =>
            {
                opt.AddProfile(new CategoryProfil());
                opt.AddProfile(new CurrentProfil());
                opt.AddProfile(new CustomerProfil());
                opt.AddProfile(new EmployeeProfil());
                opt.AddProfile(new MaterialPriceProfil());
                opt.AddProfile(new MaterialProfil());
                opt.AddProfile(new MaterialUnitProfile());
                opt.AddProfile(new OrderProfil());
                opt.AddProfile(new ProductProfil());
                opt.AddProfile(new RecipeProfil());
                opt.AddProfile(new RezervationProfil());
                opt.AddProfile(new SupplierProfil());
                opt.AddProfile(new TableProfil());
                opt.AddProfile(new UnitStockProfil());
            });
            IMapper mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
