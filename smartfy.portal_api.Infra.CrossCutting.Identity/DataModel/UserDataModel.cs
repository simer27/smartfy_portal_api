using smartfy.portal_api.domain.DataModel;

namespace smartfy.portal_api.Infra.CrossCutting.Identity.DataModel
{
    public class UserDataModel : IUserDataModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
