using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.ViewModels.TableVM
{
    public class CreateTableVM
    {
        [Required(ErrorMessage = "Masa no boş geçilemez!")]
        public int TableNo { get; set; }
        
        [Required(ErrorMessage = "Rezervasyon durumu boş geçilemez!")]
        public bool RezStatus { get; set; }
        
        [Required(ErrorMessage = "Kişi kapasitesi boş geçilemez!")]
        public int PersonCapacity { get; set; }
    }
}
