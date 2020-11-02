using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnindaKapinda.UI.MVC.Filters
{
    public class CustomAuthorize: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["kullanici"] == null)
            {
                return false;
            }

            Kullanici currentUser = httpContext.Session["kullanici"] as Kullanici;
            if (this.Roles.Contains(currentUser.Rol.RolAdi))
            {
                return true;
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            Kullanici kullanici = filterContext.HttpContext.Session["kullanici"] as Kullanici;
            if (filterContext.HttpContext.Session["kullanici"] == null)//HttpContext web sitesindeki session lara ulaşmaya yarar.
            {
                filterContext.Result = new RedirectResult("/Account/Login");
            }
            else
            {
                if (kullanici.Rol.RolAdi == "Admin")
                {
                    filterContext.Result = new RedirectResult("/Admin/Index");
                }
                else
                {
                    filterContext.Result = new RedirectResult("/Home/Index");
                }
            }
           
        }
    }
}