using System.ComponentModel.DataAnnotations;

namespace smartfy.portal_api.Infra.CrossCutting.Identity.Entities.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
