using AnindaKapinda.BusinessLogic.Abstract;
using AnindaKapinda.Common;
using AnindaKapinda.Model;
using AnindaKapinda.UI.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnindaKapinda.UI.MVC.Controllers
{

    public class AccountController : Controller
    {
        IKullaniciService _kullaniciService;
        IKullaniciRolService _kullaniciRolService;
        public AccountController(IKullaniciService kullaniciService, IKullaniciRolService kullaniciRolService)
        {
            _kullaniciService = kullaniciService;
            _kullaniciRolService = kullaniciRolService;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                Kullanici user = _kullaniciService.GetUserByLogin(model.Mail, model.Password);
                if (user != null)
                {
                    if (user.Rol.RolAdi == "Admin")
                    {
                        Session["kullanici"] = user;
                        return RedirectToAction("Index", "Admin", new { id = user.KullaniciId });
                    }
                    else if (user.Rol.RolAdi == "Uye")
                    {
                        Session["kullanici"] = user;
                        return RedirectToAction("Index", "Home", new { id = user.KullaniciId });
                    }

                }
                else
                {
                    ViewBag.Hata = "Giriş bilgileri hatalı";
                }
            }

            return View();

        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserViewModel model)
        {
            Kullanici user = new Kullanici();
            user.Adi = model.Name;
            user.Soyadi = model.Surname;
            user.Mail = model.Mail;
            user.Telefon = model.Telefon;
            user.Sifre = model.Password;
            user.Adres = model.Adres;
            user.DogumTarihi = model.BirthDate;
            user.IsActive = true;//Sonradan eğiştirelecek
            user.RoleID = 3;


            try
            {
                bool result = _kullaniciService.Add(user);
                if (result)
                {
                    result= MailHelper.SendMail(user); 
                }
                
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }
        public ActionResult Activate(Guid code)
        {
            Kullanici currentUser = _kullaniciService.GetUserByCode(code);
            if (currentUser != null)
            {
                currentUser.IsActive = true;
                _kullaniciService.Update(currentUser);
            }

            return View();
        }
    }
}