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
   public class SatisService : ISatisService
    {
        ISatisDAL _satisDAL;
        public SatisService(ISatisDAL satisDAL)
        {
            _satisDAL = satisDAL;
        }
        public bool Add(Satis entity)
        {
            return _satisDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Satis deleted = _satisDAL.Get(a => a.SatisId == entityID);
            return _satisDAL.Delete(deleted) > 0;
        }

        public List<Satis> GetAll()
        {
            return _satisDAL.GetAll().ToList();
        }

        public List<Satis> GetAllByUser(int kullaniciID)
        {
            return _satisDAL.GetAll(a => a.KullaniciId == kullaniciID, a => a.Kart, a => a.Kullanici).ToList();
        }

        public Satis GetByID(int entityID)
        {
            return _satisDAL.Get(a => a.SatisId == entityID);
        }

        public bool Update(Satis entity)
        {
            return _satisDAL.Update(entity)>0;
        }
    }
}
