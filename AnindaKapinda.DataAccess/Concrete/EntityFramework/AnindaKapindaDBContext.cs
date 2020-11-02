using AnindaKapinda.DataAccess.Concrete.EntityFramework.Mappings;
using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DataAccess.Concrete.EntityFramework
{
   public class AnindaKapindaDBContext :DbContext
    {
        public AnindaKapindaDBContext():base("name=AnindaKapinda")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<KullaniciRol> KullaniciRoller { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<SatisDetay> SatisDetaylari { get; set; }
        public DbSet<SiparisDurum> SiparisDurumlari { get; set; }
        public DbSet<Kargo> Kargolar { get; set; }
        public DbSet<Kart> Kartlar { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KullaniciMapping());
            modelBuilder.Configurations.Add(new RolMapping());
            modelBuilder.Configurations.Add(new UrunMapping());
            modelBuilder.Configurations.Add(new MarkaMapping());
            modelBuilder.Configurations.Add(new KategoriMapping());
            modelBuilder.Configurations.Add(new SatisMapping());
            modelBuilder.Configurations.Add(new SatisDetayMapping());
            modelBuilder.Configurations.Add(new SiparisDurumMapping());
            modelBuilder.Configurations.Add(new KargoMapping());
            modelBuilder.Configurations.Add(new KartMapping());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }
    }
}
