using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DataAccess.Concrete.EntityFramework.Mappings
{
    class KullaniciMapping:EntityTypeConfiguration<Kullanici>
    {
        public KullaniciMapping()
        {
            HasKey(i => i.KullaniciId);
            Property(i => i.Adi).HasMaxLength(20).IsRequired();
            Property(i => i.Soyadi).HasMaxLength(30).IsRequired();
            Property(i => i.Telefon).HasMaxLength(15).IsRequired();
            Property(i => i.Mail).HasMaxLength(250).IsRequired();
            Property(i => i.Sifre).HasMaxLength(20).IsRequired();
            Property(i => i.Adres).HasMaxLength(50);
            Property(i => i.DogumTarihi);
            HasRequired(i => i.Rol).WithMany(i => i.Kullanici).HasForeignKey(i => i.RoleID).WillCascadeOnDelete(false);
        }
    }
}
