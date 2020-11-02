using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.BusinessLogic.Abstract
{
   public interface IKullaniciService:IBaseService<Kullanici>
    {
        Kullanici GetUserByLogin(string mail, string sifre);
        Kullanici GetUserByCode(Guid code);
        Kullanici GetUserByOrders(int id);
        List<Kullanici> GetAllByUyeID(int id);
    }
}
