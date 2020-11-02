using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DataAccess.Concrete.EntityFramework.Mappings
{
    class SatisMapping : EntityTypeConfiguration<Satis>
    {
        public SatisMapping()
        {
            HasKey(i => i.SatisId);
            Property(i => i.SatisTarihi).IsRequired();
            Property(i => i.ToplamTutar).IsRequired();
            Property(i => i.SiparisAdresi).HasMaxLength(250).IsRequired();
            HasRequired(i => i.Kullanici).WithMany(i => i.Satislar).HasForeignKey(i => i.KullaniciId).WillCascadeOnDelete(false);
            HasRequired(i => i.Kart).WithMany(i => i.Satislar).HasForeignKey(i => i.KartID).WillCascadeOnDelete(false);
            HasRequired(i => i.Kargo).WithMany(i => i.Satislar).HasForeignKey(i => i.KargoID).WillCascadeOnDelete(false);
            HasRequired(i => i.SiparisDurum).WithMany(i => i.Satislar).HasForeignKey(i => i.SiparisDurumId).WillCascadeOnDelete(false);
            
        }
    }
}
