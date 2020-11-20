using System.ComponentModel.DataAnnotations;

namespace smartfy.portal_api.Infra.CrossCutting.Identity.Entities.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
