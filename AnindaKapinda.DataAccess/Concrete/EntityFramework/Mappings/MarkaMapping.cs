using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DataAccess.Concrete.EntityFramework.Mappings
{
    class MarkaMapping : EntityTypeConfiguration<Marka>
    {
        public MarkaMapping()
        {
            HasKey(i => i.MarkaId);
            Property(i => i.MarkaAdi).HasMaxLength(30).IsRequired();
            Property(i => i.MarkaAciklama).HasMaxLength(500);
        }
    }
}
