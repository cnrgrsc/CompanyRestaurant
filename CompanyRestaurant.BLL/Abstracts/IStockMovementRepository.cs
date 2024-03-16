using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IStockMovementRepository : IRepository<StockMovement>
    {
        Task RecordStockEntry(StockMovementEntryViewModel entryViewModel);
        Task RecordStockExit(StockMovementExitViewModel exitViewModel);
        Task<IEnumerable<StockMovementViewModel>> GetStockMovementsForPeriod(DateTime startDate, DateTime endDate);
    }
}
