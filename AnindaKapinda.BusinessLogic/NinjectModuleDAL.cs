using AnindaKapinda.DataAccess.Abstract;
using AnindaKapinda.DataAccess.Concrete.EntityFramework.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.BusinessLogic
{
   public class NinjectModuleDAL:NinjectModule
    {
        public override void Load()
        {
            this.Bind<IKullaniciDAL>().To<KullaniciRepository>();
            this.Bind<IKullaniciRolDAL>().To<KullaniciRolRepository>();
            this.Bind<IUrunDAL>().To<UrunRepository>();
            this.Bind<IMarkaDAL>().To<MarkaRepository>();
            this.Bind<IKargoDAL>().To<KargoRepository>();
            this.Bind<IKartDAL>().To<KartRepository>();
            this.Bind<ISatisDAL>().To<SatisRepository>();
            this.Bind<ISatisDetayDAL>().To<SatisDetayRepository>();
            this.Bind<ISiparisDurumDAL>().To<SiparisDurumRepository>();
            this.Bind<IKategoriDAL>().To<KategoriRepository>();
        }
    }
}
