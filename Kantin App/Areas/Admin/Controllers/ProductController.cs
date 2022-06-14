using Kantin.DATA.DataAccess;
using Kantin.DATA.Entity;
using Kantin_App.Models;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Kantin_App.Areas.Admin.Controllers
{

    [OturumKontrol]
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {

            var List = ProductDataAccess.ProductList();
            return View(List);
        }

        public ActionResult UrunEkle()
        {
            ViewBag.Categories = CategoryDataAccess.CategoryList();

            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Product model, HttpPostedFileBase dosya)
        {
            ViewBag.Categories = CategoryDataAccess.CategoryList();

            if (dosya == null)
            {
                ViewBag.Hata = "Lütfen dosya seçiniz";
                return View(model);
            }

            var dosyaYolu = Path.GetExtension(dosya.FileName);

            var yuklemeYeri = Path.Combine(Server.MapPath("~/Areas/Admin/Products/"), dosyaYolu);
            dosya.SaveAs(yuklemeYeri);
            model.UrunLink = dosyaYolu;



            if (model != null)
            {
                var sonuc = ProductDataAccess.Add(model);
            }

            return RedirectToAction("Index", "Product");
        }

        public ActionResult UrunGuncelle(int id)
        {
            var data = ProductDataAccess.Product(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult UrunGuncelle(Product model, HttpPostedFileBase dosya)
        {
            if (dosya == null)
            {
                if (model == null)
                {
                    ViewBag.Hata = "Lütfen dosya seçiniz";
                    return View(model);
                }

                var sonuc = ProductDataAccess.UpdateProduct(model);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }

                ViewBag.Hata = "Hata Oluştu Tekrar Deneyiniz..";
                return View(model);
            }
            else
            {
                string dosyaYolu = Path.GetFileName(dosya.FileName);

                var yuklemeYeri = Path.Combine(Server.MapPath("~/Areas/Admin/Products/"), dosyaYolu);
                dosya.SaveAs(yuklemeYeri);
                model.UrunLink = dosyaYolu;

                if (model == null)
                {
                    ViewBag.Hata = "Lütfen dosya seçiniz";
                    return View(model);
                }

                var sonuc = ProductDataAccess.UpdateProduct(model);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }

                ViewBag.Hata = "Hata Oluştu Tekrar Deneyiniz..";
                return View(model);
            }



        }

        public ActionResult UrunSil(int id)
        {
            var sonuc = ProductDataAccess.Delete(id);
            return RedirectToAction("Index");
        }

        public PartialViewResult GetProducts(int id, string search)
        {
            var data = ProductDataAccess.CategoryUrun(id, search);
            var category = CategoryDataAccess.CategoryList();
            ViewBag.Category = category;
            return PartialView("GetProducts", data);
        }
    }
}