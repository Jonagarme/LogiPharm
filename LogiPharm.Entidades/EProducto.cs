using System;

namespace LogiPharm.Entidades
{
    public class EProducto
    {
        // Propiedades que coinciden con la tabla 'productos'
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoPrincipal { get; set; }
        public string CodigoAuxiliar { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public string RegistroSanitario { get; set; }
        public int IdTipoProducto { get; set; }
        public int IdClaseProducto { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdSubcategoria { get; set; }
        public int? IdSubnivel { get; set; } // Permite nulos
        public int? IdMarca { get; set; }
        public int? IdLaboratorio { get; set; } // Permite nulos
        public decimal Stock { get; set; }
        public decimal StockMinimo { get; set; }
        public decimal StockMaximo { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool EsDivisible { get; set; }
        public bool EsPsicotropico { get; set; }
        public bool RequiereCadenaFrio { get; set; }
        public bool RequiereSeguimiento { get; set; }
        public bool CalculoABCManual { get; set; }
        public string ClasificacionABC { get; set; }
        public bool Activo { get; set; }

        // Campos de Auditoría (no se insertan directamente, se asignan en la capa de datos)
        public int CreadoPor { get; set; }
        public int? EditadoPor { get; set; }
        public DateTime FechaVencimiento { get; set; } // Campo nuevo
        public decimal CostoUnidad { get; set; }
        public decimal CostoCaja { get; set; }
        public decimal PvpUnidad { get; set; }  // opcional

        // Propiedades de navegación (se llenan desde la capa de datos con JOINs)
        public string NombreCategoria { get; set; }
        public string NombreLaboratorio { get; set; }
        public string NombreMarca { get; set; }
        public string Ubicacion { get; set; } // Percha/Ubicación física

        // Propiedades calculadas (solo lectura)
        public decimal MargenPorcentaje
        {
            get
            {
                if (CostoUnidad == 0) return 0;
                return ((PrecioVenta - CostoUnidad) / CostoUnidad) * 100;
            }
        }

        public decimal MargenValor
        {
            get { return PrecioVenta - CostoUnidad; }
        }

        public int DiasParaVencer
        {
            get
            {
                if (FechaVencimiento == DateTime.MinValue) return int.MaxValue;
                return (FechaVencimiento - DateTime.Now).Days;
            }
        }

        public string EstadoVencimiento
        {
            get
            {
                int dias = DiasParaVencer;
                if (dias < 0) return "VENCIDO";
                if (dias <= 30) return "CRÍTICO";
                if (dias <= 90) return "PRÓXIMO";
                if (dias <= 180) return "ADVERTENCIA";
                return "OK";
            }
        }

        public string EstadoStock
        {
            get
            {
                if (Stock <= 0) return "SIN STOCK";
                if (Stock <= StockMinimo) return "BAJO";
                if (Stock >= StockMaximo) return "EXCESO";
                return "NORMAL";
            }
        }
    }
}
