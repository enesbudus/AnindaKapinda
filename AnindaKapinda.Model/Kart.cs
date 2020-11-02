using AnindaKapinda.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.Model
{
  public class Kart:BaseEntity
    {
        public Kart()
        {
            Satislar = new HashSet<Satis>();

        }
        public int KartId { get; set; }
        public int KullaniciID { get; set; }
        public int KartNo { get; set; }
        public int SonKullanimTarihi { get; set; }
        public int CVCNo { get; set; }
        public Kullanici Kullanici { get; set; }
        public ICollection<Satis> Satislar { get; set; }
    }
}
