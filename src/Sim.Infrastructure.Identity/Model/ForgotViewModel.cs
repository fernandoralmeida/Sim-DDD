using System.ComponentModel.DataAnnotations;

namespace Sim.Infrastructure.Identity.Model
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}