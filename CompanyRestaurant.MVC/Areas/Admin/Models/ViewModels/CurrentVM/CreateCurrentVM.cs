using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.CurrentVM
{
    public class CreateCurrentVM
    {
        [Required(ErrorMessage = "Borç boş geçilemez!")]
        public decimal Debit { get; set; } // Borç

        [Required(ErrorMessage = "Alacak boş geçilemez!")]
        public decimal Credit { get; set; } // Alacak
        public decimal Balance => Debit - Credit; // Bakiye, hesaplama alanı

        // Cari Hesap Detayları
        [Required(ErrorMessage = "Hesap numarası boş geçilemez!")]
        public string AccountNumber { get; set; } // Hesap Numarası

        [Required(ErrorMessage = "Şirket adı boş geçilemez!")]
        public string CompanyName { get; set; } // Şirket Adı (opsiyonel, bireysel müşteriler için kullanılmayabilir)

        [Required(ErrorMessage = "İletişim adı boş geçilemez!")]
        public string ContactName { get; set; } // İletişim Adı

        [Required(ErrorMessage = "İletişim E-posta boş geçilemez!")]
        public string ContactEmail { get; set; } // İletişim E-postası

        [Required(ErrorMessage = "İletişim Telefon boş geçilemez!")]
        public string ContactPhone { get; set; } // İletişim Telefonu

        [Required(ErrorMessage = "Adres boş geçilemez!")]
        public string Address { get; set; } // Adres

        [Required(ErrorMessage = "Vergi Numarası boş geçilemez!")]
        public string TaxNumber { get; set; } // Vergi Numarası (opsiyonel, bireysel müşteriler için kullanılmayabilir)

        [Required(ErrorMessage = "Vergi dairesi boş geçilemez!")]
        public string TaxOffice { get; set; }
    }
}
