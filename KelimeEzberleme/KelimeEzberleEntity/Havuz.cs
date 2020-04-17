using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeEzberleEntity
{
    public class Havuz : BaseClass
    {
        public int HavuzID { get; set; }
        public string HavuzAdi { get; set; }
        public int KullaniciID { get; set; }

        //1 havuzun sahibi tek bir kullanıcı olabilir. 
        public Kullanici Kullanici { get; set; }

        //çoka çok ilişki kısmı
        //bir havuzda birden fazla kelime olabilir??? 
        // TODO: buraya bakalım.
        public List<Kelime> Kelimeler { get; set; }
    }
}
