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
    public class KargoService : IKargoService
    {
        IKargoDAL _kargoDAL;
        public KargoService(IKargoDAL kargoDAL)
        {
            _kargoDAL = kargoDAL;
        }
        public bool Add(Kargo entity)
        {
            return _kargoDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Kargo deleted = _kargoDAL.Get(a => a.KargoId == entityID);
            return _kargoDAL.Delete(deleted) > 0;
        }

        public List<Kargo> GetAll()
        {
            return _kargoDAL.GetAll().ToList();
        }

        public Kargo GetByID(int entityID)
        {
            return _kargoDAL.Get(a => a.KargoId == entityID);
        }

        public bool Update(Kargo entity)
        {
            return _kargoDAL.Update(entity) > 0;
        }
    }
}
