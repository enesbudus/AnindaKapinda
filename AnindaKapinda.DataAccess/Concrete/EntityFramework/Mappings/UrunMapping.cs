using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DataAccess.Concrete.EntityFramework.Mappings
{
    class UrunMapping : EntityTypeConfiguration<Urun>
    {
        public UrunMapping()
        {
            HasKey(i => i.UrunId);
            Property(i => i.UrunAdi).HasMaxLength(30).IsRequired();
            Property(i => i.UrunFiyat).IsRequired();
            Property(i => i.UrunDetay).HasMaxLength(500);
            Property(i => i.EklenmeTarihi).IsRequired();
            Property(i => i.Stok).IsRequired();
            HasRequired(i => i.Marka).WithMany(i => i.Urunler).HasForeignKey(i => i.MarkaId).WillCascadeOnDelete(false);
            HasRequired(i => i.Kategori).WithMany(i => i.Urunler).HasForeignKey(i => i.KategoriId).WillCascadeOnDelete(false);

        }
    }
}
