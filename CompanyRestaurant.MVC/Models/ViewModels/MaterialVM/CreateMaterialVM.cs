using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.ViewModels.MaterialVM
{
    public class CreateMaterialVM
    {
        [Required(ErrorMessage = "Malzeme adı boş geçilemez!")]
        public string MaterialName { get; set; }

        [Required(ErrorMessage = "Malzeme fiyatı boş geçilemez!")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Malzeme stoğu boş geçilemez!")]
        public short UnitInStock { get; set; }

        [Required(ErrorMessage = "Tedarikçi boş geçilemez!")]
        public int SupplierId { get; set; }
    }
}
