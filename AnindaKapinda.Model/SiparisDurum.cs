using AnindaKapinda.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.Model
{
   public class SiparisDurum:BaseEntity
    {
        public SiparisDurum()
        {
            Satislar = new HashSet<Satis>();
        }
        public int SiparisId { get; set; }
        
       
        
        public string SiparisAciklama { get; set; }
        public string SiparisDurumu { get; set; }
        
        
        public ICollection<Satis> Satislar { get; set; }
    }
}
