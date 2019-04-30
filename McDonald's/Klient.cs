using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonald_s
{
    interface Klient
    {
        int Numerek { get; set; }
        void zamow();
        void zaplac();
        void odbierz();
    }
}
