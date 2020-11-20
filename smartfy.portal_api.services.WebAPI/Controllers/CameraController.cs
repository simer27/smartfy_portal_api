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
    public class CameraController : ApiController
    {
        readonly DbSet<Camera> repository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="db"></param>
        public CameraController(ApplicationDbContext db) : base(db)
        {
            repository = db.Cameras;
        }

        /// <summary>
        /// Retorna Lista de Cameras
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
                return Ok(repository.ToList());
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
                var result = repository.FirstOrDefault(c => c.Id == id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Cadastro Cameras
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add([FromBody] Camera vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                repository.Add(vm);

                var result = Db.SaveChanges();
                return Created("", true);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Atualizar Cameras
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Edit([FromBody] Camera vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                repository.Update(vm);
                var result = Db.SaveChanges();
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Deletar Cameras
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var item = repository.FirstOrDefault(c => c.Id == id);
                repository.Remove(item);
                Db.SaveChanges();
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}