using Microsoft.AspNetCore.Mvc;
using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using smartfy.portal_api.presentation.UI.Web.DataTables;
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

        private void LoadViewBags()
        {
        }
    }
}
