using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Models.ViewModels.CategoryVM
{
    public class DeleteCategoryVM
    {
        public DeleteCategoryVM()
        {
            Status = DataStatus.Deleted;
        }

        public DataStatus Status { get; set; }
        public int Id { get; set; }
       
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
