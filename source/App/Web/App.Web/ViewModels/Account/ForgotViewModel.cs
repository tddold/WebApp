using System.ComponentModel.DataAnnotations;

namespace App.Web.ViewModel.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
