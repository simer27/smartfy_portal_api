using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;

namespace smartfy.portal_api.presentation.UI.Web.Controllers.Api
{
    [Route("api")]
    [Authorize]
    [ApiController]
    public class DashboardController : BaseApiController
    {
        public DashboardController(ApplicationDbContext context) : base(context)
        {
        }

        [HttpGet]
        [Route("areas")]
        public IActionResult Get()
        {
            return Response(
                _context.Areas.ToList()
            );
        }

        [HttpGet("all")]
        public async Task<JsonResult> FullDataSetAsync()
        {
            //var query = from file in _context.Files.Include(f => f.Camera)
            //            .ThenInclude(c => c.Team).ThenInclude(t => t.Partner)
            //            select file;



            //var lastWeekCameras = await _context.Cameras.Where(c => c.DtActivation > DateTime.Now.AddDays(-7)).ToListAsync();

            //var teams = await _context.Teams.CountAsync();

            var cameras = await _context.Cameras.LongCountAsync();
            var camerasInOperation = await _context.Cameras.Where(c => c.InOperation).LongCountAsync();


            var partners = from partner in _context.Partners.Include(p => p.Teams).ThenInclude(t => t.Cameras)
                           select new
                           {
                               partner.Id,
                               partner.Name,
                               registered = partner.CreationDate.ToShortDateString(),
                               partner.Contact,
                               email = partner.Contact,
                               percentage = (double)camerasInOperation / cameras * 10000,
                               Teams = partner.Teams.Select(t => new
                               {
                                   t.Id,
                                   Cameras = t.Cameras.Select(c => new { c.Id, c.InOperation })
                               })
                           };
            var model = await partners.ToListAsync();
            return Json(model);
        }
        [HttpGet("files-drill")]
        public async Task<JsonResult> FilesDrill(DateTime? start, DateTime? end, Guid? partnerId)
        {
            var query = from files in _context.Files select files;

            if (start.HasValue)
            {
                query = from files in query
                        where files.DtCopy >= start
                        select files;
            }
            if (end.HasValue)
            {
                query = from files in query
                        where files.DtCopy <= end
                        select files;
            }
            if (partnerId.HasValue)
            {
                query = from files in query.Include(f => f.Camera).ThenInclude(c => c.Team)
                        where files.Camera.Team.PartnerId == partnerId
                        select files;
            }
            return Json(await query.ToListAsync());
        }
    }
}