using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using smartfy.portal_api.presentation.UI.Web.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartfy.portal_api.presentation.UI.Web.Controllers
{
    public class EstoqueController : BaseController
    {
        public EstoqueController(ApplicationDbContext db) : base(db)
        {
        }
        #region INDEX
        [HttpGet]
        public IActionResult Index() => View();
        [HttpPost]
        public async Task<JsonResult> List(GridDataRequest request = null)
        {
            return Json(await Db.Estoques.Where(r => r.Excluded != true)
                .Select(r => new
                {
                    DT_RowId = r.Id,
                    descricao = r.Produto.Descricao,
                    quantidade = r.Quantidade,
                    reservado = r.Reservado,
                    precototalestoque = r.PrecoTotalEstoque,
                    precototalreservado = r.PrecoTotalReservado
                }).ToDataSourceAsync(request));
        }
        #endregion
        //#region CRUD
        [HttpGet]
        public IActionResult Create()

        {
            LoadViewBags();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Estoque vm)
        {
            LoadViewBags();
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            vm.PrecoTotalEstoque = vm.Quantidade * vm.Produto.Preco;
            vm.PrecoTotalReservado = vm.Reservado * vm.Produto.Preco;

            Db.Estoques.Add(vm);
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso:", "Cadastro inserido com sucesso!");

            return RedirectToAction("Index");
        }


        //[HttpGet]
        //public IActionResult Edit(Guid id)
        //{
        //    var item = Db.Fabricantes.FirstOrDefault(c => c.Id == id);

        //    if (item == null) return BadRequest();

        //    LoadViewBags();

        //    return View(item);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Fabricante vm)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        LoadViewBags();
        //        return View(vm);
        //    }

        //    var producer = Db.Fabricantes.AsNoTracking().Where(c => c.Id == vm.Id);
        //    if (producer == null) return BadRequest();

        //    Db.Entry(vm).State = EntityState.Modified;
        //    Db.SaveChanges();

        //    LoadViewBags();
        //    NotifySuccess("Sucesso", "Cadastro atualizado com sucesso!");

        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult Delete(Guid id)
        //{
        //    var item = Db.Fabricantes.FirstOrDefault(c => c.Id == id);

        //    if (item == null) return BadRequest();

        //    return View(item);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(DeleteViewModel vm)
        //{
        //    Entity entity = new Entity();

        //    var item = Db.Fabricantes.FirstOrDefault(c => c.Id == vm.Id);

        //    if (item == null) return BadRequest();

        //    item.Excluded = entity.Delete();
        //    Db.Fabricantes.Update(item);
        //    Db.SaveChanges();


        //    NotifySuccess("Sucesso", "Produto removido com sucesso.");

        //    return RedirectToAction("Index");
        //}
        //#endregion //CRUD
        private void LoadViewBags()
        {
            ViewBag.DescricaoProduto = Db.Estoques.Select(c => new SelectListItem($"{c.Produto.Descricao}", c.Id.ToString()));
        }
    }
}
