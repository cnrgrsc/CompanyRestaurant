using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IPerformanceReviewRepository : IRepository<PerformanceReview>
    {
        Task<IEnumerable<PerformanceReview>> GetPerformanceReviewsByEmployee(int employeeId);
        //Task<PerformanceReport> GeneratePerformanceReport(int employeeId); // Bu kısmın dönüş tipini detaylandırmak gerekebilir, örneğin bir DTO veya başka bir entity tipi.
    }
}
