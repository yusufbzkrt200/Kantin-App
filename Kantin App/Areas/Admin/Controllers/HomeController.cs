using Kantin_App.Models;
using System.Web.Mvc;

namespace Kantin_App.Areas.Admin.Controllers
{
    [OturumKontrol]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}