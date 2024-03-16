using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.RecipeVM
{
    public class UpdateRecipeVM
    {
        public UpdateRecipeVM()
        {
            Status = DataStatus.Updated;
        }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Serves { get; set; } // Porsiyon bilgisi
        public string ImageUrl { get; set; }

        // Eklenen yeni alanlar
        public TimeSpan PreparationTime { get; set; } // Hazırlık süresi
        public TimeSpan CookingTime { get; set; } // Pişirme süresi
        public string Instructions { get; set; } // Hazırlama talimatları
        public IFormFile RecipeImage { get; set; }  // Reçetenin görseli
    }
}
