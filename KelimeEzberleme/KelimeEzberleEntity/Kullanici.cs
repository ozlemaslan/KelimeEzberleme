using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeEzberleEntity
{
    public class Kullanici : BaseClass
    {
        public int KullaniciID { get; set; }
        public int RolID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string Telefon { get; set; }

        public Role Rol { get; set; }

        //1 kullanıcının birden fazla havuzu olabilir. 
        public List<Havuz> Havuzlar { get; set; }
        //TODO
        public KullaniciOdeme KullaniciOdeme { get; set; }
    }
}
