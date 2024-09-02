using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {

        // Atributos:
         
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPersona { get; set; }


        [Required(ErrorMessage = "Ingrese Los Nombres.")]
        [StringLength(150)]
        public string Nombres { get; set; }



        [Required(ErrorMessage = "Ingrese Los Apellidos.")]
        [StringLength(150)]
        public string Apellidos { get; set; }



        [Required(ErrorMessage = "Ingrese El Correo Electronico.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }



        [Required(ErrorMessage = "Ingrese Una Contraseña.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "La Contraseña Debe Tener Entre 5 y 100 Caracteres")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }



        [Required(ErrorMessage = "Debe Confirmar La Contraseña Ingresada.")]
        [Compare("Contraseña", ErrorMessage = "La Contraseña No Coincide.")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmarContraseña { get; set; }


        public byte[]? Fotografia { get; set; }



        // Referencia De Otra Clase:
        [ForeignKey("Objeto_Ciudad")]
        public int IdCiudadEnPersona { get; set; }
        public virtual Ciudad Objeto_Ciudad { get; set; } = null;

    }
}
