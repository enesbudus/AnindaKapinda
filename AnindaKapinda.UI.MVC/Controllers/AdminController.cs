using AnindaKapinda.BusinessLogic.Abstract;
using AnindaKapinda.BusinessLogic.Concrete;
using AnindaKapinda.Model;
using AnindaKapinda.UI.MVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnindaKapinda.UI.MVC.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        IUrunService _urunService;
        IKategoriService _kategoriService;
        IMarkaService _markaService;
        IKullaniciService _kullaniciService;
        public AdminController(IUrunService urunService, IKategoriService kategoriService, IMarkaService markaService,IKullaniciService kullaniciService)
        {
            _urunService = urunService;
            _kategoriService = kategoriService;
            _markaService = markaService;
            _kullaniciService = kullaniciService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    
        public ActionResult Urun()
        {   /*var tablo =(from a in )*/


            ViewBag.Kategoriler = _kategoriService.GetAll();
            ViewBag.Markalar = _markaService.GetAll();

            return View(_urunService.GetUrunByMarka());
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Login","Account");
        }
        public ActionResult UrunEkle()
        {
            List<SelectListItem> kategoriler = new List<SelectListItem>();
            foreach (Kategori item in _kategoriService.GetAll())
            {
                kategoriler.Add(new SelectListItem() { Text = item.KategoriAdi, Value = item.KategoriId.ToString() });
            }
            ViewBag.Kategoriler = kategoriler;
            List<SelectListItem> markalar = new List<SelectListItem>();
            foreach (Marka item in _markaService.GetAll())
            {
                markalar.Add(new SelectListItem() { Text = item.MarkaAdi, Value = item.MarkaId.ToString() });
            }
            ViewBag.Markalar = markalar;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            List<SelectListItem> kategoriler = new List<SelectListItem>();
            foreach (Kategori item in _kategoriService.GetAll())
            {
                kategoriler.Add(new SelectListItem() { Text = item.KategoriAdi, Value = item.KategoriId.ToString() });
            }
            ViewBag.Kategoriler = kategoriler;
            List<SelectListItem> markalar = new List<SelectListItem>();
            foreach (Marka item in _markaService.GetAll())
            {
                markalar.Add(new SelectListItem() { Text = item.MarkaAdi, Value = item.MarkaId.ToString() });
            }
            ViewBag.Markalar = markalar;
            Urun newUrun = new Urun();
            newUrun.UrunAdi = urun.UrunAdi;
            newUrun.UrunDetay = urun.UrunDetay;
            newUrun.UrunFiyat = urun.UrunFiyat;
            newUrun.Stok = urun.Stok;
            newUrun.KategoriId = urun.KategoriId;
            newUrun.MarkaId = urun.MarkaId;
            newUrun.EklenmeTarihi = urun.EklenmeTarihi;
            bool kontrol = _urunService.Add(newUrun);
            return RedirectToAction("Urun");

        }
        public ActionResult UrunGuncelle(int id)
        {
            List<SelectListItem> kategoriler = new List<SelectListItem>();
            foreach (Kategori item in _kategoriService.GetAll())
            {
                kategoriler.Add(new SelectListItem() { Text = item.KategoriAdi, Value = item.KategoriId.ToString() });
            }
            ViewBag.Kategoriler = kategoriler;
            List<SelectListItem> markalar = new List<SelectListItem>();
            foreach (Marka item in _markaService.GetAll())
            {
                markalar.Add(new SelectListItem() { Text = item.MarkaAdi, Value = item.MarkaId.ToString() });
            }
            ViewBag.Markalar = markalar;
            Urun urun = _urunService.GetByID(id);
            return View(urun);
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urun urun)
        {
            List<SelectListItem> kategoriler = new List<SelectListItem>();
            foreach (Kategori item in _kategoriService.GetAll())
            {
                kategoriler.Add(new SelectListItem() { Text = item.KategoriAdi, Value = item.KategoriId.ToString() });
            }
            ViewBag.Kategoriler = kategoriler;
            List<SelectListItem> markalar = new List<SelectListItem>();
            foreach (Marka item in _markaService.GetAll())
            {
                markalar.Add(new SelectListItem() { Text = item.MarkaAdi, Value = item.MarkaId.ToString() });
            }
            ViewBag.Markalar = markalar;
            Urun newUrun = _urunService.GetByID(urun.UrunId);
            newUrun.UrunAdi = urun.UrunAdi;
            newUrun.UrunDetay = urun.UrunDetay;
            newUrun.UrunFiyat = urun.UrunFiyat;
            newUrun.Stok = urun.Stok;
            newUrun.KategoriId = urun.KategoriId;
            newUrun.MarkaId = urun.MarkaId;
            newUrun.EklenmeTarihi = urun.EklenmeTarihi;
            _urunService.Update(newUrun);
            return RedirectToAction("Urun");
        }
        public ActionResult UrunSil(int id,string ad)
        {
            Urun urun = _urunService.GetByID(id);
            return View(urun);
        }
        [HttpPost]
        public ActionResult UrunSil(int id)
        {
           
                _urunService.Delete(id);
                return RedirectToAction("Urun");

           
         
        }
        public ActionResult Kategori()
        {   /*var tablo =(from a in )*/

            return View(_kategoriService.GetAll());
        }
        [HttpPost]
        public ActionResult Kategori(string name, string detay)
        {   /*var tablo =(from a in )*/
            //var state = new UrlHelper(Request.RequestContext).Action("Kategori","Admin");
            Kategori kategori = new Kategori();
            kategori.KategoriAdi = name;
            kategori.KategoriDetay = detay;

            bool kontrol = _kategoriService.Add(kategori);
            if (kontrol)
            {

                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            return View(_urunService.GetUrunByMarka());
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(int id, string name, string detay)
        {

            Kategori kategori = _kategoriService.GetByID(id);
            kategori.KategoriAdi = name;
            kategori.KategoriDetay = detay;
            bool kontrol = _kategoriService.Update(kategori);

            if (kontrol)
            {
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            return View(_urunService.GetUrunByMarka());
        }
        [HttpPost]
        public ActionResult KategoriSil(int id)
        {
            bool kontrol = _kategoriService.Delete(id);
            if (kontrol)
            {

                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            return View(_urunService.GetUrunByMarka());
        }
        public ActionResult Marka()
        {   /*var tablo =(from a in )*/

            return View(_markaService.GetAll());
        }
        [HttpPost]
        public ActionResult Marka(string name, string detay)
        {   /*var tablo =(from a in )*/

            Marka marka = new Marka();
            marka.MarkaAdi = name;
            marka.MarkaAciklama = detay;
            bool control = _markaService.Add(marka);
            if (control)
            {
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            return View(_markaService.GetAll());
        }
        [HttpPost]
        public ActionResult MarkaGuncelle(int id, string name, string detay)
        {   /*var tablo =(from a in )*/

            Marka marka = _markaService.GetByID(id);
            marka.MarkaAdi = name;
            marka.MarkaAciklama = detay;
            bool control = _markaService.Update(marka);
            if (control)
            {
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            return View(_markaService.GetAll());
        }
        [HttpPost]
        public ActionResult MarkaSil(int id)
        {   /*var tablo =(from a in )*/


            bool control = _markaService.Delete(id);
            if (control)
            {
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            return View(_markaService.GetAll());
        }
        public ActionResult Uye()
        {
            
            return View(_kullaniciService.GetAllByUyeID(3));
        }
    }
}