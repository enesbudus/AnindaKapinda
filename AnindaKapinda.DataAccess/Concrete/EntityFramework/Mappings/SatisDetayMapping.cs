using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DataAccess.Concrete.EntityFramework.Mappings
{
    class SatisDetayMapping : EntityTypeConfiguration<SatisDetay>
    {
        public SatisDetayMapping()
        {
            HasKey(i => new {i.SatisId,i.UrunId });
            
           
            Property(i => i.UrunAdet).IsRequired();
            Property(i => i.UrunFiyat).IsRequired();
            Property(i => i.UrunIndirim).IsOptional();
            HasRequired(i => i.Urun).WithMany(i => i.SatisDetaylar).HasForeignKey(i => i.UrunId).WillCascadeOnDelete(false);
            HasRequired(i => i.Satis).WithMany(i => i.SatisDetaylar).HasForeignKey(i => i.SatisId).WillCascadeOnDelete(false);

        }
    }
}
