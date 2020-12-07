using System;
using Microsoft.AspNetCore.Mvc;
using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using smartfy.portal_api.presentation.UI.Web.DataTables;
using System.Linq;
using System.Threading.Tasks;

namespace smartfy.portal_api.presentation.UI.Web.Controllers
{
    public class DespachoController : BaseController
    {
        public DespachoController(ApplicationDbContext db) : base(db)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(Db.Despachos);
        }

        private void GambiarraDoEliel()
        {
            for (int i = 0; i < 10; ++i)
            {
                var daysToAdd = new Random().Next(i,100);
                //PRODUTO EM DIA
                Db.Despachos.Add(new Despacho()
                {
                    ProdutoId = Db.Produtos.FirstOrDefault().Id,
                    ClienteId = Db.Clientes.FirstOrDefault().Id,
                    DtEnvio = DateTime.Now,
                    DtEntrega = DateTime.Now.AddDays(i + 4),
                    DtRecebimento = DateTime.Now.AddDays(daysToAdd)
                });

                //PRODUTO ATRASADO
                Db.Despachos.Add(new Despacho()
                {
                    ProdutoId = Db.Produtos.FirstOrDefault().Id,
                    ClienteId = Db.Clientes.LastOrDefault().Id,
                    DtEnvio = DateTime.Now,
                    DtEntrega = DateTime.Now.AddDays(i + 4),
                    DtRecebimento = DateTime.Now.AddDays(daysToAdd)
                });

                Db.SaveChanges(); //Commit
            }
        }

        

        [HttpPost]
        public async Task<JsonResult> List(GridDataRequest request = null)
        {

            GambiarraDoEliel();

            return Json(await Db.Despachos
                .Select(despacho => new
                {
                    DT_RowId = despacho.Id,
                    cliente = Db.Clientes.FirstOrDefault(c=> c.Id == despacho.ClienteId).Name,
                    dtenvio = despacho.DtEnvio.ToShortDateString(),
                    dtentrega = despacho.DtEntrega.ToShortDateString(),
                    dtrecebimento = despacho.DtRecebimento.ToShortDateString()
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
        public IActionResult Create(Despacho vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Db.Despachos.Add(vm);
            Db.SaveChanges();

            LoadViewBags();
            NotifySuccess("Sucesso:", "Cadastro inserido com sucesso!");

            return RedirectToAction("Index");
        }

        private void LoadViewBags()
        {
          
        }
    }
}
