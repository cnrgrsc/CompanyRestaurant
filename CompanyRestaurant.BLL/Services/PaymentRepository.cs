using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Services
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly CompanyRestaurantContext _context;
        public PaymentRepository(CompanyRestaurantContext context):base(context)
        {
            _context = context;
        }
    }
}
