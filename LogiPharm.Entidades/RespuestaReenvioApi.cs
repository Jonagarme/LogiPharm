using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiPharm.Entidades
{
    /// <summary>
    /// Representa la respuesta del endpoint de reenvío de facturas al SRI
    /// </summary>
    public class RespuestaReenvioApi
    {
        public string Estado { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string FechaAutorizacion { get; set; }
        public string ClaveAcceso { get; set; }
        public string Mensaje { get; set; }
        public object Mensajes { get; set; }
    }
}
