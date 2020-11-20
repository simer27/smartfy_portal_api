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
    public class PartnerController : BaseController
    {
        public PartnerController(ApplicationDbContext db) : base(db)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(
                Db.Partners.Take(10) //Todo: Habilitar Paginação
                .OrderBy(c => c.Name)
                );
        }

        [HttpPost]
        public async Task<JsonResult> List(GridDataRequest request = null)
        {
            return Json(await Db.Partners.Select(r => new
            {
                DT_RowId = r.Id,
                name = r.Name,
                email = r.Email,
                contato = r.Contact
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
        public IActionResult Create(Partner vm)
        {
            if (!ModelState.IsValid)
            {
                LoadViewBags();
                return View(vm);
            }

            Db.Partners.Add(vm);
            Db.SaveChanges();
            NotifySuccess("Sucesso:", "Cadastro inserido com sucesso!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var item = Db.Partners.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            LoadViewBags();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Partner vm)
        {
            if (!ModelState.IsValid)
            {
                LoadViewBags();
                return View(vm);
            }

            var partner = Db.Partners.AsNoTracking().Where(c => c.Id == vm.Id);
            if (partner == null) return BadRequest();

            Db.Partners.Update(vm);
            Db.SaveChanges();

            NotifySuccess("Sucesso", "Cadastro atualizado com sucesso!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var item = Db.Partners.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Partner Partner)
        {
            var item = Db.Partners.FirstOrDefault(c => c.Id == Partner.Id);

            if (item == null) return BadRequest();

            Db.Partners.Remove(item);
            Db.SaveChanges();

            NotifySuccess("Sucesso", "Cadastro removido com sucesso.");

            return RedirectToAction("Index");
        }

        private void LoadViewBags()
        {
            //Preencher ViewBag aqui
        }
    }
}
