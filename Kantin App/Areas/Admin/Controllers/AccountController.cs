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
    public class AccountController : Controller
    {
        [OturumKontrol]
        public ActionResult Index()
        {
            var List = UserDataAccess.Users();
            return View(List);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login (string Username, string password)
        {
            if (string.IsNullOrEmpty(Username)|| string.IsNullOrEmpty(password))
            {
                ViewBag.Hata="Lütfen Formu Eksiksiz Doldurun!";
                return View();
            }

            var sonuc = UserDataAccess.Login(Username, password);


            //User user = new User()
            //{
            //    Id = 1,
            //    Name = "Yusuf",
            //    Surname = "Bozkurt",
            //    Username = "softwareruless",
            //    Password = "123456789"
            //};

            //Session["Kullanici"] = user;



            if (sonuc!=null)
            {
                Session["Kullanici"] = sonuc;
                return RedirectToAction("Index","Account");
            }
            ViewBag.Hata = "Geçersiz Kullanıcı Adı Veya Şifre";
            return View();
        }

        [OturumKontrol]
        public ActionResult Register()
        {
            return View();
        }

        [OturumKontrol]
        [HttpPost]
        public ActionResult Register(User model)
        {
            if (model!= null)
            {
                var sonuc = UserDataAccess.Add(model);
            }

            return RedirectToAction("Login", "Account");

        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            Session["Kullanici"] = null;
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Delete(int id)
        {
            var data = UserDataAccess.Sil(id);
            
            return RedirectToAction("Index");
        }

    }
}