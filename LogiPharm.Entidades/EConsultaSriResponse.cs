using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LogiPharm.Entidades
{
    public class ConsultaSriResponse
    {
        [JsonProperty("comprobanteXml")]
        public string ComprobanteXml { get; set; }
        // agrega más campos si tu API los devuelve (estado, mensajes, etc.)
    }
}
