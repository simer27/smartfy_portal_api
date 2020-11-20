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
    public class CameraController : BaseController
    {
        public CameraController(ApplicationDbContext db) : base(db)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(
                Db.Cameras.Include(c => c.Team)
                    .Take(10) //Todo: Habilitar Paginação
                .OrderBy(c => c.Code)
                );
        }

        [HttpPost]
        public async Task<JsonResult> List(GridDataRequest request = null)
        {
            return Json(await Db.Cameras
                .Include("Team")
                .Select(r => new
                {
                    DT_RowId = r.Id,
                    code = r.Code,
                    model = r.Model,
                    manufacturer = r.Manufacturer,
                    team = r.Team.Code
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
        public IActionResult Create(Camera vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            vm.TeamId = vm.TeamId;
            Db.Cameras.Add(vm);
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso:", "Cadastro inserido com sucesso!");

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var item = Db.Cameras.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            LoadViewBags();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Camera vm)
        {
            if (!ModelState.IsValid)
            {
                LoadViewBags();
                return View(vm);
            }

            var partner = Db.Cameras.AsNoTracking().Where(c => c.Id == vm.Id);
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
            var item = Db.Cameras.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Camera camera)
        {
            var item = Db.Cameras.FirstOrDefault(c => c.Id == camera.Id);

            if (item == null) return BadRequest();

            Db.Cameras.Remove(item);
            Db.SaveChanges();


            NotifySuccess("Sucesso", "Cadastro removido com sucesso.");

            return RedirectToAction("Index");
        }

        private void LoadViewBags()
        {
            ViewBag.Equipes = Db.Teams.ToList();
        }
    }
}
