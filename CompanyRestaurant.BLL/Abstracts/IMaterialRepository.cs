using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IMaterialRepository : IRepository<Material>
    {
        // Mevcut malzeme stok seviyesini alır
        Task<decimal> GetMaterialStockLevel(int materialId);

        // Tüm malzemeler için stok raporu oluşturur
        Task<IEnumerable<MaterialStockViewModel>> GenerateStockReport();

        // Belirli bir reçete için gerekli olan malzemeleri alır
        Task<IEnumerable<MaterialStockViewModel>> GetMaterialsForRecipe(int recipeId);

        // Belirli bir reçete için malzeme sipariş önerisi yapar
        Task<MaterialOrderSuggestionViewModel> SuggestMaterialOrders(int recipeId);
    }

}
