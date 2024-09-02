using Acceso_Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Negocio
{
    public class CiudadBL
    {
        // Puente Para El Objeto Que Puede Usar La DB::
        private readonly CiudadDAL _ciudadDAL;

        // Constructor:
        public CiudadBL(CiudadDAL ciudadDAL)
        {
            _ciudadDAL = ciudadDAL;
        }


        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********:
        // Manda Un Objeto Encontrado:
        public async Task<Ciudad> Obtener_PorId(Ciudad ciudad)
        {
            return await _ciudadDAL.Obtener_PorId(ciudad);
        }

        // Manda Todos Los Objetos De La DB:
        public async Task<List<Ciudad>> Obtener_Todos()
        {
            return await _ciudadDAL.Obtener_Todos();
        }


        // ******* METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB ********:
        // Recibe Un Objeto Y Lo Guarda En La DB:
        public async Task<int> Create(Ciudad ciudad)
        {
            return await _ciudadDAL.Create(ciudad);
        }

        // Recibe Un Objeto Lo Busca Y Lo Elimina:
        public async Task<int> Delete(Ciudad ciudad)
        {
            return await _ciudadDAL.Delete(ciudad);
        }

        // Recibe Un Objeto Lo Busca Y Lo Modifica
        public async Task<int> Edit(Ciudad ciudad)
        {
            return await _ciudadDAL.Edit(ciudad);
        }
    }
}
