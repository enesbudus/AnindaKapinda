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
    public class KategoriService : IKategoriService
    {
        IKategoriDAL _kategoriDAL;
        public KategoriService(IKategoriDAL kategoriDAL)
        {
            _kategoriDAL = kategoriDAL;
        }
        public bool Add(Kategori entity)
        {
            return _kategoriDAL.Add(entity)>0;
        }

        public bool Delete(int entityID)
        {
            Kategori deleted = _kategoriDAL.Get(a => a.KategoriId == entityID);
            return _kategoriDAL.Delete(deleted) > 0;
        }

        public List<Kategori> GetAll()
        {
            return _kategoriDAL.GetAll().ToList();
        }

        public Kategori GetByID(int entityID)
        {
            return _kategoriDAL.Get(a => a.KategoriId == entityID);
        }

        public bool Update(Kategori entity)
        {
            return _kategoriDAL.Update(entity) > 0;
        }
    }
}
