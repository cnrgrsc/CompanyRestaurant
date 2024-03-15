using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Models.ViewModels.SupplierVM
{
    public class DeleteSupplierVM
    {
        public DeleteSupplierVM()
        {
            Status=DataStatus.Deleted;
        }
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
    }
}
