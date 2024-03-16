using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.SupplierVM
{
    public class CreateSupplierVM
    {
        [Required(ErrorMessage = "Şirket adı boş geçilemez!")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Şirket adresi boş geçilemez!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Şirket mail boş geçilemez!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şirket telefon boş geçilemez!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Şirket çalışan adı boş geçilemez!")]
        public string ContactPerson { get; set; }
    }
}
