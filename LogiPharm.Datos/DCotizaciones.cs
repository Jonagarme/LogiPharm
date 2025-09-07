using LogiPharm.Entidades;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace LogiPharm.Datos
{
    public class DCotizaciones
    {
        public int ObtenerSiguienteNumero(MySqlConnection cn, MySqlTransaction tran)
        {
            // Usa tabla 'secuencias' con nombre 'COTIZACION'
            int nuevo;
            using (var cmdSel = new MySqlCommand("SELECT valor FROM secuencias WHERE nombre='COTIZACION' FOR UPDATE", cn, tran))
            {
                var obj = cmdSel.ExecuteScalar();
                if (obj == null)
                {
                    using (var cmdIns = new MySqlCommand("INSERT INTO secuencias(nombre, valor) VALUES('COTIZACION', 0)", cn, tran))
                        cmdIns.ExecuteNonQuery();
                    nuevo = 1;
                }
                else
                {
                    nuevo = Convert.ToInt32(obj) + 1;
                }
            }
            using (var cmdUpd = new MySqlCommand("UPDATE secuencias SET valor=@v WHERE nombre='COTIZACION'", cn, tran))
            {
                cmdUpd.Parameters.AddWithValue("@v", nuevo);
                cmdUpd.ExecuteNonQuery();
            }
            return nuevo;
        }

        // Preview (no incrementa en BD)
        public int ObtenerProximoNumeroPreview()
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand("SELECT valor FROM secuencias WHERE nombre='COTIZACION'", cn))
            {
                cn.Open();
                var obj = cmd.ExecuteScalar();
                if (obj == null || obj == DBNull.Value) return 1; // si no existe, el primero será 1
                return Convert.ToInt32(obj) + 1;
            }
        }

        public long GuardarCotizacion(ECotizacion cot, int idUsuario)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                using (var tran = cn.BeginTransaction())
                {
                    try
                    {
                        // Generar número si no viene
                        if (cot.Numero <= 0)
                        {
                            cot.Numero = ObtenerSiguienteNumero(cn, tran);
                        }

                        // Insert encabezado
                        string sqlEnc = @"INSERT INTO cotizaciones
                            (numero, fecha, validezDias, idCliente, observaciones, subtotal, descuento, iva, total, estado, creadoPor, creadoDate, anulado)
                            VALUES(@numero, @fecha, @validezDias, @idCliente, @observaciones, @subtotal, @descuento, @iva, @total, 'VIGENTE', @creadoPor, NOW(), 0);
                            SELECT LAST_INSERT_ID();";

                        long idCotizacion;
                        using (var cmd = new MySqlCommand(sqlEnc, cn, tran))
                        {
                            cmd.Parameters.AddWithValue("@numero", cot.Numero);
                            cmd.Parameters.AddWithValue("@fecha", cot.Fecha.Date);
                            cmd.Parameters.AddWithValue("@validezDias", cot.ValidezDias);
                            cmd.Parameters.AddWithValue("@idCliente", cot.IdCliente);
                            cmd.Parameters.AddWithValue("@observaciones", (object)cot.Observaciones ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@subtotal", cot.Subtotal);
                            cmd.Parameters.AddWithValue("@descuento", cot.Descuento);
                            cmd.Parameters.AddWithValue("@iva", cot.IVA);
                            cmd.Parameters.AddWithValue("@total", cot.Total);
                            cmd.Parameters.AddWithValue("@creadoPor", idUsuario);
                            idCotizacion = Convert.ToInt64(cmd.ExecuteScalar());
                        }

                        // Insert detalle
                        string sqlDet = @"INSERT INTO cotizaciones_detalle
                            (idCotizacion, idProducto, codigo, productoNombre, cantidad, precioUnitario, precioFinal, descuentoPorc, descuentoValor, ivaValor, subtotal, total)
                            VALUES(@idCotizacion, @idProducto, @codigo, @productoNombre, @cantidad, @precioUnitario, @precioFinal, @descuentoPorc, @descuentoValor, @ivaValor, @subtotal, @total);";

                        foreach (var det in cot.Detalles)
                        {
                            using (var cmdD = new MySqlCommand(sqlDet, cn, tran))
                            {
                                cmdD.Parameters.AddWithValue("@idCotizacion", idCotizacion);
                                cmdD.Parameters.AddWithValue("@idProducto", det.IdProducto);
                                cmdD.Parameters.AddWithValue("@codigo", (object)det.Codigo ?? DBNull.Value);
                                cmdD.Parameters.AddWithValue("@productoNombre", det.ProductoNombre);
                                cmdD.Parameters.AddWithValue("@cantidad", det.Cantidad);
                                cmdD.Parameters.AddWithValue("@precioUnitario", det.PrecioUnitario);
                                cmdD.Parameters.AddWithValue("@precioFinal", det.PrecioFinal);
                                cmdD.Parameters.AddWithValue("@descuentoPorc", det.DescuentoPorc);
                                cmdD.Parameters.AddWithValue("@descuentoValor", det.DescuentoValor);
                                cmdD.Parameters.AddWithValue("@ivaValor", det.IVAValor);
                                cmdD.Parameters.AddWithValue("@subtotal", det.Subtotal);
                                cmdD.Parameters.AddWithValue("@total", det.Total);
                                cmdD.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                        return idCotizacion;
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public void AnularCotizacion(long idCotizacion, int idUsuario)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                using (var cmd = new MySqlCommand(@"UPDATE cotizaciones 
                                                     SET anulado = 1, estado='ANULADA', anuladoPor=@u, anuladoDate=NOW()
                                                     WHERE id=@id;", cn))
                {
                    cmd.Parameters.AddWithValue("@u", idUsuario);
                    cmd.Parameters.AddWithValue("@id", idCotizacion);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int ObtenerNumeroPorId(long idCotizacion)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            using (var cmd = new MySqlCommand("SELECT numero FROM cotizaciones WHERE id=@id", cn))
            {
                cn.Open();
                cmd.Parameters.AddWithValue("@id", idCotizacion);
                var obj = cmd.ExecuteScalar();
                if (obj == null || obj == DBNull.Value) return 0;
                return Convert.ToInt32(obj);
            }
        }

        public ECotizacion ObtenerCotizacionPorNumero(int numero)
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                long id = 0;
                ECotizacion cot = null;
                using (var cmd = new MySqlCommand(@"SELECT id, numero, fecha, validezDias, idCliente, observaciones, subtotal, descuento, iva, total, estado, creadoPor, creadoDate, anulado, anuladoPor, anuladoDate
                                                     FROM cotizaciones WHERE numero=@n LIMIT 1", cn))
                {
                    cmd.Parameters.AddWithValue("@n", numero);
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            id = rd.GetInt64("id");
                            cot = new ECotizacion
                            {
                                Id = id,
                                Numero = rd.GetInt32("numero"),
                                Fecha = rd.GetDateTime("fecha"),
                                ValidezDias = rd.GetInt32("validezDias"),
                                IdCliente = rd.GetInt32("idCliente"),
                                Observaciones = rd["observaciones"] as string,
                                Subtotal = rd.GetDecimal("subtotal"),
                                Descuento = rd.GetDecimal("descuento"),
                                IVA = rd.GetDecimal("iva"),
                                Total = rd.GetDecimal("total"),
                                Estado = rd["estado"].ToString(),
                                CreadoPor = rd.GetInt32("creadoPor"),
                                CreadoDate = rd.GetDateTime("creadoDate"),
                                Anulado = rd.GetBoolean("anulado"),
                                AnuladoPor = rd["anuladoPor"] != DBNull.Value ? (int?)Convert.ToInt32(rd["anuladoPor"]) : null,
                                AnuladoDate = rd["anuladoDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(rd["anuladoDate"]) : null,
                                Detalles = new List<ECotizacionDetalle>()
                            };
                        }
                    }
                }
                if (cot == null) return null;

                using (var cmdDet = new MySqlCommand(@"SELECT id, idProducto, codigo, productoNombre, cantidad, precioUnitario, precioFinal, descuentoPorc, descuentoValor, ivaValor, subtotal, total
                                                       FROM cotizaciones_detalle WHERE idCotizacion=@id", cn))
                {
                    cmdDet.Parameters.AddWithValue("@id", id);
                    using (var rd = cmdDet.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            cot.Detalles.Add(new ECotizacionDetalle
                            {
                                Id = rd.GetInt64("id"),
                                IdCotizacion = id,
                                IdProducto = rd.GetInt32("idProducto"),
                                Codigo = rd["codigo"] as string,
                                ProductoNombre = rd["productoNombre"].ToString(),
                                Cantidad = rd.GetDecimal("cantidad"),
                                PrecioUnitario = rd.GetDecimal("precioUnitario"),
                                PrecioFinal = rd.GetDecimal("precioFinal"),
                                DescuentoPorc = rd.GetDecimal("descuentoPorc"),
                                DescuentoValor = rd.GetDecimal("descuentoValor"),
                                IVAValor = rd.GetDecimal("ivaValor"),
                                Subtotal = rd.GetDecimal("subtotal"),
                                Total = rd.GetDecimal("total")
                            });
                        }
                    }
                }
                return cot;
            }
        }

        public ECotizacion ObtenerUltimaCotizacion()
        {
            using (var cn = new MySqlConnection(CapaDatos.Conexion.cadena))
            {
                cn.Open();
                long id = 0;
                ECotizacion cot = null;
                using (var cmd = new MySqlCommand(@"SELECT id, numero, fecha, validezDias, idCliente, observaciones, subtotal, descuento, iva, total, estado, creadoPor, creadoDate, anulado, anuladoPor, anuladoDate
                                                     FROM cotizaciones ORDER BY id DESC LIMIT 1", cn))
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        id = rd.GetInt64("id");
                        cot = new ECotizacion
                        {
                            Id = id,
                            Numero = rd.GetInt32("numero"),
                            Fecha = rd.GetDateTime("fecha"),
                            ValidezDias = rd.GetInt32("validezDias"),
                            IdCliente = rd.GetInt32("idCliente"),
                            Observaciones = rd["observaciones"] as string,
                            Subtotal = rd.GetDecimal("subtotal"),
                            Descuento = rd.GetDecimal("descuento"),
                            IVA = rd.GetDecimal("iva"),
                            Total = rd.GetDecimal("total"),
                            Estado = rd["estado"].ToString(),
                            CreadoPor = rd.GetInt32("creadoPor"),
                            CreadoDate = rd.GetDateTime("creadoDate"),
                            Anulado = rd.GetBoolean("anulado"),
                            AnuladoPor = rd["anuladoPor"] != DBNull.Value ? (int?)Convert.ToInt32(rd["anuladoPor"]) : null,
                            AnuladoDate = rd["anuladoDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(rd["anuladoDate"]) : null,
                            Detalles = new List<ECotizacionDetalle>()
                        };
                    }
                }
                if (cot == null) return null;

                using (var cmdDet = new MySqlCommand(@"SELECT id, idProducto, codigo, productoNombre, cantidad, precioUnitario, precioFinal, descuentoPorc, descuentoValor, ivaValor, subtotal, total
                                                       FROM cotizaciones_detalle WHERE idCotizacion=@id", cn))
                {
                    cmdDet.Parameters.AddWithValue("@id", id);
                    using (var rd = cmdDet.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            cot.Detalles.Add(new ECotizacionDetalle
                            {
                                Id = rd.GetInt64("id"),
                                IdCotizacion = id,
                                IdProducto = rd.GetInt32("idProducto"),
                                Codigo = rd["codigo"] as string,
                                ProductoNombre = rd["productoNombre"].ToString(),
                                Cantidad = rd.GetDecimal("cantidad"),
                                PrecioUnitario = rd.GetDecimal("precioUnitario"),
                                PrecioFinal = rd.GetDecimal("precioFinal"),
                                DescuentoPorc = rd.GetDecimal("descuentoPorc"),
                                DescuentoValor = rd.GetDecimal("descuentoValor"),
                                IVAValor = rd.GetDecimal("ivaValor"),
                                Subtotal = rd.GetDecimal("subtotal"),
                                Total = rd.GetDecimal("total")
                            });
                        }
                    }
                }
                return cot;
            }
        }
    }
}
