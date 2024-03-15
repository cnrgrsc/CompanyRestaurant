using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.ViewModels.MaterialPriceVM
{
    public class CreateMaterialPriceVM
    {
        [Required(ErrorMessage = "Fiyat boş geçilemez!")]
        public decimal Price { get; set; }
       
        [Required(ErrorMessage = "İsim  boş geçilemez!")]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
