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
    public class TeamController : BaseController
    {
        public TeamController(ApplicationDbContext db) : base(db)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(
                Db.Teams
                .Include(a => a.Area)
                .Include(p => p.Partner)
                    .Take(10) //Todo: Habilitar Paginação
                .OrderBy(c => c.Code)
                );
        }

        [HttpPost]
        public async Task<JsonResult> List(GridDataRequest request = null)
        {
            return Json(await Db.Teams
                .Include("Area")
                .Include("Partner")
                .Select(r => new
            {
                DT_RowId = r.Id,
                code = r.Code,
                plate = r.Plate,
                area = r.Area.Name,
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
        public IActionResult Create(Team vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Db.Teams.Add(vm);
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso:", "Cadastro inserido com sucesso!");

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var item = Db.Teams.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            LoadViewBags();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Team vm)
        {
            if (!ModelState.IsValid)
            {
                LoadViewBags();
                return View(vm);
            }

            var partner = Db.Teams.AsNoTracking().Where(c => c.Id == vm.Id);
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
            var item = Db.Teams.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Team entity)
        {
            var item = Db.Teams.FirstOrDefault(c => c.Id == entity.Id);

            if (item == null) return BadRequest();

            Db.Teams.Remove(item);
            Db.SaveChanges();

            NotifySuccess("Sucesso", "Cadastro removido com sucesso.");

            return RedirectToAction("Index");
        }

        private void LoadViewBags()
        {
            ViewBag.Parceiro = Db.Partners.ToList();
            ViewBag.Area = Db.Areas.ToList();
        }
    }
}
