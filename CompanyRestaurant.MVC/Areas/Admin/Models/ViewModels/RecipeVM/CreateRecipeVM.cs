using CompanyRestaurant.Entities.Entities;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.RecipeVM
{
    public class CreateRecipeVM
    {
        [Required(ErrorMessage = "Reçete adı boş geçilemez!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Hizmet durumu boş geçilemez!")]
        public int Serves { get; set; } // Porsiyon bilgisi

        // Eklenen yeni alanlar

        [Required(ErrorMessage = "Hazırlanma zamanı boş geçilemez!")]
        public TimeSpan PreparationTime { get; set; } // Hazırlık süresi

        [Required(ErrorMessage = "Pişme süresi boş geçilemez!")]
        public TimeSpan CookingTime { get; set; } // Pişirme süresi

        [Required(ErrorMessage = "Talimatlar boş geçilemez!")]
        public string Instructions { get; set; } // Hazırlama talimatları

        [Required(ErrorMessage = "Resim boş geçilemez!")]
        public IFormFile RecipeImage { get; set; } // Reçetenin görseli
    }
}
