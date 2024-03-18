using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.CustomerVM
{
    public class CustomerViewModel
    {
        public int Id { get; set; } // Müşteri ID'si

        [Required(ErrorMessage = "Müşteri adı zorunludur.")]
        [Display(Name = "Adı")]
        public string Name { get; set; } // Müşteri adı

        [Required(ErrorMessage = "Müşteri soyadı zorunludur.")]
        [Display(Name = "Soyadı")]
        public string Surname { get; set; } // Müşteri soyadı

        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; } // Müşteri telefon numarası

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; } // Müşteri e-posta adresi

        [Display(Name = "Açıklama")]
        public string Description { get; set; } // Müşteri hakkında ek açıklamalar

        // Opsiyonel: Müşterinin ilişkilendirilmiş cari hesabı varsa, bu bilgiyi de tutabilirsiniz.
        public int? CurrentAccountId { get; set; }
        [Display(Name = "Cari Hesap")]
        public string CurrentAccountName { get; set; } // İlişkilendirilmiş cari hesabın adı

        // Müşteri ile ilişkilendirilen rezervasyon sayısı gibi ek bilgiler de ViewModel içerisinde yer alabilir.
        [Display(Name = "Rezervasyon Sayısı")]
        public int ReservationCount { get; set; } // Müşteriye ait rezervasyon sayısı
    }

}
