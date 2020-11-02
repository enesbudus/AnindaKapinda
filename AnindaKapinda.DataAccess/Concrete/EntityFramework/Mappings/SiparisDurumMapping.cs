using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DataAccess.Concrete.EntityFramework.Mappings
{
    class SiparisDurumMapping : EntityTypeConfiguration<SiparisDurum>
    {
        public SiparisDurumMapping()
        {
            HasKey(i => i.SiparisId);

            Property(i => i.SiparisAciklama).HasMaxLength(500);
            Property(i => i.SiparisDurumu).HasMaxLength(50).IsRequired();
           
            
        }
    }
}
