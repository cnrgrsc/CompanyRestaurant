using CompanyRestaurant.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.ViewModels.OrderVM
{
    public class CreateOrderVM
    {
        [Required(ErrorMessage = "Sipariş adı boş geçilemez!")]
        public string OrderName { get; set; }
        
        [Required(ErrorMessage = "Sipariş fiyatı boş geçilemez!")]
        public decimal Price { get; set; }
      
        [Required(ErrorMessage = "Ödeme türü boş geçilemez!")]
        public PaymentType PaymentType { get; set; }

        [Required(ErrorMessage = "Masa seçimi yapılmalıdır!")]
        public int TableId { get; set; }
        
        [Required(ErrorMessage = "Çalışan seçimi yapılmalıdır!")]
        public int EmployeeId { get; set; }
        public int AccountingId { get; set; }
        
    }
}
