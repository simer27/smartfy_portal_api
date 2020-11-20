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
    public class DockstationController : BaseController
    {
        public DockstationController(ApplicationDbContext db) : base(db)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(
                Db.Dockstations.Include(d => d.Partner)
                //.Take(10) //Todo: Habilitar Paginação Problena na listagem do docstation
                .OrderBy(c => c.Code)
                );
        }

        [HttpPost]
        public async Task<JsonResult> List(GridDataRequest request = null)
        {
            return Json(await Db.Dockstations.Include(r => r.Partner).Select(r => new
            {
                DT_RowId = r.Id,
                name = r.Code,
                partner = r.Partner.Name
            }).ToDataSourceAsync(request));
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBags();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Dockstation vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Db.Dockstations.Add(vm);
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso:", "Cadastro inserido com sucesso!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var item = Db.Dockstations.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            LoadViewBags();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Dockstation vm)
        {
            if (!ModelState.IsValid)
            {
                LoadViewBags();
                return View(vm);
            }

            var partner = Db.Dockstations.AsNoTracking().Where(c => c.Id == vm.Id);
            if (partner == null) return BadRequest();

            Db.Entry(vm).State = EntityState.Modified;
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso", "Cadastro atualizado com sucesso!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var item = Db.Dockstations.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Dockstation entity)
        {
            var item = Db.Dockstations.FirstOrDefault(c => c.Id == entity.Id);

            if (item == null) return BadRequest();

            Db.Dockstations.Remove(item);
            Db.SaveChanges();


            NotifySuccess("Sucesso", "Cadastro removido com sucesso.");

            return RedirectToAction("Index");
        }

        private void LoadViewBags()
        {
            ViewBag.Parceiros = Db.Partners.ToList();
        }
    }
}
