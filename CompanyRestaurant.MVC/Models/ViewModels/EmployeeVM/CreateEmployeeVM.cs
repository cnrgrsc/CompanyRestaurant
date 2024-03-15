using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.ViewModels.EmployeeVM
{
    public class CreateEmployeeVM
    {
        [Required(ErrorMessage = "Çalışan adı boş geçilemez!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Çalışan Soyad boş geçilemez!")]
        public string Surname { get; set; }
        
        [Required(ErrorMessage = "Ünvan  boş geçilemez!")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "TC  boş geçilemez!")]
        public long TC { get; set; }
        
        [Required(ErrorMessage = "Telefon no  boş geçilemez!")]
        public string Phone { get; set; }
    }
}
