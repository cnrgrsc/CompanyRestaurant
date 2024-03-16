using AutoMapper;
using CompanyRestaurant.Entities.Entities;
using CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.OrderVM;
using CompanyRestaurant.MVC.Models.ViewModels.CategoryVM;

namespace CompanyRestaurant.MVC.AutoMappers
{
    public class OrderProfil:Profile
    {
        public OrderProfil()
        {
            CreateMap<Order, CreateOrderVM>().ReverseMap();   //Tam tersi de olabilir demek=ReverseMap.
            CreateMap<Order, UpdateOrderVM>().ReverseMap();
            CreateMap<Order, DeleteOrderVM>().ReverseMap();

        }
    }
}
