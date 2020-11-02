using AnindaKapinda.BusinessLogic.Abstract;
using AnindaKapinda.Model;
using AnindaKapinda.UI.MVC.Filters;
using AnindaKapinda.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnindaKapinda.UI.MVC.Controllers
{
    [CustomAuthorize(Roles = "Uye")]
    public class HomeController : Controller
    {
        IKullaniciService _kullaniciService;
        IUrunService _urunService;
        IKategoriService _kategoriService;
        IMarkaService _markaService;
        ISatisService _satisService;
        ISiparisDurumService _siparisService;
        ISatisDetayService _satisDetay;
        IKartService _kartService;
        Kullanici kullanici;
        //int userid;
        public HomeController(IKullaniciService kullaniciService,IUrunService urunService,IKategoriService kategoriService,IMarkaService markaService,
            ISatisService satisService,ISiparisDurumService siparisService,ISatisDetayService satisDetay,IKartService kartService)
        {
            _kullaniciService = kullaniciService;
            _urunService = urunService;
            _kategoriService = kategoriService;
            _markaService = markaService;
            _satisService = satisService;
            _siparisService = siparisService;
            _satisDetay = satisDetay;
            _kartService = kartService;
            kullanici = new Kullanici();
        }
       //[CustomAuthorize(Roles = "Admin,Uye")]
        // GET: Home
        public ActionResult Index()
        {
            List<SelectListItem> marka = new List<SelectListItem>();
            foreach (var item in _markaService.GetAll())
            {
                marka.Add(new SelectListItem() { Text = item.MarkaAdi, Value = item.MarkaId.ToString() });
            }
            ViewBag.Markalar = marka;

            List<SelectListItem> kategori = new List<SelectListItem>();
            foreach (var item in _kategoriService.GetAll())
            {
                kategori.Add(new SelectListItem() { Text = item.KategoriAdi, Value = item.KategoriId.ToString() });
            }
            ViewBag.Kategoriler = kategori;

            return View(_urunService.GetAll());
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            List<SelectListItem> markalar = new List<SelectListItem>();
            foreach (var item in _markaService.GetAll())
            {
                markalar.Add(new SelectListItem() { Text = item.MarkaAdi, Value = item.MarkaId.ToString() });
            }
            ViewBag.Markalar = markalar;

            List<SelectListItem> kategoriler = new List<SelectListItem>();
            foreach (var item in _kategoriService.GetAll())
            {
                kategoriler.Add(new SelectListItem() { Text = item.KategoriAdi, Value = item.KategoriId.ToString() });
            }
            ViewBag.Kategoriler = kategoriler;

            var marka = form.Get("marka");
            var kategori = form.Get("kategori");
            if (marka != "")
            {
                int markaa = Convert.ToInt32(marka);
                return PartialView(_urunService.GetUrunByMarkaGetir(markaa));
            }
            if (kategori != "")
            {
                int kategorii = Convert.ToInt32(kategori);
                return PartialView(_urunService.GetUrunByKategoriGetir(kategorii));
            }
            else if (kategori != "" && marka != "")
            {
                int markaa = Convert.ToInt32(marka);
                int kategorii = Convert.ToInt32(kategori);
                return PartialView(_urunService.GetUrunByMarkaAndKategori(markaa, kategorii));
            }
            return View(_urunService.GetAll());
        }
       
        public PartialViewResult Menu()
        {
            //userid = ((Kullanici)Session["kullanici"]).KullaniciId;
            return PartialView(/*_kullaniciService.GetByID(userid)*/);
        }
        public ActionResult UrunDetay(int id)
        {
            Urun urun = _urunService.GetByID(id);
            return View(urun);
        }

        public ActionResult Hesabim()
        {
            int userid = ((Kullanici)Session["kullanici"]).KullaniciId;
            return View(_kullaniciService.GetByID(userid));
        }
        [HttpPost]
        public ActionResult Hesabim(Kullanici kullanici)
        {
            Kullanici updated =_kullaniciService.GetByID(kullanici.KullaniciId);
            updated.Adi = kullanici.Adi;
            updated.Soyadi = kullanici.Soyadi;
            updated.Mail = kullanici.Mail;
            updated.Sifre = kullanici.Sifre;
            updated.Telefon = kullanici.Telefon;
            updated.Adres = kullanici.Adres;
            updated.DogumTarihi = kullanici.DogumTarihi;
            _kullaniciService.Update(updated);
            return View(_kullaniciService.GetByID(kullanici.KullaniciId));
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Login","Account");
        }
        public JsonResult Sepet(int urunId)
        {
            Urun p = _urunService.GetByID(urunId);
            List<SepetViewModel> SepettekiUrunler = null;

            if (p != null)
            {
                SepetViewModel sepetDeger = new SepetViewModel();
                sepetDeger.Name = p.UrunAdi;
                sepetDeger.Price = p.UrunFiyat;
                sepetDeger.ProductID = p.UrunId;
                sepetDeger.Quantity = 1;

                if (Session["sepet"] != null)
                {
                    SepettekiUrunler = Session["sepet"] as List<SepetViewModel>;
                    SepetViewModel sepetDeger2 = SepettekiUrunler.SingleOrDefault(a => a.ProductID == sepetDeger.ProductID);
                    if (sepetDeger2 == null)
                    {
                        SepettekiUrunler.Add(sepetDeger);
                    }
                    else
                    {
                        sepetDeger2.Quantity++;
                    }
                }
                else
                {
                    SepettekiUrunler = new List<SepetViewModel>();
                    SepettekiUrunler.Add(sepetDeger);
                }

                Session["sepet"] = SepettekiUrunler;

                return Json(SepettekiUrunler.Count, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Ürün bulunamadı", JsonRequestBehavior.AllowGet);
                //return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Ürün bulunmadı");
            }
        }
        public ActionResult SepetList()
        {
            Kullanici kullanici = _kullaniciService.GetByID(((Kullanici)Session["kullanici"]).KullaniciId);
            List<SelectListItem> kartlar = new List<SelectListItem>();
            foreach (var item in _kartService.GetAllByUser(kullanici.KullaniciId))
            {
                kartlar.Add(new SelectListItem() { Text = item.KartNo.ToString(), Value = item.KartId.ToString() });
            }
            ViewBag.Kartlar = kartlar;
            List<SepetViewModel> sepet = Session["sepet"] == null ? new List<SepetViewModel>() : Session["sepet"] as List<SepetViewModel>;
            return View(sepet);
        }
        public JsonResult SepetTemizle()
        {
            Session.Remove("sepet");
           return Json("ok",JsonRequestBehavior.AllowGet);
        }
        public JsonResult SatisIslem(string kartID)
        {
            List<SepetViewModel> sepet = Session["sepet"] as List<SepetViewModel>;
            Kullanici kullanici =_kullaniciService.GetByID(((Kullanici)Session["kullanici"]).KullaniciId);
            Satis satilan = new Satis();
            satilan.KullaniciId = kullanici.KullaniciId;
            satilan.SatisTarihi = DateTime.Now;
            decimal sum = 0;
            foreach (SepetViewModel item in sepet)
            {
                sum += item.Quantity * item.Price;
            }
            satilan.ToplamTutar = sum;
            satilan.SiparisAdresi = kullanici.Adres;
            satilan.SiparisDurumId = 1;
            if (kartID=="")
            {
                satilan = null;
                return Json("kart bulunamadı", JsonRequestBehavior.AllowGet);
            }
            satilan.KartID = Convert.ToInt32(kartID);
            satilan.KargoID = 1;
            
            _satisService.Add(satilan);
            Kullanici kullanici2 = _kullaniciService.GetUserByOrders(kullanici.KullaniciId);
            Satis satinAlinan = kullanici2.Satislar.OrderByDescending(i => i.SatisId).FirstOrDefault();
            foreach (SepetViewModel item in sepet)
            {
                SatisDetay satisDetay = new SatisDetay();
                satisDetay.SatisId = satinAlinan.SatisId;
                satisDetay.UrunId = item.ProductID;
                satisDetay.UrunAdet = item.Quantity;
                satisDetay.UrunIndirim = 0;
                satisDetay.UrunFiyat = item.Price ;
                _satisDetay.Add(satisDetay);
            }

            return Json(satinAlinan.SatisId ,JsonRequestBehavior.AllowGet);
        }
        public ActionResult SatisDetay(int id)
        {
            return View(_satisDetay.GetAllByID(id));
        }
        public ActionResult KartEkle()
        {            
            return View();
        }
        [HttpPost]
        public ActionResult KartEkle(Kart kart)
        {
            Kart newKart = new Kart();
            Kullanici kullanici = _kullaniciService.GetByID(((Kullanici)Session["kullanici"]).KullaniciId);
            newKart.KartNo = kart.KartNo;
            newKart.SonKullanimTarihi = kart.SonKullanimTarihi;
            newKart.CVCNo = kart.CVCNo;
            newKart.KullaniciID = kullanici.KullaniciId;           
            bool check = _kartService.Add(newKart);
            if (check)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        
    }
}