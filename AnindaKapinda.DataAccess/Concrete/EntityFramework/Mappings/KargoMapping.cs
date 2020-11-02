using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DataAccess.Concrete.EntityFramework.Mappings
{
    class KargoMapping : EntityTypeConfiguration<Kargo>
    {
        public KargoMapping()
        {
            HasKey(i => i.KargoId);
            Property(i => i.SirketAdi).HasMaxLength(100).IsRequired();
            Property(i => i.ŞirketAdresi).HasMaxLength(250).IsRequired();
            Property(i => i.Telefon).HasMaxLength(15);
            
        }
    }
}
