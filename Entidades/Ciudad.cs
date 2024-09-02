using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciudad
    {

        // Atributos:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCiudad { get; set; } 


        [Required(ErrorMessage = "Ingrese El Nombre De La Ciudad")]
        public string Nombre { get; set; }


        // Persona Asociada A Esta Clase
        public virtual List<Persona> Lista_Personas { get; set; }


        // Constructor
        public Ciudad()
        {
            Lista_Personas = new List<Persona>();
        }
    }
}
