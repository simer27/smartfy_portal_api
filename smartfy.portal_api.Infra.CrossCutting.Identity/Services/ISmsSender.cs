using System.Threading.Tasks;

namespace smartfy.portal_api.Infra.CrossCutting.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
