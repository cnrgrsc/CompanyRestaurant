using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.AppRoleVM
{
    public class DeleteAppRoleVM
    {
        public DeleteAppRoleVM()
        {
            Status = DataStatus.Deleted;
        }

        public int Id { get; set; }
        public DataStatus Status { get; set; }
    }
}
