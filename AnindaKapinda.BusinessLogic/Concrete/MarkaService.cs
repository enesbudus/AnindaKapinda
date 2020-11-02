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
    public class MarkaService : IMarkaService
    {
        IMarkaDAL _markaDAL;
        public MarkaService(IMarkaDAL markaDAL)
        {
            _markaDAL = markaDAL;
        }
        public bool Add(Marka entity)
        {
            return _markaDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Marka deleted = _markaDAL.Get(a => a.MarkaId == entityID);
            return _markaDAL.Delete(deleted) > 0;
        }

        public List<Marka> GetAll()
        {
            return _markaDAL.GetAll().ToList();
        }

        public Marka GetByID(int entityID)
        {
            return _markaDAL.Get(a => a.MarkaId == entityID);
        }

        public bool Update(Marka entity)
        {
            return _markaDAL.Update(entity) > 0;
        }
    }
}
