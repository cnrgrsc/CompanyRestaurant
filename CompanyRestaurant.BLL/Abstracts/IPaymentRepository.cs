using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{

    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<IEnumerable<PaymentViewModel>> GetPaymentsForOrder(int orderId);
        Task RecordPayment(PaymentCreateViewModel paymentViewModel);
    }
}
