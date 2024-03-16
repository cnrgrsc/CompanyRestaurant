using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
        Task<IEnumerable<SalesReportViewModel>> GenerateSalesReport(DateTime startDate, DateTime endDate);
    }
}
