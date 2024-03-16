using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.RezervationVM
{
    public class DeleteRezervationVM
    {
        public DeleteRezervationVM()
        {
            Status = DataStatus.Deleted;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
        public int AppUserId { get; set; }
        public int TableId { get; set; }
    }
}
