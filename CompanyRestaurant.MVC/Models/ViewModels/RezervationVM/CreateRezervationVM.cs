using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.ViewModels.RezervationVM
{
    public class CreateRezervationVM
    {
        [Required(ErrorMessage = "Kişi adı boş geçilemez!")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Kişi soyadı boş geçilemez!")]
        public string Surname { get; set; }
        
        [Required(ErrorMessage = "Kişi telefon numarası boş geçilemez!")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Kişi mail boş geçilemez!")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Tarih boş geçilemez!")]
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int AppUserId { get; set; }
        public int TableId { get; set; }
    }
}
