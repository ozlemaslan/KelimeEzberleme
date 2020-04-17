using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeEzberleEntity
{
    public abstract class BaseClass
    {
        public DateTime OlusturulmaTarihi { get; set; }
        public bool AktifMi { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }
    }
}
