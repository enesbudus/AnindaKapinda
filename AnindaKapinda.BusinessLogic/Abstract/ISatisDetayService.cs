using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.BusinessLogic.Abstract
{
   public interface ISatisDetayService: IBaseService<SatisDetay>
    {
         bool Delete(int satisID, int urunID);
         SatisDetay GetByID(int satisID, int urunID);
        List<SatisDetay> GetAllByID(int satisID);
    }
}
