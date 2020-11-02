using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DataAccess.Concrete.EntityFramework.Mappings
{
    class KartMapping : EntityTypeConfiguration<Kart>
    {
        public KartMapping()
        {
            HasKey(i => i.KartId);
            Property(i => i.KartNo).IsRequired();
            Property(i => i.SonKullanimTarihi).IsRequired();
            Property(i => i.CVCNo).IsRequired();
            HasRequired(i => i.Kullanici).WithMany(i => i.Kartlar).HasForeignKey(i => i.KullaniciID).WillCascadeOnDelete(false);
        }
    }
}
