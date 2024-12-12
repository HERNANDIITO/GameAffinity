using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;
using GameAffinityGen.ApplicationCore.Enumerated.GameAffinity;

namespace Web_GameAffinity.Controllers
{
    public class VideojuegoController : BasicController
    {
        // GET: VideojuegoController
        public ActionResult Index()
        {
            SessionInitialize();
            VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);

            IList<VideojuegoEN> listEN = videojuegoCEN.GetAll(0, -1);

            IEnumerable<VideojuegoViewModel> listaVideojuegos = new VideojuegoAssembler().ConvertirListaENtoViewModel(listEN).ToList();
            SessionClose();

            return View(listaVideojuegos);
        }

        // GET: VideojuegoController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            VideojuegoRepository videojuegoRepository = new VideojuegoRepository(session);
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);

            VideojuegoEN videojuegoEn = videojuegoCEN.GetByoID(id);
            VideojuegoViewModel videojuegoView = new VideojuegoAssembler().ConvertirENToViewModel(videojuegoEn);

            SessionClose();
            return View(videojuegoView);
        }

        // GET: VideojuegoController/Create
        public ActionResult Create()
        {
            //Obtener enums
            IList<SelectListItem> listaGeneros = new List<SelectListItem>();
            listaGeneros.Add(new SelectListItem { Text = "Terror", Value = GenerosEnum.Terror.ToString() });
            listaGeneros.Add(new SelectListItem { Text = "Acción", Value = GenerosEnum.Accion.ToString() });
            listaGeneros.Add(new SelectListItem { Text = "Puzzles", Value = GenerosEnum.Puzzles.ToString() });
            listaGeneros.Add(new SelectListItem { Text = "Mundo Abierto", Value = GenerosEnum.Mundo_abierto.ToString() });
            ViewData["GenerosItems"] = listaGeneros;
            
            return View();

        }

        // POST: VideojuegoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VideojuegoViewModel videojuego)
        {
            try
            {
                VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
                VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);
                videojuegoCEN.New_(videojuego.Nombre, videojuego.Descripcion, 0.0f, videojuego.Genero, videojuego.FechaLanzamiento, videojuego.Imagen);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VideojuegoController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            VideojuegoRepository videojuegoRepository = new VideojuegoRepository(session);
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);

            VideojuegoEN videojuegoEn =  videojuegoCEN.GetByoID(id);
            VideojuegoViewModel videojuegoView = new VideojuegoAssembler().ConvertirENToViewModel(videojuegoEn);

            SessionClose();
            return View(videojuegoView);
        }

        // POST: VideojuegoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VideojuegoViewModel videojuego)
        {
            try
            {
                VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
                VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);
                videojuegoCEN.Modify(id, videojuego.Nombre, videojuego.Descripcion, 0.0f, videojuego.Genero, videojuego.FechaLanzamiento, videojuego.Imagen);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VideojuegoController/Delete/5
        public ActionResult Delete(int id)
        {
            VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);
            videojuegoCEN.Destroy(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: VideojuegoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
