using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeEzberleEntity
{
    public class KullaniciOdeme
    {
        public int KullaniciOdemeID { get; set; }
        public int KullaniciID { get; set; }
        public int OdemeID { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime OdemeTarihi { get; set; }

        public Kullanici Kullanici { get; set; }
        public Odeme Odeme { get; set; }
    }
}
