using System;
using System.Collections.Generic;
using System.Globalization;
using LogiPharm.Entidades;

namespace LogiPharm.Presentacion.Utilidades
{
    public static class NotaCreditoBuilder
    {
        private const decimal IVA_PCT = 0.15m;   // 15%
        private const string IVA_CODIGO = "2";
        private const string IVA_COD_PORC = "4"; // 15%

        private static string TipoIdentificacionDesdeId(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return "06"; // otros
            id = id.Trim();
            if (id.Length == 10) return "05"; // cédula
            if (id.Length == 13) return "04"; // RUC
            return "06";
        }

        private static (string id, string razon, string direccion) NormalizarCliente(ECliente c)
        {
            var id = (c?.Identificacion ?? "").Trim();
            if (string.IsNullOrWhiteSpace(id)) id = (c?.CedulaRuc ?? "").Trim();
            if (string.IsNullOrWhiteSpace(id)) id = "9999999999999"; // CF

            string razon = (c?.RazonSocial ?? "").Trim();
            if (string.IsNullOrWhiteSpace(razon))
            {
                var nombres = (c?.Nombres ?? "").Trim();
                var apellidos = (c?.Apellidos ?? "").Trim();
                razon = ($"{nombres} {apellidos}").Trim();
            }
            if (string.IsNullOrWhiteSpace(razon)) razon = "CONSUMIDOR FINAL";

            string dir = (c?.Direccion ?? "").Trim();
            if (string.IsNullOrWhiteSpace(dir)) dir = "S/D";

            return (id, razon, dir);
        }

        public class ItemDevolucion
        {
            public string CodigoInterno { get; set; }
            public string Descripcion { get; set; }
            public decimal Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal DescuentoValor { get; set; }
        }

        public static NotaCreditoPayload Build(
            string empresaRuc,
            int ambiente,
            string estab,
            string ptoEmi,
            string secuencial,
            string dirMatriz,
            string dirEstablecimiento,
            string contribuyenteRimpe,
            bool obligadoContabilidad,
            ECliente cliente,
            string numDocModificado,
            DateTime fechaEmisionDocSustento,
            string motivo,
            List<ItemDevolucion> items,
            bool itemsGravadosConIva = true)
        {
            var (idComprador, razonComprador, _) = NormalizarCliente(cliente);
            var tipoId = TipoIdentificacionDesdeId(idComprador);

            string sec9 = (secuencial ?? "1").PadLeft(9, '0');

            decimal totalSinImpuestos = 0m;
            decimal totalIva = 0m;
            var detalles = new List<DetalleNotaCredito>();

            foreach (var p in items)
            {
                decimal cant = Math.Round(p.Cantidad, 2, MidpointRounding.AwayFromZero);
                decimal pu = Math.Round(p.PrecioUnitario, 2, MidpointRounding.AwayFromZero);
                decimal dscto = Math.Round(p.DescuentoValor, 2, MidpointRounding.AwayFromZero);
                decimal baseLinea = Math.Round(cant * pu - dscto, 2, MidpointRounding.AwayFromZero);
                decimal ivaLinea = itemsGravadosConIva ? Math.Round(baseLinea * IVA_PCT, 2, MidpointRounding.AwayFromZero) : 0m;

                detalles.Add(new DetalleNotaCredito
                {
                    codigoInterno = p.CodigoInterno,
                    descripcion = p.Descripcion,
                    cantidad = cant,
                    precioUnitario = pu,
                    descuento = dscto,
                    precioTotalSinImpuesto = baseLinea,
                    impuestos = new List<ImpuestoDetalle>
                    {
                        new ImpuestoDetalle
                        {
                            codigo = IVA_CODIGO,
                            codigoPorcentaje = itemsGravadosConIva ? IVA_COD_PORC : "0",
                            tarifa = itemsGravadosConIva ? 15.00m : 0.00m,
                            baseImponible = baseLinea,
                            valor = ivaLinea
                        }
                    }
                });

                totalSinImpuestos += baseLinea;
                totalIva += ivaLinea;
            }

            totalSinImpuestos = Math.Round(totalSinImpuestos, 2, MidpointRounding.AwayFromZero);
            totalIva = Math.Round(totalIva, 2, MidpointRounding.AwayFromZero);
            decimal importeTotal = Math.Round(totalSinImpuestos + totalIva, 2, MidpointRounding.AwayFromZero);

            return new NotaCreditoPayload
            {
                empresaRuc = empresaRuc,
                ambiente = ambiente,
                tipoComprobante = "04",
                infoTributaria = new InfoTributaria
                {
                    estab = estab,
                    ptoEmi = ptoEmi,
                    secuencial = sec9,
                    dirMatriz = dirMatriz,
                    contribuyenteRimpe = contribuyenteRimpe
                },
                infoNotaCredito = new InfoNotaCredito
                {
                    fechaEmision = DateTime.Now.ToString("dd/MM/yyyy"),
                    dirEstablecimiento = dirEstablecimiento,
                    tipoIdentificacionComprador = tipoId,
                    razonSocialComprador = razonComprador,
                    identificacionComprador = idComprador,
                    obligadoContabilidad = obligadoContabilidad ? "SI" : "NO",
                    codDocModificado = "01",
                    numDocModificado = numDocModificado,
                    fechaEmisionDocSustento = fechaEmisionDocSustento.ToString("dd/MM/yyyy"),
                    totalSinImpuestos = totalSinImpuestos,
                    valorModificacion = importeTotal,
                    moneda = "DOLAR",
                    totalConImpuestos = new List<TotalImpuesto>
                    {
                        new TotalImpuesto
                        {
                            codigo = IVA_CODIGO,
                            codigoPorcentaje = itemsGravadosConIva ? IVA_COD_PORC : "0",
                            baseImponible = totalSinImpuestos,
                            valor = totalIva
                        }
                    },
                    motivo = string.IsNullOrWhiteSpace(motivo) ? "DEVOLUCIÓN DE MERCADERÍA" : motivo
                },
                detalles = detalles
            };
        }
    }
}
