using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealers.BL
{
   public class ClientesBL
    {
        Contexto _contexto;
        public List<Cliente> ListadeClientes { get; set; }

        public ClientesBL()
        {
            _contexto = new Contexto();
            ListadeClientes = new List<Cliente>();
        }

        public List<Cliente> ObtenerClientes()
        {
            ListadeClientes = _contexto.Clientes
                .OrderBy(r => r.Nombre)
                .ToList();

            return ListadeClientes;
        }

        public List<Cliente> ObtenerClientesActivos()
        {
            ListadeClientes = _contexto.Clientes
                .Where(r => r.Activo == true)
                .OrderBy(r => r.Nombre)
                .ToList();

            return ListadeClientes;
        }

        public void GuardarClientes(Cliente cliente)
        {
            if (cliente.Id == 0)
            {
                _contexto.Clientes.Add(cliente);
            }
            else
            {
                var clienteExistente = _contexto.Clientes.Find(cliente.Id);
                clienteExistente.Nombre = cliente.Nombre;
                clienteExistente.RTN = cliente.RTN;
                clienteExistente.Direccion = cliente.Direccion;
                clienteExistente.Telefono = cliente.Telefono;
                clienteExistente.Email = cliente.Email;
               
            }

            _contexto.SaveChanges();

        }
        public Cliente ObtenerClientes(int id)
        {
            var cliente = _contexto.Clientes.Find(id);

            return cliente;
        }

        public void EliminarClientes(int id)
        {
            var cliente = _contexto.Clientes.Find(id);

            _contexto.Clientes.Remove(cliente);
            _contexto.SaveChanges();
        }
    }

}

