namespace AnindaKapinda.DataAccess.Migrations
{
    using AnindaKapinda.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AnindaKapinda.DataAccess.Concrete.EntityFramework.AnindaKapindaDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
           
        }

        protected override void Seed(AnindaKapinda.DataAccess.Concrete.EntityFramework.AnindaKapindaDBContext context)
        {
            List<KullaniciRol> roller = new List<KullaniciRol>() {
                new KullaniciRol(){ RolAdi = "Admin" },
                new KullaniciRol(){ RolAdi = "Kargocu" },
                new KullaniciRol(){ RolAdi = "Uye" },
                new KullaniciRol(){ RolAdi = "PazarlamaGorevlisi" },
                new KullaniciRol(){ RolAdi = "TedarikGorevlisi" },
                new KullaniciRol(){ RolAdi = "MerkezGorevlisi" }
            };

            context.KullaniciRoller.AddRange(roller);

            context.SaveChanges();
        }
    }
}
