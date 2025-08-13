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

    }
}
