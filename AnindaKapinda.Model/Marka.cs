using AnindaKapinda.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.Model
{
  public class Marka:BaseEntity
    {
        public Marka()
        {
            Urunler = new HashSet<Urun>();
        }
        public int MarkaId { get; set; }
        public string MarkaAdi { get; set; }
        public string MarkaAciklama { get; set; }
        public ICollection<Urun> Urunler { get; set; }
    }
}
