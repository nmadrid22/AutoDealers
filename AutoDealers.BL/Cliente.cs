using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDealers.BL
{
    public class Cliente
    {
        public Cliente()
        {
            Activo = true;

        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese la descripcion del producto")]
        [MinLength(3, ErrorMessage = "Ingrese minimo 3 caracteres")]
        [MaxLength(20, ErrorMessage = "Ingrese la maximo 20 caracteres")]
        public string Nombre { get; set; }
        public string RTN { get; set; }
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Ingrese el precio")]
        [Range(0, 300000000, ErrorMessage = "Ingrese un rango entre mayor de 0")]
        public double Telefono { get; set; }
        
        public string Email { get; set; }
        
        
        public bool Activo { get; set; }

    }
}
