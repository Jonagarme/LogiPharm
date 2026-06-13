﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LogiPharm.Entidades;

namespace LogiPharm.Presentacion.Utilidades
{
    public static class FacturaBuilder
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
            // ID: intenta Identificacion, luego CedulaRuc, y si nada, consumidor final
            var id = (c?.Identificacion ?? "").Trim();
            if (string.IsNullOrWhiteSpace(id)) id = (c?.CedulaRuc ?? "").Trim();
            if (string.IsNullOrWhiteSpace(id)) id = "9999999999999"; // CF

            // Razón: usa RazonSocial; si no hay, arma con nombres/apellidos
            string razon = (c?.RazonSocial ?? "").Trim();
            if (string.IsNullOrWhiteSpace(razon))
            {
                var nombres = (c?.Nombres ?? "").Trim();
                var apellidos = (c?.Apellidos ?? "").Trim();
                razon = $"{nombres} {apellidos}".Trim();
            }
            if (string.IsNullOrWhiteSpace(razon)) razon = "CONSUMIDOR FINAL";

            // Dirección
            string dir = (c?.Direccion ?? "").Trim();
            if (string.IsNullOrWhiteSpace(dir)) dir = "S/D";

            return (id, razon, dir);
        }

        public static FacturaPayload BuildFactura(
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
            List<ProductoVenta> productos)
        {
            // 1) Cliente normalizado
            var (idComprador, razonComprador, dirComprador) = NormalizarCliente(cliente);
            var tipoId = TipoIdentificacionDesdeId(idComprador);

            // 2) Secuencial 9 dígitos
            string sec9 = (secuencial ?? "1").PadLeft(9, '0');

            // 3) Detalles y totales (2 decimales)
            var detalles = new List<DetalleFactura>();
            decimal totalSinImpuestos = 0m;
            decimal totalDescuento = 0m;

            foreach (var p in productos)
            {
                decimal cant = Math.Round(p.Cantidad, 2, MidpointRounding.AwayFromZero);
                decimal pu = Math.Round(p.PrecioUnitario, 2, MidpointRounding.AwayFromZero);
                // tu “Descuento” es porcentaje en la UI; si ya lo convertiste a valor, quítale este cálculo.
                decimal dsctoValor = Math.Round(p.Descuento, 2, MidpointRounding.AwayFromZero); // si ya viene como valor
                                                                                                // Si “Descuento” fuese %: descomenta
                                                                                                // decimal dsctoValor = Math.Round(cant * pu * (p.Descuento / 100m), 2, MidpointRounding.AwayFromZero);

                decimal baseLinea = Math.Round(cant * pu - dsctoValor, 2, MidpointRounding.AwayFromZero);
                decimal ivaLinea = Math.Round(baseLinea * IVA_PCT, 2, MidpointRounding.AwayFromZero);

                detalles.Add(new DetalleFactura
                {
                    codigoPrincipal = p.CodigoPrincipal,
                    descripcion = p.Descripcion,
                    cantidad = cant,
                    precioUnitario = pu,
                    descuento = dsctoValor,
                    precioTotalSinImpuesto = baseLinea,
                    impuestos = new List<ImpuestoDetalle>
            {
                new ImpuestoDetalle
                {
                    codigo = IVA_CODIGO,
                    codigoPorcentaje = IVA_COD_PORC,
                    tarifa = 15.00m,
                    baseImponible = baseLinea,
                    valor = ivaLinea
                }
            }
                });

                totalSinImpuestos += baseLinea;
                totalDescuento += dsctoValor;
            }

            totalSinImpuestos = Math.Round(totalSinImpuestos, 2, MidpointRounding.AwayFromZero);
            decimal valorIva = Math.Round(totalSinImpuestos * IVA_PCT, 2, MidpointRounding.AwayFromZero);
            decimal total = Math.Round(totalSinImpuestos + valorIva, 2, MidpointRounding.AwayFromZero);

            return new FacturaPayload
            {
                empresaRuc = empresaRuc,
                ambiente = ambiente,
                tipoComprobante = "01",
                infoTributaria = new InfoTributaria
                {
                    estab = estab,
                    ptoEmi = ptoEmi,
                    secuencial = sec9,
                    dirMatriz = dirMatriz,
                    contribuyenteRimpe = contribuyenteRimpe
                },
                infoFactura = new InfoFactura
                {
                    fechaEmision = DateTime.Now.ToString("dd/MM/yyyy"),
                    dirEstablecimiento = dirEstablecimiento,
                    obligadoContabilidad = obligadoContabilidad ? "SI" : "NO",
                    tipoIdentificacionComprador = tipoId,
                    razonSocialComprador = razonComprador,
                    identificacionComprador = idComprador,
                    direccionComprador = dirComprador,
                    totalSinImpuestos = totalSinImpuestos,
                    totalDescuento = totalDescuento,
                    totalConImpuestos = new List<TotalImpuesto>
            {
                new TotalImpuesto
                {
                    codigo = IVA_CODIGO,
                    codigoPorcentaje = IVA_COD_PORC,
                    baseImponible = totalSinImpuestos,
                    valor = valorIva
                }
            },
                    propina = 0.00m,
                    importeTotal = total,
                    moneda = "DOLAR"
                },
                detalles = detalles
            };
        }

		public static ProcesarFacturaRequest BuildProcesarFacturaRequest(
			string tipo,
			EEmpresa empresa,
			string establecimiento,
			string puntoEmision,
			string secuencial,
			ECliente cliente,
			List<ProductoVenta> productos,
			string formaPago = "EFECTIVO")
		{
			if (empresa == null) throw new ArgumentNullException(nameof(empresa));
			if (productos == null) productos = new List<ProductoVenta>();

			var (idComprador, razonComprador, dirComprador) = NormalizarCliente(cliente);
			string sec9 = (secuencial ?? "1").PadLeft(9, '0');
			decimal ivaRate = ImpuestoProvider.GetIVA();
			decimal ivaTarifaPct = Math.Round(ivaRate * 100m, 2, MidpointRounding.AwayFromZero);

			var detalles = new List<FacturaDetalleApi>();
			decimal totalSinImpuestos = 0m;
			decimal totalDescuento = 0m;
			decimal totalIva = 0m;
			decimal baseIva15 = 0m;
			decimal valorIva15 = 0m;
			decimal baseIva0 = 0m;

			foreach (var p in productos)
			{
				decimal cant = Math.Round(p.Cantidad, 2, MidpointRounding.AwayFromZero);
				decimal pu = Math.Round(p.PrecioUnitario, 2, MidpointRounding.AwayFromZero);
				decimal subtotalSinDesc = Math.Round(cant * pu, 2, MidpointRounding.AwayFromZero);

				decimal baseLinea;
				if (p.PrecioTotalSinImpuesto > 0)
				{
					baseLinea = Math.Round(p.PrecioTotalSinImpuesto, 2, MidpointRounding.AwayFromZero);
				}
				else
				{
					// En el POS `Descuento` suele ser % (0-100). Si no, se interpreta como valor.
					decimal descuentoValorEstimado;
					if (p.Descuento > 0m && p.Descuento <= 100m)
						descuentoValorEstimado = Math.Round(subtotalSinDesc * (p.Descuento / 100m), 2, MidpointRounding.AwayFromZero);
					else
						descuentoValorEstimado = Math.Round(p.Descuento, 2, MidpointRounding.AwayFromZero);

					baseLinea = Math.Round(subtotalSinDesc - descuentoValorEstimado, 2, MidpointRounding.AwayFromZero);
					if (baseLinea < 0m) baseLinea = 0m;
				}

				decimal dsctoValor = Math.Round(subtotalSinDesc - baseLinea, 2, MidpointRounding.AwayFromZero);
				if (dsctoValor < 0m) dsctoValor = 0m;

				decimal itemIvaRate = p.AplicaIva ? ivaRate : 0m;
				decimal itemIvaTarifaPct = p.AplicaIva ? ivaTarifaPct : 0m;
				string itemCodigoPorc = p.AplicaIva ? IVA_COD_PORC : "0";

				decimal ivaLinea = Math.Round(baseLinea * itemIvaRate, 2, MidpointRounding.AwayFromZero);
				totalSinImpuestos += baseLinea;
				totalDescuento += dsctoValor;
				totalIva += ivaLinea;

				if (p.AplicaIva)
				{
					baseIva15 += baseLinea;
					valorIva15 += ivaLinea;
				}
				else
				{
					baseIva0 += baseLinea;
				}

				detalles.Add(new FacturaDetalleApi
				{
					codigoPrincipal = p.CodigoPrincipal,
					codigoAuxiliar = string.Empty,
					descripcion = p.Descripcion,
					cantidad = cant,
					precioUnitario = pu,
					descuento = dsctoValor,
					precioTotalSinImpuesto = baseLinea,
					impuestos = new List<ImpuestoApi>
					{
						new ImpuestoApi
						{
							codigo = IVA_CODIGO,
							codigoPorcentaje = itemCodigoPorc,
							baseImponible = baseLinea,
							tarifa = itemIvaTarifaPct,
							valor = ivaLinea
						}
					}
				});
			}

			totalSinImpuestos = Math.Round(totalSinImpuestos, 2, MidpointRounding.AwayFromZero);
			totalDescuento = Math.Round(totalDescuento, 2, MidpointRounding.AwayFromZero);
			totalIva = Math.Round(totalIva, 2, MidpointRounding.AwayFromZero);
			decimal importeTotal = Math.Round(totalSinImpuestos + totalIva, 2, MidpointRounding.AwayFromZero);

			string telefono = (cliente?.Telefono ?? string.Empty).Trim();
			if (string.IsNullOrWhiteSpace(telefono)) telefono = (cliente?.Celular ?? string.Empty).Trim();
			string email = (cliente?.Email ?? string.Empty).Trim();

			var listaImpuestosCabecera = new List<ImpuestoApi>();
			if (baseIva15 > 0m)
			{
				listaImpuestosCabecera.Add(new ImpuestoApi
				{
					codigo = IVA_CODIGO,
					codigoPorcentaje = IVA_COD_PORC,
					baseImponible = Math.Round(baseIva15, 2, MidpointRounding.AwayFromZero),
					tarifa = ivaTarifaPct,
					valor = Math.Round(valorIva15, 2, MidpointRounding.AwayFromZero)
				});
			}
			if (baseIva0 > 0m || listaImpuestosCabecera.Count == 0)
			{
				listaImpuestosCabecera.Add(new ImpuestoApi
				{
					codigo = IVA_CODIGO,
					codigoPorcentaje = "0",
					baseImponible = Math.Round(baseIva0, 2, MidpointRounding.AwayFromZero),
					tarifa = 0m,
					valor = 0m
				});
			}

			return new ProcesarFacturaRequest
			{
				tipo = string.IsNullOrWhiteSpace(tipo) ? "FACTURA" : tipo,
				ruc = (empresa.Ruc ?? string.Empty).Trim(),
				empresa_Id = empresa.Id,
				data = new ProcesarFacturaData
				{
					fechaEmision = DateTime.Now.ToString("dd/MM/yyyy"),
					establecimiento = establecimiento,
					puntoEmision = puntoEmision,
					secuencial = sec9,
					identificacionComprador = idComprador,
					razonSocialComprador = razonComprador,
					direccionComprador = dirComprador,
					totalSinImpuestos = totalSinImpuestos,
					totalDescuento = totalDescuento,
					importeTotal = importeTotal,
					detalles = detalles,
					impuestos = listaImpuestosCabecera,
					pagos = new List<PagoApi>
					{
						new PagoApi
						{
							formaPago = formaPago,
							total = importeTotal
						}
					},
					infoAdicional = new InfoAdicionalApi
					{
						email = email,
						telefono = telefono
					}
				}
			};
		}

    }
}

