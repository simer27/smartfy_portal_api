using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.domain.Enums;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using smartfy.portal_api.presentation.UI.Web.Controllers.Api;
using smartfy.portal_api.presentation.UI.Web.DataTables;
using smartfy.portal_api.presentation.UI.Web.Extensions;
using smartfy.portal_api.presentation.UI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartfy.portal_api.presentation.UI.Web.Controllers
{
    public class FuncionarioController : BaseController
    {
        public FuncionarioController(ApplicationDbContext db) : base(db)
        {
        }
        #region INDEX
        [HttpGet]
        public IActionResult Index() => View();

        //#region FILTERS
        //[HttpGet]
        //public IActionResult Pesquisa()
        //{
        //    LoadViewBags();

        //    return View(new FuncionarioViewModel()
        //    {              
        //        Funcionarios = Db.Funcionarios.ToList(),                
        //        FilterNome = string.Empty,
        //        FilterFuncao = string.Empty,
        //        FilterTurno = string.Empty

        //    }); //Model da View = List de Funcionarios
        //}

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public IActionResult Pesquisa(FuncionarioViewModel vm)
        //{
        //    LoadViewBags();

        //    //Filters - BEGINS
        //    var funcionariosFiltrados = Db.Funcionarios.Where(r => !r.Excluded);

        //    funcionariosFiltrados = funcionariosFiltrados.Where(c => c.Nome.ToUpper().Contains(vm.FilterNome.ToUpper()));
        //    funcionariosFiltrados = funcionariosFiltrados.Where(c => c.Funcao.Contains(vm.FilterFuncao));
        //    funcionariosFiltrados = funcionariosFiltrados.Where(c => c.Turno.Contains(vm.FilterTurno));
            

        //    //Filters - ENDS

        //    vm.Funcionarios = funcionariosFiltrados.ToList();
        //    return View(vm); //Model da View = List de Funcionarios
        //}
        //#endregion //FILTERS
        [HttpPost]
        public async Task<JsonResult> List(GridDataRequest request = null)
        {
            return Json(await Db.Funcionarios.Where(r => r.Excluded != true)
                .Select(r => new
                {
                    DT_RowId = r.Id,
                    id_func = r.Id_Func,
                    nome = r.Nome,
                    status = r.Status == EStatus.Inativo ? "Inativo" : "Ativo",
                    funcao = r.Funcao,
                    dtadmissao = r.DtAdmissao.ToString("dd/MM/yyyy"),
                    dtdemissao = r.DtDemissao.ToString("dd/MM/yyyy"),
                    turno = r.Turno == ETurno.Manhã ? "Manhã" : (r.Turno == ETurno.Tarde ? "Tarde" : "Noite"),
                    salario = r.Salario,
                    beneficio = r.Beneficio,

                }).ToDataSourceAsync(request)) ;
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
        public IActionResult Create(Funcionario vm)
        {
            LoadViewBags();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            //db.funci transformar para tolist, vai habilitar uma funçao chamado count
            //id_func = count+1


            if (vm.DtAdmissao > vm.DtDemissao)
            {
                ModelState.AddModelError("DtDemissao", "Data de Demissão não pode ser anterior a data de Admissâo.");
                return View(vm);
            }

            Db.Funcionarios.Add(vm);
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso:", "Cadastro inserido com sucesso!");

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var item = Db.Funcionarios.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            LoadViewBags();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Funcionario vm)
        {

            if (!ModelState.IsValid)
            {
                LoadViewBags();
                return View(vm);
            }

            var producer = Db.Funcionarios.AsNoTracking().Where(c => c.Id == vm.Id);
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
            var item = Db.Funcionarios.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(DeleteViewModel vm)
        {
            Entity entity = new Entity();

            var item = Db.Funcionarios.FirstOrDefault(c => c.Id == vm.Id);

            if (item == null) return BadRequest();

            item.Excluded = entity.Delete();
            Db.Funcionarios.Update(item);
            Db.SaveChanges();


            NotifySuccess("Sucesso", "Funcionário removido com sucesso.");

            return RedirectToAction("Index");
        }
        #endregion //CRUD
        

        private void LoadViewBags()
        {
            // Combobox/DropDownList from Static
            ViewBag.Status = new List<SelectListItem>() {
                new SelectListItem( "Ativo",Convert.ToString((int)EStatus.Ativo)),
                new SelectListItem("Inativo",Convert.ToString((int)EStatus.Inativo)),
            };

            ViewBag.Turno = new List<SelectListItem>() {
                new SelectListItem( "Manhã",Convert.ToString((int)ETurno.Manhã)),
                new SelectListItem("Tarde",Convert.ToString((int)ETurno.Tarde)),
                new SelectListItem("Noite",Convert.ToString((int)ETurno.Noite)),
            };

            // Combobox/DropDownList from DB
            //ViewBag.ClientesSemNumero3 = Db.Clientes.Where(a => !a.CPF.StartsWith("3")).Select(c => new SelectListItem($"{c.Name} - {c.CPF}", c.Id.ToString()));
            //ViewBag.ClientesComNumero3 = Db.Clientes.Where(a => a.CPF.StartsWith("3")).Select(c => new SelectListItem($"{c.Name} - {c.CPF}", c.Id.ToString()));

            // Combobox/DropDownList for Filters (Codigo)
            //ViewBag.Codigo = Db.Produtos.Where(Codigo);                     
            //};

            // Combobox/DropDownList for Filters (Descricao)
            //ViewBag.Descricao = new List<SelectListItem>() {
            //    new SelectListItem( "Ativo",Convert.ToString((int)EStatus.Ativo)),
            //    new SelectListItem("Inativo",Convert.ToString((int)EStatus.Inativo)),
            //};
        }

    }
}
