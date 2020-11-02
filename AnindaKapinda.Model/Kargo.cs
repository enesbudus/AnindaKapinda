using AnindaKapinda.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.Model
{
   public class Kargo:BaseEntity
    {
        public Kargo()
        {
            Satislar = new HashSet<Satis>();
        }
        public int KargoId { get; set; }
        public string SirketAdi { get; set; }
        public string ŞirketAdresi { get; set; }
        public string Telefon { get; set; }
        public ICollection<Satis> Satislar { get; set; }
    }
}
