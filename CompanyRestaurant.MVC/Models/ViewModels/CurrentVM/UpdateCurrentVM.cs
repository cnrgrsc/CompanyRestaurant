using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Models.ViewModels.CurrentVM
{
    public class UpdateCurrentVM
    {
        public UpdateCurrentVM()
        {
            Status = DataStatus.Updated;
        }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
        public decimal Debit { get; set; } // Borç
        public decimal Credit { get; set; } // Alacak
        public decimal Balance => Debit - Credit; // Bakiye, hesaplama alanı
        // Cari Hesap Detayları
        public string AccountNumber { get; set; } // Hesap Numarası
        public string CompanyName { get; set; } // Şirket Adı (opsiyonel, bireysel müşteriler için kullanılmayabilir)
        public string ContactName { get; set; } // İletişim Adı
        public string ContactEmail { get; set; } // İletişim E-postası
        public string ContactPhone { get; set; } // İletişim Telefonu
        public string Address { get; set; } // Adres
        public string TaxNumber { get; set; } // Vergi Numarası (opsiyonel, bireysel müşteriler için kullanılmayabilir)
        public string TaxOffice { get; set; }
    }
}
