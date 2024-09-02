using Acceso_Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Negocio
{
    public class PersonaBL
    {
        // Puente Para El Objeto Que Puede Usar La DB::
        private readonly PersonaDAL _personaDAL;

        // Constructor:
        public PersonaBL(PersonaDAL personaDAL)
        {
            _personaDAL = personaDAL;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********:
        // Manda Un Objeto Encontrado:
        public async Task<Persona> Obtener_PorId(Persona persona)
        {
            return await _personaDAL.Obtener_PorId(persona);
        }

        // Manda Todos Los Objetos De La DB:
        public async Task<List<Persona>> Obtener_Todos()
        {
            return await _personaDAL.Obtener_Todos();
        }


        // ******* METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB ********:
        // Recibe Un Objeto Y Lo Guarda En La DB:
        public async Task<int> Create(Persona persona)
        {
            return await _personaDAL.Create(persona);
        }

        // Recibe Un Objeto Lo Busca Y Lo Elimina:
        public async Task<int> Delete(Persona persona)
        {
            return await _personaDAL.Delete(persona);
        }

        // Recibe Un Objeto Lo Busca Y Lo Modifica
        public async Task<int> Edit(Persona persona)
        {
            return await _personaDAL.Edit(persona);
        }

        // Para Colocarlos En ViewData:
        public async Task<List<Ciudad>> Lista_ViewData()
        {
            return await _personaDAL.Lista_ViewData();
        }
    }
}
