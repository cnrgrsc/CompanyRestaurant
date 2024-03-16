using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface IMaterialRepository : IRepository<Material>
    {
        Task<decimal> GetMaterialStockLevel(int materialId);
        Task<IEnumerable<Material>> GenerateStockReport();
        Task<IEnumerable<Material>> GetMaterialsForRecipe(int recipeId);
        //Task<SuggestMaterialOrder> SuggestMaterialOrders(int recipeId); // Bu kısmın dönüş tipini detaylandırmak gerekebilir, örneğin bir DTO veya başka bir entity tipi.
    }

}
