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
    public class SiparisDurumService : ISiparisDurumService
    {
        ISiparisDurumDAL _siparisDurumDAL;
        public SiparisDurumService(ISiparisDurumDAL siparisDurumDAL)
        {
            _siparisDurumDAL = siparisDurumDAL;
        }
        public bool Add(SiparisDurum entity)
        {
            return _siparisDurumDAL.Add(entity)>0;
        }

        public bool Delete(int entityID)
        {
            SiparisDurum deleted = _siparisDurumDAL.Get(a => a.SiparisId == entityID);
            return _siparisDurumDAL.Delete(deleted) > 0;
        }

        public List<SiparisDurum> GetAll()
        {
            return _siparisDurumDAL.GetAll().ToList();
        }

        public SiparisDurum GetByID(int entityID)
        {
            return _siparisDurumDAL.Get(a => a.SiparisId == entityID);
        }

        public bool Update(SiparisDurum entity)
        {
            return _siparisDurumDAL.Update(entity) > 0;
        }
    }
}
