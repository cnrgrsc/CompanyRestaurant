using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Models.AppRoleVM
{
    public class AssignRoleViewModel
    {
        [Required]
        [Display(Name = "Kullanıcı Id")]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Rol Id'leri")]
        public IEnumerable<int> RoleIds { get; set; } // Kullanıcıya atanacak rollerin Id'leri

        public AssignRoleViewModel()
        {
            RoleIds = new List<int>();
        }
    }
}
