using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class CiudadDAL
    {
        // Representa La DB:
        private readonly MyDBContext _myDBContext;

        // Constructor:
        public CiudadDAL(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********:
        // Manda Un Objeto Encontrado:
        public async Task<Ciudad> Obtener_PorId(Ciudad ciudad)
        {
            var Objeto_Obtenido = await _myDBContext.Ciudades.FirstOrDefaultAsync(x => x.IdCiudad == ciudad.IdCiudad);

            return Objeto_Obtenido;
        }

        // Manda Todos Los Objetos De La DB:
        public async Task<List<Ciudad>> Obtener_Todos()
        {
            var Objetos_Obtenidos = await _myDBContext.Ciudades.ToListAsync();

            return Objetos_Obtenidos;
        }



        // ******* METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB ********:
        // Recibe Un Objeto Y Lo Guarda En La DB:
        public async Task<int> Create(Ciudad ciudad)
        {
            _myDBContext.Add(ciudad);
            return await _myDBContext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Lo Elimina:
        public async Task<int> Delete(Ciudad ciudad)
        {
            var Objeto_Obtenido = await _myDBContext.Ciudades.FirstOrDefaultAsync(x => x.IdCiudad == ciudad.IdCiudad);

            _myDBContext.Remove(Objeto_Obtenido);

            return await _myDBContext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Lo Modifica
        public async Task<int> Edit(Ciudad ciudad)
        {
            var Objeto_Obtenido = await _myDBContext.Ciudades.FirstOrDefaultAsync(x => x.IdCiudad == ciudad.IdCiudad);

            if(Objeto_Obtenido!=null)
            {
                Objeto_Obtenido.Nombre = ciudad.Nombre;
                _myDBContext.Update(Objeto_Obtenido);
            }

            return await _myDBContext.SaveChangesAsync();
        }
    }
}
