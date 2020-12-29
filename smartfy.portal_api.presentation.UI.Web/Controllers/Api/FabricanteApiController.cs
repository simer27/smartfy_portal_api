using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace smartfy.portal_api.presentation.UI.Web.Controllers.Api
{
    [Route("api/Fabricante")]
    [ApiController]
    public class FabricanteApiController : BaseApiController
    {
        public FabricanteApiController(ApplicationDbContext context) : base(context)
        {
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllFabricantes()
        {
            return Response(Db.Fabricantes.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var result = Db.Fabricantes.FirstOrDefault(c => c.Id == id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Delete(DeleteViewModel vm)
        {
            try
            {
                
                var fabricanteDb = Db.Fabricantes.FirstOrDefault(c => c.Id == vm.Id);
                if (fabricanteDb == null)
                    return Ok(new { status = false, msg = $"Erro ao deletar o produto" });

                Db.Fabricantes.Remove(fabricanteDb);
                Db.SaveChanges();

                return Ok(new { status = true, msg = string.Empty, fabricante = fabricanteDb });
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

