﻿using Microsoft.AspNetCore.Mvc;
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
    public class ProdutoController : BaseController
    {
        public ProdutoController(ApplicationDbContext db) : base(db)
        {
        }
        #region INDEX
        [HttpGet]
        public IActionResult Index() => View(); //return View();

        #region FILTERS
        [HttpGet]
        public IActionResult Pesquisa()
        {
            LoadViewBags();

            return View(new ProdutoViewModel()
            {
                Produtos = Db.Produtos.ToList(),
                FilterDtCadastroDe = DateTime.Now.ToFirstDayOfMonth(),
                FilterDtCadastroAte = DateTime.Now.ToLastDayOfMonthSmartest(),
                FilterStatus = EStatus.None,
                FilterCodigo = string.Empty,
                FilterDescricao = string.Empty // AMADOR => ""
            }); //Model da View = List de Produtos
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Pesquisa(ProdutoViewModel vm)
        {
            LoadViewBags();

            //Filters - BEGINS
            var produtosFiltrados = Db.Produtos.Where(r => !r.Excluded && r.IsVencido());

            if (!string.IsNullOrEmpty(vm.FilterDescricao))
                produtosFiltrados = produtosFiltrados.Where(c => c.Descricao.ToUpper().Contains(vm.FilterDescricao.ToUpper()));
            produtosFiltrados = produtosFiltrados.Where(c => c.Codigo.ToUpper().Contains(vm.FilterCodigo.ToUpper()));
            produtosFiltrados = produtosFiltrados.Where(r => vm.FilterDtCadastroAte.IsValid() ? r.CreationDate.IsBetween(vm.FilterDtCadastroDe, vm.FilterDtCadastroAte) : true);
            produtosFiltrados = produtosFiltrados.Where(r => vm.FilterStatus != EStatus.None ? r.Status.Equals(vm.FilterStatus) : true);

            //Filters - ENDS

            vm.Produtos = produtosFiltrados.ToList();
            return View(vm); //Model da View = List de Produtos
        }
        #endregion //FILTERS

        [HttpPost]
        public async Task<JsonResult> List(GridDataRequest request = null)
        {
            return Json(await Db.Produtos.Where(r => r.Excluded != true)
                .Select(r => new
                {
                    DT_RowId = r.Id,
                    codigo = r.Codigo,
                    descricao = r.Descricao,
                    dtvencimento = r.DtVencimento.ToString("dd/MM/yyyy"),
                    isperecivel = r.IsPerecivel ? "Sim" : "Nao",
                    status = r.Status == EStatus.Inativo ? "Inativo" : "Ativo",
                    numeroserie = r.NumeroSerie,
                    preco = r.Preco,
                    observacao = r.Observacao
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
        public IActionResult Create(Produto vm)
        {
            LoadViewBags();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Random randNum = new Random();
            vm.NumeroSerie ="SFY" + randNum.Next().ToString();

            //if (!string.IsNullOrEmpty(vm.NumeroSerie))
            //{
            //    return View(vm);
            //}

            Db.Produtos.Add(vm);
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso:", "Cadastro inserido com sucesso!");

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var item = Db.Produtos.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            LoadViewBags();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produto vm)
        {

            if (!ModelState.IsValid)
            {
                LoadViewBags();
                return View(vm);
            }

            //if (!string.IsNullOrEmpty(vm.NumeroSerie) && !vm.NumeroSerie.StartsWith("SFY"))
            //{
            //    ModelState.AddModelError("NumeroSerie", "Número de série inválido.");
            //    return View(vm);
            //}

            var partner = Db.Produtos.AsNoTracking().Where(c => c.Id == vm.Id);
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
            var item = Db.Produtos.FirstOrDefault(c => c.Id == id);

            if (item == null) return BadRequest();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(DeleteViewModel vm)
        {
            Entity entity = new Entity();

            var item = Db.Produtos.FirstOrDefault(c => c.Id == vm.Id);

            if (item == null) return BadRequest();
            
            //Utilizei a função Delete da Classe Entity
            //Função utiliza o campo excluded
            
            item.Excluded = entity.Delete();
            Db.Produtos.Update(item);
            //Db.Produtos.Remove(item);
            Db.SaveChanges();


            NotifySuccess("Sucesso", "Produto removido com sucesso.");

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

            // Combobox/DropDownList from DB
            ViewBag.ClientesSemNumero3 = Db.Clientes.Where(a => !a.CPF.StartsWith("3")).Select(c => new SelectListItem($"{c.Name} - {c.CPF}", c.Id.ToString()));
            ViewBag.ClientesComNumero3 = Db.Clientes.Where(a => a.CPF.StartsWith("3")).Select(c => new SelectListItem($"{c.Name} - {c.CPF}", c.Id.ToString()));

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
