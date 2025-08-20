using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiPharm.Entidades
{
    public class RespuestaFacturaApi
    {
        public string claveAcceso { get; set; }
        public string numeroAutorizacion { get; set; }
        public string estadoFinal { get; set; }
        public string fechaAutorizacion { get; set; }
        public string comprobanteXml { get; set; }
        public object mensajes { get; set; }
    }

}
