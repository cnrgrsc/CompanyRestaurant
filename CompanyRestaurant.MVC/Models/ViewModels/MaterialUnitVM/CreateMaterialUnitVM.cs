using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.ViewModels.MaterialUnitVM
{
    public class CreateMaterialUnitVM
    {
        [Required(ErrorMessage = "Birim boş geçilemez!")]
        public string Unit { get; set; }
        public string Description { get; set; }
    }
}
