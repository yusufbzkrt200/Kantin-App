using Kantin.DATA.DataAccess;
using Kantin.DATA.Entity;
using Kantin_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kantin_App.Areas.Admin.Controllers
{
    [OturumKontrol]
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var data = CategoryDataAccess.CategoryList();
            return View(data);
        }

        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Category model)
        {
            var data = CategoryDataAccess.Add(model);
            if (data)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Sil(int id)
        {
            var data = CategoryDataAccess.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Guncelle(int id)
        {
            var data = CategoryDataAccess.ReturnCategory(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Guncelle(Category model)
        {
            var data = CategoryDataAccess.Update(model);
            if (data)
            {
                return RedirectToAction("Index");
            }

            return View(model);


        }
    }
}