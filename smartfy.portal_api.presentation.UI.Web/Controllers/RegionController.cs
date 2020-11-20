using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using smartfy.portal_api.presentation.UI.Web.DataTables;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace smartfy.portal_api.presentation.UI.Web.Controllers
{
    public class RegionController : BaseController
    {
        public RegionController(ApplicationDbContext db) : base(db)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(Db.Regions.Take(10) //Todo: Habilitar Paginação
                .OrderBy(c => c.Code)
                );
        }

        [HttpPost]
        public async Task<JsonResult> List(GridDataRequest request = null)
        {
            return Json(await Db.Regions.Select(d => new
            {
                DT_RowId = d.Id,
                name = d.Code,
                Editar = ""
            }).ToDataSourceAsync(request));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Region vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Db.Regions.Add(vm);
            Db.SaveChanges();

            NotifySuccess("Sucesso:", "Cadastro inserido com sucesso!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var item = Db.Regions.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Region vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var partner = Db.Regions.AsNoTracking().Where(c => c.Id == vm.Id);
            if (partner == null) return BadRequest();

            Db.Entry(vm).State = EntityState.Modified;
            Db.SaveChanges();

            NotifySuccess("Sucesso", "Cadastro atualizado com sucesso!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var item = Db.Regions.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Region entity)
        {
            var item = Db.Regions.FirstOrDefault(c => c.Id == entity.Id);

            if (item == null) return BadRequest();

            Db.Regions.Remove(item);
            Db.SaveChanges();
            NotifySuccess("Sucesso", "Cadastro removido com sucesso.");
            return RedirectToAction("Index");
        }
    }
}
