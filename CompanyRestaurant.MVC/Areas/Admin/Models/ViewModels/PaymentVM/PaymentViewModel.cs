using CompanyRestaurant.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.PaymentVM
{
    public class PaymentViewModel
    {
        public decimal Amount { get; set; } // Ödeme tutarı
        public PaymentType PaymentType { get; set; } // Ödeme tipi
        [Display(Name = "Ödeme Tarihi")]
        public DateTime PaymentDate { get; set; } // Ödeme tarihi
    }
}
