using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;

namespace smartfy.portal_api.presentation.UI.Web.Controllers.Api
{
    public class BaseApiController : Controller
    {
        protected readonly ApplicationDbContext _context;

        public BaseApiController(ApplicationDbContext context)
        {
            _context = context;
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