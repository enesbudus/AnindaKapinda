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
    public class UrunService : IUrunService
    {
        IUrunDAL _urunDAL;
        public UrunService(IUrunDAL urunDAL)
        {
            _urunDAL = urunDAL;
        }
        public bool Add(Urun entity)
        {
            return _urunDAL.Add(entity) > 0;
        }

        public bool Delete(int entityID)
        {
            Urun deleted = _urunDAL.Get(a => a.UrunId == entityID);
            return _urunDAL.Delete(deleted) > 0;
        }

        public List<Urun> GetAll()
        {
            return _urunDAL.GetAll().ToList();
        }

        public Urun GetByID(int entityID)
        {
            return _urunDAL.Get(a => a.UrunId == entityID);
        }

        public List<Urun> GetUrunByKategoriGetir(int kategoriId)
        {
            return _urunDAL.GetAll(m => m.KategoriId == kategoriId).ToList();
        }

        public List<Urun> GetUrunByMarka()
        {
            return _urunDAL.GetAll(null,m=>m.Marka,m=>m.Kategori ).ToList();
        }

        public List<Urun> GetUrunByMarkaAndKategori(int markaId, int kategoriId)
        {
            return _urunDAL.GetAll(m => m.KategoriId == kategoriId&&m.MarkaId==markaId).ToList();
        }

        public List<Urun> GetUrunByMarkaGetir(int markaId)
        {
            return _urunDAL.GetAll(m => m.MarkaId == markaId).ToList();
        }

        public bool Update(Urun entity)
        {
            return _urunDAL.Update(entity) > 0;
        }
    }
}
