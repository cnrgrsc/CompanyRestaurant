using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.AppRoleVM
{
    public class EditRoleVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Rol adı gereklidir.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
