using Entidades;
using Logica_Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI_CRUD.Controllers
{
    public class CiudadController : Controller
    {
        // Puente Para Comunicarnos Con DB:
        private readonly CiudadBL _ciudadBL;

        // Constructor:
        public CiudadController(CiudadBL ciudadBL)
        {
            _ciudadBL = ciudadBL;
        }

        // Manda Todos Los Registros De La Tabla
        public async Task<ActionResult> Index()
        {
            var Objetos_Obtenidos = await _ciudadBL.Obtener_Todos();

            return View(Objetos_Obtenidos);
        }


        // Busca Un Objeto Y Lo Manda A La Vista
        public async Task<ActionResult> Details(int id)
        {
            var Objeto_Obtenido = await _ciudadBL.Obtener_PorId(new Ciudad() { IdCiudad=id });
            
            return View(Objeto_Obtenido);
        }

        public ActionResult Create()
        {           
            return View();
        }


        // Recibe Un Objeto Y Lo Guarda:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Ciudad ciudad)
        {
            await _ciudadBL.Create(ciudad);
            return RedirectToAction(nameof(Index));
        }


        // Busca Un Objeto Y Lo Manda A La Vista
        public async Task<ActionResult> Edit(int id)
        {
            var Objeto_Obtenido = await _ciudadBL.Obtener_PorId(new Ciudad() { IdCiudad = id });

            return View(Objeto_Obtenido);
        }


        // Recibe Un Objeto Lo Busca Y Lo Modifica:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Ciudad ciudad)
        {
            await _ciudadBL.Edit(ciudad);
            return RedirectToAction(nameof(Index));
        }

        // Busca Un Objeto Y Lo Manda A La Vista:
        public async Task<ActionResult> Delete(int id)
        {
            var Objeto_Obtenido = await _ciudadBL.Obtener_PorId(new Ciudad() { IdCiudad = id });

            return View(Objeto_Obtenido);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Recibe Un Objeto Lo Busca Y Lo Elimina
        public async Task<ActionResult> Delete(Ciudad ciudad)
        {
            await _ciudadBL.Delete(ciudad);
            return RedirectToAction(nameof(Index));
        }
    }
}
