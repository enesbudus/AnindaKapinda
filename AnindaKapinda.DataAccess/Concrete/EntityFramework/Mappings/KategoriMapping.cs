using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DataAccess.Concrete.EntityFramework.Mappings
{
    class KategoriMapping : EntityTypeConfiguration<Kategori>
    {
        public KategoriMapping()
        {
            HasKey(i => i.KategoriId);
            Property(i => i.KategoriAdi).HasMaxLength(30).IsRequired();
            Property(i => i.KategoriDetay).HasMaxLength(500);
            
        }
    }
}
