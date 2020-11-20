using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using smartfy.portal_api.Infra.CrossCutting.Identity.DataModel;
using smartfy.portal_api.presentation.UI.Web.Helpers;
using System.Linq;

namespace smartfy.portal_api.presentation.UI.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext Db;

        public BaseController(ApplicationDbContext db)
        {
            Db = db;
        }

        protected void NotifySuccess(string titulo, string mensagem)
        {
            ModalHelper.ShowModal(titulo, mensagem, ModalHelper.Types.Message, ModalHelper.CssClass.Success);
        }

        protected void NotifyError(string titulo, string mensagem)
        {
            ModalHelper.ShowModal(titulo, mensagem, ModalHelper.Types.Message, ModalHelper.CssClass.Danger);
        }

        protected UserDataModel GetLoggedUser()
        {
            if (!User.Identity.IsAuthenticated) return null;

            return (
                from user in Db.Users
                where user.Email == User.Identity.Name
                select new UserDataModel()
                {
                    Email = user.Email,
                    UserId = user.Id,
                    UserName = user.UserName
                }
            ).FirstOrDefault();

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.User = GetLoggedUser();

            base.OnActionExecuting(context);
        }

    }

}
