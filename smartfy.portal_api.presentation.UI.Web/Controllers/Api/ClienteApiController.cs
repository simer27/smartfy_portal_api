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
    [Route("api/Cliente")]
    [ApiController]
    public class ClienteApiController : BaseApiController
    {
        public ClienteApiController(ApplicationDbContext context) : base(context)
        {
        }
        [HttpGet]
        [Route("all")]
        public IActionResult GetAllClientes()
        {
            return Response(Db.Clientes.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var result = Db.Clientes.FirstOrDefault(c => c.Id == id);
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
                var clienteDb = Db.Clientes.FirstOrDefault(c => c.Id == vm.Id);
                if (clienteDb == null)
                    return Ok(new { status = false, msg = $"Erro ao deletar o cliente" });

                Db.Clientes.Remove(clienteDb);
                Db.SaveChanges();

                return Ok(new { status = true, msg = string.Empty, cliente = clienteDb });
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
