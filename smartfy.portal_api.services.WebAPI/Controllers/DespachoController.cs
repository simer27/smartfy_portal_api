using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using System;
using System.Linq;
using System.Net;

namespace smartfy.portal_api.services.WebAPI.Controllers
{
    /// <summary>
    /// Class
    /// </summary>
    [Route("api/[controller]")]
    //[Authorize]
    public class DespachoController : ApiController
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="db"></param>
        public DespachoController(ApplicationDbContext db, IMapper mapper) : base(db)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna Lista de Despachos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Response( Db.Despachos
                    .Select(despacho => new
                    {
                        Nome = Db.Clientes.FirstOrDefault(_ => _.Id == despacho.ClienteId).Name,
                        Codigo = Db.Produtos.FirstOrDefault(_ => _.Id == despacho.ProdutoId).Codigo,
                        Produto = Db.Produtos.FirstOrDefault(_ => _.Id == despacho.ProdutoId).Descricao,
                        DtEnvio = despacho.DtEnvio,
                        DtEntrega = despacho.DtEntrega,
                        DtRecebimento = despacho.DtRecebimento
                    }));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Retorna um item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var despacho = Db.Despachos.FirstOrDefault(c => c.Id == id);
                if (despacho == null)
                    return NotFound();
                return Response(
                    new
                    {
                        Nome = Db.Clientes.FirstOrDefault(_=>_.Id == despacho.ClienteId).Name,
                        Codigo = Db.Produtos.FirstOrDefault(_ => _.Id == despacho.ClienteId).Codigo,
                        Produto = Db.Produtos.FirstOrDefault(_ => _.Id == despacho.ClienteId).Descricao,
                        DtEnvio = despacho.DtEnvio,
                        DtEntrega = despacho.DtEntrega,
                        DtRecebimento = despacho.DtRecebimento
                    }
                );
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}