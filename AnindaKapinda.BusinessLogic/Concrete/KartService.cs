using AnindaKapinda.BusinessLogic.Abstract;
using AnindaKapinda.DataAccess.Abstract;
using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.BusinessLogic.Concrete
{
    public class KartService : IKartService
    {
        IKartDAL _kartDAL;
        public KartService(IKartDAL kartDAL)
        {
            _kartDAL = kartDAL;
        }
        public bool Add(Kart entity)
        {
            return _kartDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Kart deleted = _kartDAL.Get(a => a.KartId == entityID);
            return _kartDAL.Delete(deleted) > 0;
        }

        public List<Kart> GetAll()
        {
            return _kartDAL.GetAll().ToList();
        }

        public List<Kart> GetAllByUser(int kullaniciID)
        {
            return _kartDAL.GetAll(a => a.KullaniciID == kullaniciID, a => a.Kullanici).ToList();
        }

        public Kart GetByID(int entityID)
        {
            return _kartDAL.Get(a => a.KartId == entityID);
        }

        public bool Update(Kart entity)
        {
            return _kartDAL.Update(entity) > 0;
        }
    }
}
