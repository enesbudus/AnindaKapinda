using AnindaKapinda.Model;
using AnindaKapinda.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnindaKapinda.UI.MVC.Controllers
{
    public class JSONController : Controller
    {
        // GET: JSON
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index3()
        {
            return View();
        }
        public JsonResult Index4()
        {
            SepetViewModel spt = new SepetViewModel();
            spt.ProductID = 2;
            spt.Name = "sepet";
            spt.Price = 12;
            spt.Quantity = 1212;
            return Json(spt,JsonRequestBehavior.AllowGet);
        }
        
    }
}