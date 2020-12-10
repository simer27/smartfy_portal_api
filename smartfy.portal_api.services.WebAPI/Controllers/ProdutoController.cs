using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class ProdutoController : ApiController
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="db"></param>
        public ProdutoController(ApplicationDbContext db, IMapper mapper) : base(db)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna Lista de Clientes
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
                return Ok(Db.Produtos.ToList());
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
    }
}