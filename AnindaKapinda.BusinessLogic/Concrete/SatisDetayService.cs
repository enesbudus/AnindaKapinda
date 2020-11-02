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
    public class SatisDetayService : ISatisDetayService
    {
        ISatisDetayDAL _satisDetayDAL; 
        public SatisDetayService(ISatisDetayDAL satisDetayDAL)
        {
            _satisDetayDAL = satisDetayDAL;
        }
        public bool Add(SatisDetay entity)
        {
            return _satisDetayDAL.Add(entity)>0;
        }

        public bool Delete(int entityID)
        {
            
            throw new NotImplementedException();
        }

        public bool Delete(int satisID, int urunID)
        {
            SatisDetay deleted = _satisDetayDAL.Get(i => i.SatisId == satisID && i.UrunId == urunID);
            return _satisDetayDAL.Delete(deleted) > 0;
        }

        public List<SatisDetay> GetAll()
        {
            return _satisDetayDAL.GetAll().ToList();
        }

        public List<SatisDetay> GetAllByID(int satisID)
        {
            return _satisDetayDAL.GetAll(i => i.SatisId == satisID,i=>i.Urun).ToList();
        }

        public SatisDetay GetByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public SatisDetay GetByID(int satisID, int urunID)
        {
            return _satisDetayDAL.Get(i => i.SatisId == satisID && i.UrunId == urunID);
        }

        public bool Update(SatisDetay entity)
        {
            return _satisDetayDAL.Update(entity) > 0;
        }
    }
}
