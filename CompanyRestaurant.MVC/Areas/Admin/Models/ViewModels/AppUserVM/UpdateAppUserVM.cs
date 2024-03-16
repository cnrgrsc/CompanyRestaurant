using CompanyRestaurant.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanyRestaurant.MVC.Areas.Admin.Models.ViewModels.AppUserVM
{
    public class UpdateAppUserVM
    {
        public UpdateAppUserVM()
        {
            Status = DataStatus.Updated;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [EmailAddress]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }

        public DataStatus Status { get; set; }

        [Display(Name = "Roller")]
        public List<string> Roles { get; set; } = new List<string>();
    }
}
