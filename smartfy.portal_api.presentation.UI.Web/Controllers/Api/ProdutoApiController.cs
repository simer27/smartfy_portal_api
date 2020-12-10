using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;

namespace smartfy.portal_api.presentation.UI.Web.Controllers.Api {

    [Route("api/Produto")]
    [ApiController]
    public class ProdutoApiController : BaseApiController {


        public ProdutoApiController(ApplicationDbContext context) : base(context)
        {
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllProdutos()
        {
            return Response(Db.Produtos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var result = Db.Produtos.FirstOrDefault(c => c.Id == id);
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
                var produtoDb = Db.Produtos.FirstOrDefault(c => c.Id == vm.Id);
                if (produtoDb == null)
                    return Ok(new { status = false, msg = $"Erro ao deletar o produto"});

                Db.Produtos.Remove(produtoDb);
                Db.SaveChanges();

                return Ok(new { status = true, msg = string.Empty, produto = produtoDb });
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }

    public class DeleteViewModel
    {
        public Guid Id { get; set; }
        //public string Name { get; set; }

    }
}