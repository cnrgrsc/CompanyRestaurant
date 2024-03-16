using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.CustomerVM
{
    public class CreateCustomerVM
    {
        [Required(ErrorMessage = "Kişi adı boş geçilemez!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kişi soyadı boş geçilemez!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kişi telefon boş geçilemez!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Kişi mail boş geçilemez!")]
        public string Email { get; set; }

        public string Description { get; set; }
    }
}
