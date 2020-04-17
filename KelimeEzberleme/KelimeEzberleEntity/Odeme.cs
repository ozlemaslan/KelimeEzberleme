using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeEzberleEntity
{
    public class Odeme : BaseClass
    {
        public int OdemeID { get; set; }
        public string OdemeTuru { get; set; }

        //1 ödeme yöntemini kullanan birden fazla kullanıcı olabilir. 
        public List<Kullanici> Kullanicilar { get; set; }

        //TODO
        public KullaniciOdeme KullaniciOdeme { get; set; }
    }
}
