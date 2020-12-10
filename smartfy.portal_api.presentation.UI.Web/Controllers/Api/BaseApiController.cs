using Microsoft.AspNetCore.Mvc;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;

namespace smartfy.portal_api.presentation.UI.Web.Controllers.Api
{
    public class BaseApiController : Controller
    {
        protected readonly ApplicationDbContext Db;

        public BaseApiController(ApplicationDbContext context)
        {
            Db = context;
        }

        protected new IActionResult Response(object result = null, bool success = true)
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
                errors = result
            });
        }
    }
}