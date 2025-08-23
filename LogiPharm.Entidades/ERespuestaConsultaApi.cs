using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LogiPharm.Entidades
{
    public class CompradorResumen
    {
        [JsonProperty("identificacion")]
        public string Identificacion { get; set; }
        [JsonProperty("razonSocial")]
        public string RazonSocial { get; set; }
    }

    public class EmisorResumen
    {
        [JsonProperty("razonSocial")]
        public string RazonSocial { get; set; }

        [JsonProperty("numeroDocumento")]
        public string NumeroDocumento { get; set; }
    }

    public class TotalesResumen
    {
        [JsonProperty("importeTotal")]
        public string ImporteTotal { get; set; }
    }

    public class Resumen
    {
        [JsonProperty("comprador")]
        public CompradorResumen Comprador { get; set; }
        [JsonProperty("emisor")]
        public EmisorResumen Emisor { get; set; }

        [JsonProperty("numeroDocumento")]
        public EmisorResumen NumeroDocumento { get; set; }

        [JsonProperty("fechaEmision")]
        public string FechaEmision { get; set; }
        [JsonProperty("totales")]
        public TotalesResumen Totales { get; set; }
    }

    public class RespuestaConsultaApi
    {
        [JsonProperty("claveAcceso")]
        public string ClaveAcceso { get; set; }
        [JsonProperty("estado")]
        public string Estado { get; set; }
        [JsonProperty("numeroAutorizacion")]
        public string NumeroAutorizacion { get; set; }
        [JsonProperty("fechaAutorizacion")]
        public string FechaAutorizacion { get; set; }
        [JsonProperty("resumen")]
        public Resumen Resumen { get; set; }
        [JsonProperty("comprobanteXml")]
        public string ComprobanteXml { get; set; }
    }
}
