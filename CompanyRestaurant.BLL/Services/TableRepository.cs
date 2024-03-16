using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Services
{
    public class TableRepository:BaseRepository<Table>,ITableRepository
    {
        public TableRepository(CompanyRestaurantContext context):base(context)
        {
            
        }

        public Task CloseTable(int tableId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Table>> GetTableUsageReport(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task OpenTable(int tableId)
        {
            throw new NotImplementedException();
        }
    }
}
