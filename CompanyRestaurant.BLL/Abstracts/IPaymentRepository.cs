﻿using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{

    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetPaymentsForOrder(int orderId); // ViewModel yerine entity dönüş tipi.
        //Task RecordPayment(Payment payment); // Doğrudan entity alacak şekilde güncellendi.
    }
}

