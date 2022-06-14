using Kantin.DATA.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kantin_App.Controllers
{
    public class ApiController : Controller
    {


        [HttpPost]
        public JsonResult Barcode(string Barkod)
        {
            BarkodDatabase.Barcode = Barkod.ToString();
            return Json(true);
        }

        [HttpPost]
        public JsonResult Barcode2()
        {
            var data = BarkodDatabase.Barcode;
            if (data != null)
            {

                return Json(data);
            }
            else
            {
                return Json(false);
            }

        }
    }
}