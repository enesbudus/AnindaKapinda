using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.BusinessLogic.Abstract
{
   public interface IUrunService: IBaseService<Urun>
    {
        List<Urun> GetUrunByMarka();
        List<Urun> GetUrunByMarkaAndKategori(int markaId,int kategoriId);
        List<Urun> GetUrunByKategoriGetir(int kategoriId);
        List<Urun> GetUrunByMarkaGetir(int markaId);
    }
}
