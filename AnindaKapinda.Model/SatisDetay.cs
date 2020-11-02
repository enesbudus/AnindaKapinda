using AnindaKapinda.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.Model
{
   public class SatisDetay:BaseEntity
    {
        public int SatisId { get; set; }
        public int UrunId { get; set; }
        public int UrunAdet { get; set; }
        public float UrunIndirim { get; set; }
        public decimal UrunFiyat { get; set; }
        public Urun Urun { get; set; }
        public Satis Satis { get; set; }
    }
}
