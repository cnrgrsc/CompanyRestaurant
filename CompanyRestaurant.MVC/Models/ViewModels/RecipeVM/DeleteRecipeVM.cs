using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Models.ViewModels.RecipeVM
{
    public class DeleteRecipeVM
    {
        public DeleteRecipeVM()
        {
            Status=DataStatus.Deleted;
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
        public IFormFile RecipeImage { get; set; } // Reçetenin görseli
    }
}
