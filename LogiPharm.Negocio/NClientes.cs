using System;
using System.Data;
using LogiPharm.Datos;
using LogiPharm.Entidades;

namespace LogiPharm.Negocio
{
    public static class NClientes
    {
        public static ECliente BuscarClientePorId(string cedulaRuc)
        {
            return new DClientes().BuscarClientePorId(cedulaRuc);
        }

        public static ECliente ObtenerClientePorId(int id)
        {
            return new DClientes().ObtenerClientePorId(id);
        }

        public static DataTable ListarClientes(string criterio)
        {
            return new DClientes().ListarClientes(criterio);
        }

        public static bool ActualizarCliente(ECliente cliente)
        {
            // Aquí se pueden agregar validaciones específicas de negocio si fueran necesarias en el futuro
            if (string.IsNullOrWhiteSpace(cliente.CedulaRuc))
                throw new ArgumentException("La identificación (Cédula/RUC) es obligatoria.");
            if (string.IsNullOrWhiteSpace(cliente.RazonSocial))
                throw new ArgumentException("La razón social o nombres es obligatoria.");

            return new DClientes().ActualizarCliente(cliente);
        }

        public static bool InsertarCliente(ECliente cliente)
        {
            // Validaciones de negocio antes de insertar
            if (string.IsNullOrWhiteSpace(cliente.CedulaRuc))
                throw new ArgumentException("La identificación (Cédula/RUC) es obligatoria.");
            if (string.IsNullOrWhiteSpace(cliente.RazonSocial))
                throw new ArgumentException("La razón social o nombres es obligatoria.");

            return new DClientes().InsertarCliente(cliente);
        }

        public static DataTable ListarClientesActivos()
        {
            return new DClientes().ListarClientesActivos();
        }
    }
}
