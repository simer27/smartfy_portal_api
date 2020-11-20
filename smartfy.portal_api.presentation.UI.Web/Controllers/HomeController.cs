using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using smartfy.portal_api.Infra.CrossCutting.Identity.Entities;
using System.Diagnostics;
using System.Security.Claims;
using smartfy.portal_api.presentation.UI.Web.Models;

namespace smartfy.portal_api.presentation.UI.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;


        public HomeController(UserManager<ApplicationUser> userManager,ApplicationDbContext db) : base(db)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
            userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// will give the user's userId
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
