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

        public async Task AddStockMovement(StockMovement stockMovement)
        {
            if (stockMovement == null)
            {
                throw new ArgumentNullException(nameof(stockMovement), "Stok hareketi null olamaz.");
            }

            // Stok hareketini ekleyin
            await _context.StockMovements.AddAsync(stockMovement);
            await _context.SaveChangesAsync();
        }
    }
}