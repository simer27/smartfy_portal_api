using System.Collections.Generic;
using System.Security.Claims;

namespace smartfy.portal_api.domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
