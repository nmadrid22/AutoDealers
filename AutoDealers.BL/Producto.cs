using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealers.BL
{

    public class Producto
    {

        public Producto()
        {
            Activo = true;

        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese la descripcion del producto")]
        [MinLength(3, ErrorMessage = "Ingrese minimo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese la maximo 20 caracteres")]
        public string Descripcion { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }

        [Required(ErrorMessage = "Ingrese el precio")]
        [Range(0, 300000000, ErrorMessage = "Ingrese un rango entre mayor de 0")]
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name = "Imagen")]
        public string UrlImagen { get; set; }
        public bool Activo { get; set; }

    }
}
