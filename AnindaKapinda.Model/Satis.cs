using AnindaKapinda.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.Model
{
   public class Satis:BaseEntity
    {
        public Satis()
        {
            SatisDetaylar = new HashSet<SatisDetay>();
        }
        public int SatisId { get; set; }
        public int KullaniciId { get; set; }
        public DateTime SatisTarihi { get; set; }
        public decimal ToplamTutar { get; set; }
        public string SiparisAdresi { get; set; }
        public int SiparisDurumId { get; set; }
        public int KartID { get; set; }
        public int KargoID { get; set; }
        public Kullanici Kullanici { get; set; }
        
        public ICollection<SatisDetay> SatisDetaylar { get; set; }
        public SiparisDurum SiparisDurum { get; set; }
        public Kart Kart { get; set; }
        public Kargo Kargo { get; set; }

    }
}
