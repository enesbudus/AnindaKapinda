using AnindaKapinda.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.Model
{
   public class Kategori:BaseEntity
    {
        public Kategori()
        {
            Urunler = new HashSet<Urun>();
        }
        public int KategoriId  { get; set; }
        public string KategoriAdi { get; set; }
        public string KategoriDetay { get; set; }
        public ICollection<Urun> Urunler { get; set; }
    }
}
