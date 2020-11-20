using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using System.Linq;

namespace smartfy.portal_api.services.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class DashboardController : ApiController
    {
        public DashboardController(ApplicationDbContext db) : base(db)
        {

        }

        /// <summary>
        /// Retorna Lista de Areas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Response(Db.Areas.ToList());
        }

        /// <summary>
        /// Cadastro Area
        /// </summary>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Add([FromBody] Area vm)
        {
            if (!ModelState.IsValid) return ModelStateError();

            Db.Areas.Add(vm);

            Db.SaveChanges();

            return Response(Ok());
        }
    }
}