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
    public class DiskController : BaseController
    {
        public DiskController(ApplicationDbContext db) : base(db)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(
                Db.Disks.Include(d => d.Dockstation)
                //.Take(10) //Todo: Habilitar Paginação Problena na listagem do docstation
                .OrderBy(c => c.Name)
                );
        }

        [HttpPost]
        public async Task<JsonResult> List(GridDataRequest request = null)
        {
            return Json(await Db.Disks
                .Include("Dockstation")
                .Select(r => new
                {
                    DT_RowId = r.Id,
                    name = r.Name,
                    length = r.LengthGB,
                    dock = r.Dockstation.Code
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
        public IActionResult Create(Disk vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Db.Disks.Add(vm);
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso:", "Cadastro inserido com sucesso!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var item = Db.Disks.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            LoadViewBags();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Disk vm)
        {
            if (!ModelState.IsValid)
            {
                LoadViewBags();
                return View(vm);
            }

            var partner = Db.Disks.AsNoTracking().Where(c => c.Id == vm.Id);
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
            var item = Db.Disks.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Disk entity)
        {
            var item = Db.Disks.FirstOrDefault(c => c.Id == entity.Id);

            if (item == null) return BadRequest();

            Db.Disks.Remove(item);
            Db.SaveChanges();


            NotifySuccess("Sucesso", "Cadastro removido com sucesso.");

            return RedirectToAction("Index");
        }

        private void LoadViewBags()
        {
            ViewBag.Dockstations = Db.Dockstations.ToList();
        }
    }
}
