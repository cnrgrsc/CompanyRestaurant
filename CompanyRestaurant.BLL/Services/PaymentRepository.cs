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

        public Task<IEnumerable<Payment>> GetPaymentsForOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task RecordPayment(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
