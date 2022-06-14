using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kantin_App.Models
{
    public class OturumKontrol : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Kullanici"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Admin/Account/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}