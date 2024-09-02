using Entidades;
using Logica_Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace UI_CRUD.Controllers
{
    public class PersonaController : Controller
    {
        // Puente Para Comunicarnos Con DB:
        private readonly PersonaBL _personaBL;

        // Constructor:
        public PersonaController(PersonaBL personaBL)
        {
            _personaBL = personaBL;
        }

        // Manda Todos Los Registros De La Tabla
        public async Task<ActionResult> Index()
        {
            var Objetos_Obtenidos = await _personaBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }


        // Busca Un Objeto Y Lo Manda A La Vista
        public async Task<ActionResult> Details(int id)
        {
            var Objeto_Obtenido = await _personaBL.Obtener_PorId(new Persona() { IdPersona = id });

            return View(Objeto_Obtenido);
        }

        public async Task<ActionResult> Create()
        {
            var Lista = await _personaBL.Lista_ViewData();
            
            ViewData["Lista_Ciudades"] = new SelectList(Lista, "IdCiudad", "Nombre");

            return View();
        }


        // Recibe Un Objeto Y Lo Guarda:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Persona persona, IFormFile Fotografia)
        {

            if(Fotografia!=null && Fotografia.Length>0)
            {
                var Cadena_Bytes = new MemoryStream();

                // Pasamos a Cadena De Bytes:
                await Fotografia.CopyToAsync(Cadena_Bytes);

                // Pasamos A Arreglo De Bytes Y Guardamos En Objeto:
                persona.Fotografia = Cadena_Bytes.ToArray();

            }

            // Encritamos Antes De Guardar
            persona.Contraseña = EncriptarMD5(persona.Contraseña);

            await _personaBL.Create(persona);
            return RedirectToAction(nameof(Index));
        }


        // Busca Un Objeto Y Lo Manda A La Vista 
        public async Task<ActionResult> Edit(int id)
        {
            var Objeto_Obtenido = await _personaBL.Obtener_PorId(new Persona() { IdPersona = id });

            var Lista = await _personaBL.Lista_ViewData();

            ViewData["Lista_Ciudades"] = new SelectList(Lista, "IdCiudad", "Nombre", Objeto_Obtenido.IdCiudadEnPersona);

            return View(Objeto_Obtenido);
        }


        // Recibe Un Objeto Lo Busca Y Lo Modifica:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Persona persona, IFormFile Fotografia)
        {
            var Objeto_Obtenido = await _personaBL.Obtener_PorId(persona);

            // Si Se Modifico La Imagen:
            if (Fotografia != null && Fotografia.Length > 0)
            {
                var Cadena_Bytes = new MemoryStream();

                // Pasamos a Cadena De Bytes:
                await Fotografia.CopyToAsync(Cadena_Bytes);

                // Pasamos A Arreglo De Bytes Y Guardamos En Objeto:
                persona.Fotografia = Cadena_Bytes.ToArray();

                // Agregamos La Nueva Imagen Al Objeto Ya Existente
                Objeto_Obtenido.Fotografia = persona.Fotografia;
            }

            // Modificando Los Atributos:
            // Agregamos Los Nuevos Atributos Al Objeto Ya Existente
            Objeto_Obtenido.Nombres = persona.Nombres;
            Objeto_Obtenido.Apellidos = persona.Apellidos;
            Objeto_Obtenido.Email = persona.Email;
            Objeto_Obtenido.IdCiudadEnPersona = persona.IdCiudadEnPersona;

            await _personaBL.Edit(Objeto_Obtenido);

            return RedirectToAction(nameof(Index));
        }

        // Busca Un Objeto Y Lo Manda A La Vista:
        public async Task<ActionResult> Delete(int id)
        {
            var Objeto_Obtenido = await _personaBL.Obtener_PorId(new Persona() { IdPersona = id });

            return View(Objeto_Obtenido);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        // Recibe Un Objeto Lo Busca Y Lo Elimina
        public async Task<ActionResult> Delete(Persona persona)
        {
            await _personaBL.Delete(persona);
            return RedirectToAction(nameof(Index));
        }


        // Metodo Para Encriptar Las Contraseñas:
        public string EncriptarMD5(string Password)
        {
            using (MD5 md5 = MD5.Create())
            {
                // Convertimos el texto en bytes antes de pasarlo al objeto MD5
                byte[] textoBytes = Encoding.UTF8.GetBytes(Password);

                // Calculamos el hash MD5
                byte[] hashBytes = md5.ComputeHash(textoBytes);

                // Convertimos el hash encriptado a su representación hexadecimal
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                // Retornamos el hash encriptado como cadena
                return sb.ToString();
            }
        }

    }
}
