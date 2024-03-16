using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.UnitStockVM
{
    public class CreateUnitStockVM
    {
        [Required(ErrorMessage = "Stok boş geçilemez!")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "kritik stok boş geçilemez!")]
        public int CriticalStock { get; set; }

        [Required(ErrorMessage = "Minium stok düzeyi boş geçilemez!")]
        public int MinimumStockLevel { get; set; }

        [Required(ErrorMessage = "Malzeme adı boş geçilemez!")]
        public int MaterialID { get; set; }
    }
}
