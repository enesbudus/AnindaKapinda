using AnindaKapinda.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.Model
{
   public class Urun : BaseEntity
    {
        public Urun()
        {
            SatisDetaylar = new HashSet<SatisDetay>();
        }
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public decimal UrunFiyat { get; set; }
        public string UrunDetay { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public int KategoriId { get; set; }
        public int MarkaId { get; set; }
        public int Stok { get; set; }
        public Kategori Kategori { get; set; }
        public Marka Marka { get; set; }
        public ICollection<SatisDetay> SatisDetaylar { get; set; }
    }
}
