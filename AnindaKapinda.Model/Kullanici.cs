using AnindaKapinda.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.Model
{
   public class Kullanici:BaseEntity
    {
        public Kullanici()
        {
            Satislar = new HashSet<Satis>();
            Kartlar = new HashSet<Kart>();
        }
        public int KullaniciId { get; set; }
        public int RoleID { get; set; }
        
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Telefon { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public string Adres { get; set; }
        public DateTime DogumTarihi { get; set; }
        public Guid? AktivasyonKodu { get; set; }
        public KullaniciRol Rol { get; set; }
        public ICollection<Kart> Kartlar { get; set; }
        public ICollection<Satis> Satislar { get; set; }
    }
}
