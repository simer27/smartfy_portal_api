using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using smartfy.portal_api.presentation.UI.Web.Controllers.Api;
using smartfy.portal_api.presentation.UI.Web.DataTables;
using smartfy.portal_api.presentation.UI.Web.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace smartfy.portal_api.presentation.UI.Web.Controllers
{
    public class ClienteController : BaseController
    {
        public ClienteController(ApplicationDbContext db) : base(db)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(Db.Clientes);
        }

        [HttpPost]
        public async Task<JsonResult> List(GridDataRequest request = null)
        {
            return Json(await Db.Clientes
                .Select(r => new
                {
                    DT_RowId = r.Id,
                    name = r.Name,
                    cpf = r.CPF,
                    address = r.Address
                }).ToDataSourceAsync(request));
        }
        #region CRUD
        [HttpGet]
        public IActionResult Create()
        {
            LoadViewBags();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Cliente vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Db.Clientes.Add(vm);
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso:", "Cadastro inserido com sucesso!");

            return RedirectToAction("Index");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateBulkInsert(ClienteVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            foreach (var cliente in vm.Clientes)
            {
                Db.Clientes.Add(cliente);
            }
           
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso:", "Cadastro inserido com sucesso!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var person = Db.Clientes.FirstOrDefault(c => c.Id == id);

            if (person == null) return BadRequest();

            LoadViewBags();

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente vm)
        {

            if (!ModelState.IsValid)
            {
                LoadViewBags();
                return View(vm);
            }
            var partner = Db.Clientes.AsNoTracking().Where(c => c.Id == vm.Id);
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
            var person = Db.Clientes.FirstOrDefault(c => c.Id == id);

            if (person == null) return BadRequest();

            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(DeleteViewModel vm)
        {
            Entity entity = new Entity();

            var person = Db.Clientes.FirstOrDefault(c => c.Id == vm.Id);

            if (person == null) return BadRequest();

            //Utilizei a função Delete da Classe Entity
            //Função utiliza o campo excluded

            person.Excluded = entity.Delete();
            Db.Clientes.Update(person);
            //Db.Produtos.Remove(item);
            Db.SaveChanges();


            NotifySuccess("Sucesso", "Produto removido com sucesso.");

            return RedirectToAction("Index");
        }

        #endregion
        private void LoadViewBags()
        {
        }
    }
}
