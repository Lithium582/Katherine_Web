using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class Configuracion
    {
        public string Base { get; set; }
        public string Server { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public string Motor { get; set; }

        //public string ValidAudience { get; set; }
        //public string ValidIssuer { get; set; }
        //public string Secret { get; set; }
    }
}
