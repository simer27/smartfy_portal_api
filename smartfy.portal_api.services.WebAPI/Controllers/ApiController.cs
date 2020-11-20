using Microsoft.AspNetCore.Mvc;
using smartfy.portal_api.domain.DataModel;
using smartfy.portal_api.domain.Extensions;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using smartfy.portal_api.Infra.CrossCutting.Identity.DataModel;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace smartfy.portal_api.services.WebAPI.Controllers
{
    public class ApiController : ControllerBase
    {
        protected readonly ApplicationDbContext Db;

        public ApiController(ApplicationDbContext db)
        {
            Db = db;
        }

        protected IUserDataModel GetUser(string email)
        {
            return (
                from user in Db.Users
                where user.Email == email
                select new UserDataModel()
                {
                    Email = user.Email,
                    UserId = user.Id,
                    UserName = user.UserName
                }
            ).FirstOrDefault();

        }

        protected new IActionResult Response(object result = null, bool success = true, string errorMessage = "")
        {
            if (success)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = errorMessage
            });
        }

        protected new IActionResult ModelStateError()
        {
            var result = new List<string>();
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {

                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                result.Add(erroMsg);
            }

            return Response(success: false, errorMessage: string.Join("\r\n", result));
        }

        protected IUserDataModel GetLoggedUser()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var email = claimsIdentity.FindFirst("/email")?.Value;

            return GetUser(email);
        }
    }
}
