using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.EmployeeVM
{
    public class EmployeeViewModel
    {
        public int Id { get; set; } // Çalışanın benzersiz kimliği

        [Required(ErrorMessage = "Çalışanın adı zorunludur.")]
        [Display(Name = "Adı")]
        public string Name { get; set; } // Çalışanın adı

        [Required(ErrorMessage = "Çalışanın soyadı zorunludur.")]
        [Display(Name = "Soyadı")]
        public string Surname { get; set; } // Çalışanın soyadı

        [Required(ErrorMessage = "Çalışanın unvanı zorunludur.")]
        [Display(Name = "Unvan")]
        public string Title { get; set; } // Çalışanın unvanı

        [Display(Name = "TC Kimlik No")]
        public long TC { get; set; } // Çalışanın TC kimlik numarası

        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; } // Çalışanın telefon numarası

        // Opsiyonel: Çalışanın ait olduğu kullanıcı hesabı bilgisi
        public int? AppUserId { get; set; }
        [Display(Name = "Kullanıcı Hesabı")]
        public string UserName { get; set; } // İlişkilendirilmiş kullanıcı hesabının adı

        // Performans değerlendirme sonuçları veya diğer çalışan detayları için ek alanlar eklenebilir.
        [Display(Name = "Performans Değerlendirme Sayısı")]
        public int PerformanceReviewCount { get; set; } // Çalışana ait performans değerlendirme sayısı

        // Çalışanın ait olduğu siparişler, performans değerlendirmeleri gibi ek bilgiler
        // Bu bilgiler, detay görüntülemelerde veya ilişkili listelemelerde kullanılabilir.
    }

}
