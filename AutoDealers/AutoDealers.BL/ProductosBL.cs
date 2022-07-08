﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealers.BL
{
    public class ProductosBL
    {

        Contexto _contexto;
        public List<Producto> ListadeProductos { get; set; }

        public ProductosBL()
        {
           _contexto = new Contexto();
            ListadeProductos = new List<Producto>();
        }

        public List<Producto> ObtenerProductos()
        {

            ListadeProductos = _contexto.Productos
                .Include("Categoria")
                .ToList();

            return ListadeProductos;
        }

        public void GuardarProducto(Producto producto)
        {
            if (producto.Id == 0)
            {
                _contexto.Productos.Add(producto);
            }
            else
            {
                var productoExistente = _contexto.Productos.Find(producto.Id);
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.Modelo = producto.Modelo;
                productoExistente.Color = producto.Color;
                productoExistente.Precio = producto.Precio;
                productoExistente.Existencia = producto.Existencia;
                productoExistente.CategoriaId= producto.CategoriaId;
                productoExistente.UrlImagen = producto.UrlImagen;



            } 
            
            _contexto.SaveChanges();

        }

        public Producto ObtenerProductos (int id)
        {

            var producto = _contexto.Productos
                .Include("Categoria").FirstOrDefault(p => p.Id == id);

            return producto;
        }
        public List<Producto> ObtenerProductosActivos()
        {
            ListadeProductos = _contexto.Productos
                .Include("Categoria")
                .Where(r => r.Activo == true)
                .OrderBy(r => r.Descripcion)
                .ToList();

            return ListadeProductos;
        }


        public void EliminarProducto (int id)
        {
            var producto = _contexto.Productos.Find(id);

            _contexto.Productos.Remove(producto);
            _contexto.SaveChanges();
        }
    }
}
