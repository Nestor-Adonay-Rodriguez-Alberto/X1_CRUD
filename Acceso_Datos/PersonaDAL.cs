using Entidades;
using Microsoft.EntityFrameworkCore;
namespace Acceso_Datos
{
    public class PersonaDAL
    {
        // Representa La DB:
        private readonly MyDBContext _myDBContext;

        // Constructor:
        public PersonaDAL(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        // ******* METODOS QUE MANDARAN OBJETOS A LAS VISTAS ********:
        // Manda Un Objeto Encontrado:
        public async Task<Persona> Obtener_PorId(Persona persona)
        {
            var Objeto_Obtenido = await _myDBContext.Personas
                .Include(x=> x.Objeto_Ciudad)
                .FirstOrDefaultAsync(x => x.IdPersona == persona.IdPersona);

            return Objeto_Obtenido;
        }

        // Manda Todos Los Objetos De La DB:
        public async Task<List<Persona>> Obtener_Todos()
        {
            var Objetos_Obtenidos = await _myDBContext.Personas
                .Include(x=> x.Objeto_Ciudad).ToListAsync();

            return Objetos_Obtenidos;
        }



        // ******* METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB ********:
        // Recibe Un Objeto Y Lo Guarda En La DB:
        public async Task<int> Create(Persona persona)
        {
            _myDBContext.Add(persona);
            return await _myDBContext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Lo Elimina:
        public async Task<int> Delete(Persona persona)
        {
            var Objeto_Obtenido = await _myDBContext.Personas
                .Include(x => x.Objeto_Ciudad)
                .FirstOrDefaultAsync(x => x.IdPersona == persona.IdPersona);

            _myDBContext.Remove(Objeto_Obtenido);

            return await _myDBContext.SaveChangesAsync();
        }


        // Recibe Un Objeto Lo Busca Y Lo Modifica
        public async Task<int> Edit(Persona persona)
        {
            var Objeto_Obtenido = await _myDBContext.Personas
                .Include(x => x.Objeto_Ciudad)
                .FirstOrDefaultAsync(x => x.IdPersona == persona.IdPersona);

            if (Objeto_Obtenido != null)
            {
                if(persona.Fotografia!=null && persona.Fotografia.Length>0)
                {
                    Objeto_Obtenido.Fotografia = persona.Fotografia;
                }

                //Modificando Atributos
                Objeto_Obtenido.Nombres = persona.Nombres;
                Objeto_Obtenido.Apellidos = persona.Apellidos;
                Objeto_Obtenido.Email = persona.Email;
                Objeto_Obtenido.Contraseña = persona.Contraseña;
                Objeto_Obtenido.IdCiudadEnPersona = persona.IdCiudadEnPersona;

                _myDBContext.Update(Objeto_Obtenido);
            }

            return await _myDBContext.SaveChangesAsync();
        }


        // Para Colocarlos En ViewData:
        public async Task<List<Ciudad>> Lista_ViewData()
        {
            var Lista_Objetos = await _myDBContext.Ciudades.ToListAsync();

            return Lista_Objetos;
        }
    }
}
