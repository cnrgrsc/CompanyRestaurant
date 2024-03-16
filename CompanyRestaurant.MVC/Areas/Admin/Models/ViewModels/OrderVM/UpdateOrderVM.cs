using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.OrderVM
{
    public class UpdateOrderVM
    {
        public UpdateOrderVM()
        {
            Status = DataStatus.Updated;
        }
        public int Id { get; set; }
        public string OrderName { get; set; }
        public decimal Price { get; set; }
        public PaymentType PaymentType { get; set; }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
        public int TableId { get; set; }
        public int EmployeeId { get; set; }

        public int AccountingId { get; set; }
    }
}
