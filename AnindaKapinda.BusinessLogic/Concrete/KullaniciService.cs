using AnindaKapinda.BusinessLogic.Abstract;
using AnindaKapinda.BusinessLogic.Helpers;
using AnindaKapinda.DataAccess.Abstract;
using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.BusinessLogic.Concrete
{
   public class KullaniciService : IKullaniciService,IKullaniciHelper
    {
        IKullaniciDAL _kullaniciDAL;
        public KullaniciService(IKullaniciDAL kullaniciDAL)
        {
            _kullaniciDAL = kullaniciDAL;
        }
        public bool Add(Kullanici entity)
        {
            try
            {
                CheckMail(entity.Mail);
                entity.AktivasyonKodu = Guid.NewGuid();
                entity.IsActive = false;
                return _kullaniciDAL.Add(entity) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CheckMail(string mail)
        {
            Kullanici user = _kullaniciDAL.Get(a => a.Mail == mail);
            if (user != null)
            {
                throw new Exception("Bu mail adresi zaten kayıtlı");
            }
        }

        public bool Delete(int entityID)
        {
            Kullanici deleted = _kullaniciDAL.Get(a => a.KullaniciId == entityID);
            return _kullaniciDAL.Delete(deleted) > 0;
        }

        public List<Kullanici> GetAll()
        {
            return _kullaniciDAL.GetAll().ToList();
        }

        public List<Kullanici> GetAllByUyeID(int id)
        {
            return _kullaniciDAL.GetAll(i=>i.RoleID==id).ToList();
        }

        public Kullanici GetByID(int entityID)
        {
            return _kullaniciDAL.Get(a => a.KullaniciId == entityID);
        }

        public Kullanici GetUserByCode(Guid code)
        {
            return _kullaniciDAL.Get(a => a.AktivasyonKodu == code);
        }

        public Kullanici GetUserByLogin(string mail, string sifre)
        {
            return _kullaniciDAL.Get(a => a.Mail == mail && a.Sifre == sifre && a.IsActive, a => a.Rol);
        }

        public Kullanici GetUserByOrders(int id)
        {
            return _kullaniciDAL.Get(i=>i.KullaniciId==id,i=>i.Satislar);
        }

        public bool Update(Kullanici entity)
        {
            return _kullaniciDAL.Update(entity) > 0;
        }
    }
}
