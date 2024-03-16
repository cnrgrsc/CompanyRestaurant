using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Services
{
    public class StockMovementRepository : BaseRepository<StockMovement>, IStockMovementRepository
    {
        private readonly CompanyRestaurantContext _context;

        public StockMovementRepository(CompanyRestaurantContext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<StockMovement>> GetStockMovementsForPeriod(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task RecordStockEntry(StockMovement entry)
        {
            throw new NotImplementedException();
        }

        public Task RecordStockExit(StockMovement exit)
        {
            throw new NotImplementedException();
        }
    }
}