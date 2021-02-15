using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using smartfy.portal_api.presentation.UI.Web.Controllers.Api;
using smartfy.portal_api.presentation.UI.Web.DataTables;
using smartfy.portal_api.presentation.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartfy.portal_api.presentation.UI.Web.Controllers
{
    public class FabricanteController : BaseController
    {
        public FabricanteController(ApplicationDbContext db) : base(db)
        {
        }
        #region INDEX
        [HttpGet]
        public IActionResult Index() => View();
        #region FILTERS
        [HttpGet]
        public IActionResult Pesquisa()
        {
            LoadViewBags();

            return View(new FabricanteViewModel()
            {
                Fabricantes = Db.Fabricantes.ToList(),
                FilterCodigo = string.Empty,
                FilterNome = string.Empty,// AMADOR => ""
                FilterCnpj = string.Empty,
                FilterEndereco = string.Empty,
                FilterTelefone = string.Empty

            }); //Model da View = List de Produtos
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Pesquisa(FabricanteViewModel vm)
        {
            LoadViewBags();

            //Filters - BEGINS
            var clientesFiltrados = Db.Fabricantes.Where(r => !r.Excluded);

            clientesFiltrados = clientesFiltrados.Where(c => c.Nome.ToUpper().Contains(vm.FilterNome.ToUpper()));
            clientesFiltrados = clientesFiltrados.Where(c => c.CNPJ.Contains(vm.FilterCnpj));
            clientesFiltrados = clientesFiltrados.Where(c => c.Codigo.Contains(vm.FilterCodigo));
            clientesFiltrados = clientesFiltrados.Where(c => c.Endereco.ToUpper().Contains(vm.FilterEndereco.ToUpper()));
            clientesFiltrados = clientesFiltrados.Where(c => c.Telefone.Contains(vm.FilterTelefone));

            //Filters - ENDS

            vm.Fabricantes = clientesFiltrados.ToList();
            return View(vm); //Model da View = List de Produtos
        }
        #endregion //FILTERS
        [HttpPost]
        public async Task<JsonResult> List(GridDataRequest request = null)
        {
            return Json(await Db.Fabricantes.Where(r => r.Excluded != true)
                .Select(r => new
                {
                    DT_RowId = r.Id,
                    codigo = r.Codigo,
                    nome = r.Nome,
                    cnpj = r.CNPJ,
                    telefone = r.Telefone,
                    endereco = r.Endereco
                }).ToDataSourceAsync(request));
        }
        #endregion
        #region CRUD
        [HttpGet]
        public IActionResult Create()

        {
            LoadViewBags();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Fabricante vm)
        {
            LoadViewBags();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }


            Db.Fabricantes.Add(vm);
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso:", "Cadastro inserido com sucesso!");

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var item = Db.Fabricantes.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            LoadViewBags();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Fabricante vm)
        {

            if (!ModelState.IsValid)
            {
                LoadViewBags();
                return View(vm);
            }

            var producer = Db.Fabricantes.AsNoTracking().Where(c => c.Id == vm.Id);
            if (producer == null) return BadRequest();

            Db.Entry(vm).State = EntityState.Modified;
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso", "Cadastro atualizado com sucesso!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var item = Db.Fabricantes.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(DeleteViewModel vm)
        {
            Entity entity = new Entity();

            var item = Db.Fabricantes.FirstOrDefault(c => c.Id == vm.Id);

            if (item == null) return BadRequest();

            item.Excluded = entity.Delete();
            Db.Fabricantes.Update(item);
            Db.SaveChanges();


            NotifySuccess("Sucesso", "Produto removido com sucesso.");

            return RedirectToAction("Index");
        }
        #endregion //CRUD
        private void LoadViewBags() { }
    }
}
