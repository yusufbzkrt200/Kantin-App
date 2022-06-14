using Kantin.DATA.DataAccess;
using Kantin.DATA.Entity;
using Kantin_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kantin_App.Areas.Admin.Controllers
{
    [OturumKontrol]
    public class ShoppingController : Controller
    {
        // GET: Admin/Shopping
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UrunEkle(int id)
        {
            var data = ProductDataAccess.Product(id);

            if (MyCart.Cart == null)
            {
                MyCart.Cart = new List<Cart>()
                {
                    new Cart()
                    {
                        Urun=data,
                        Adet=1
                    }
                };
                MyCart.Toplam = (data.Price * 1);
            }
            else
            {
                var cart = MyCart.Cart.Where(i => i.Urun.Id == data.Id).FirstOrDefault();

                if (cart != null)
                {
                    cart.Adet++;
                }
                else
                {
                    MyCart.Cart.Add(new Cart()
                    {
                        Urun = data,
                        Adet = 1
                    });
                }
                MyCart.Toplam = MyCart.Toplam + data.Price;


            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteFromCart(int id)
        {
            var data = ProductDataAccess.Product(id);

            var cart = MyCart.Cart.Where(i => i.Urun.Id == data.Id).FirstOrDefault();
            if (cart.Adet == 1)
            {
                MyCart.Cart.Remove(cart);

            }
            else
            {
                cart.Adet--;
            }
            MyCart.Toplam = MyCart.Toplam - data.Price;

            return RedirectToAction("Index");
        }

        public ActionResult ClearCart()
        {
            MyCart.Cart.Clear();
            MyCart.Toplam = 0;


            return RedirectToAction("Index");

        }

        public ActionResult Finish()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Finish(HttpPostedFileBase dosya)
        {
            var User = Session["Kullanici"] as User;

            if (dosya != null)
            {
                string dosyaYolu = Path.GetFileName(dosya.FileName);

                var yuklemeYeri = Path.Combine(Server.MapPath("~/Areas/Admin/Faturas/"), dosyaYolu);
                dosya.SaveAs(yuklemeYeri);

                string urunlers = "";
                foreach (var urun in MyCart.Cart)
                {
                    urunlers = urunlers + urun.Adet + "*" + urun.Urun.Name + "-";
                    var data = ProductDataAccess.Satis(urun.Urun.Id);
                }

                Fatura fatura = new Fatura()
                {
                    Cash = true,
                    Iade = false,
                    Date = DateTime.Now,
                    Urunler = urunlers,
                    Toplam = MyCart.Toplam,
                    UserId = User.Id,
                    FaturaLink = dosyaYolu,

                };

                var sonuc = ShoppingDataAccess.FaturaOlustur(fatura);

                if (sonuc)
                {
                    ClearCart();
                }
            }
            else
            {
                string urunlers = "";
                foreach (var urun in MyCart.Cart)
                {
                    urunlers = urunlers + urun.Adet + "*" + urun.Urun.Name + "-";
                    var data = ProductDataAccess.Satis(urun.Urun.Id);

                }

                Fatura fatura = new Fatura()
                {
                    Cash = false,
                    Iade = false,
                    Date = DateTime.Now,
                    Urunler = urunlers,
                    Toplam = MyCart.Toplam,
                    UserId = User.Id,

                };

                var sonuc = ShoppingDataAccess.FaturaOlustur(fatura);

                if (sonuc)
                {
                    ClearCart();
                }
            }

            return RedirectToAction("Index");
        }

        public PartialViewResult GetCart()
        {
            return PartialView("GetCart");
        }

        public PartialViewResult GetProducts(int id, string search)
        {
            var data = ProductDataAccess.CategoryUrun(id, search).Where(i => i.Stock > 0).ToList();
            return PartialView("GetProducts", data);
        }

        public ActionResult Faturalar()
        {
            var data = ShoppingDataAccess.TumFaturalar().OrderByDescending(a=>a.Date).ToList();
            var kullanicilar = UserDataAccess.Users();
            ViewBag.Kullanicilar = kullanicilar;
            return View(data);
        }

        public ActionResult FaturaSil(int id)
        {
            ShoppingDataAccess.FaturaSil(id);

            return RedirectToAction("Faturalar");
        }

        public ActionResult FaturaDetay(int id)
        {
            var data = ShoppingDataAccess.FaturaGetir(id);

            return View(data);
        }

        public ActionResult Iade(int id)
        {
            var Fatura = ShoppingDataAccess.FaturaGetir(id);

            string urunler = Fatura.Urunler;

            List<Product> products = new List<Product>();
            var db = new DataContext();
            string[] words = urunler.Split('-');
            words = words.Where(x => !String.IsNullOrEmpty(x)).ToArray();
            foreach (var item in words)
            {
                int count = int.Parse(item.Substring(0,1));
                for (int i = 0; i < count; i++)
                {
                    var name = item.Substring(2);
                    var lastName = name;
                    var product = db.Products.Where(a => a.Name == lastName).FirstOrDefault();
                    var data = ProductDataAccess.Iade(product.Id);
                }

            }

            Fatura faturaNew = new Fatura()
            {
                Iade=true,
                Cash = Fatura.Cash,
                Date = DateTime.Now,
                FaturaLink=Fatura.FaturaLink,
                Toplam=(-1)*Fatura.Toplam,
                Urunler = Fatura.Urunler,
                UserId=Fatura.UserId
            };

            var FaturaOlustur = ShoppingDataAccess.FaturaOlustur(faturaNew);

            return RedirectToAction("Faturalar");
        }

        public ActionResult UrunIade(int id)
        {
            var data = ProductDataAccess.Product(id);
            var User = Session["Kullanici"] as User;

            Fatura fatura = new Fatura()
            {
                Cash = false,
                Date = DateTime.Now,
                Iade=true,
                Toplam=(data.Price)*-1,
                Urunler="1*"+data.Name,
                UserId =User.Id
                
            };

            var FaturaOlustur = ShoppingDataAccess.FaturaOlustur(fatura);


            return RedirectToAction("Index","Shopping");
        }

    }



}