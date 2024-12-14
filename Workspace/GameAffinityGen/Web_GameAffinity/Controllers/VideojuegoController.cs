using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;
using GameAffinityGen.ApplicationCore.Enumerated.GameAffinity;
using System.Collections.Specialized;
using NHibernate;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;
using GameAffinityGen.Infraestructure.CP;

namespace Web_GameAffinity.Controllers
{
    public class VideojuegoController : BasicController
    {

        private readonly IWebHostEnvironment _webHost;

        public VideojuegoController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

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
            if (videojuegoEn == null)
            {
                return NotFound();
            }
            VideojuegoViewModel videojuegoView = new VideojuegoAssembler().ConvertirENToViewModel(videojuegoEn);

            if(videojuegoEn.Resenyas != null)
            {
                NHibernateUtil.Initialize(videojuegoEn.Resenyas);
            }

            VideojuegoDetailsViewModel vistaJuego = new VideojuegoDetailsViewModel
            {
                Videojuego = videojuegoView,
                Resenyas = videojuegoEn.Resenyas
            };

            SessionClose();
            return View(vistaJuego);
        }

        //POST: VideojuegoController/PublicarResenya
        [HttpPost]
        public ActionResult PublicarResenya(ResenyaViewModel resenya)
        {
            try
            {
                SessionInitialize();
                int idUser = HttpContext.Session.Get<ConfiguracionPerfilViewModel>("user").id;
                ResenyaRepository repo = new ResenyaRepository();
                ResenyaCEN resenyaCEN = new ResenyaCEN(repo);
                int nuevaResenyaId = resenyaCEN.New_(resenya.Titulo, resenya.Texto, 0, 0, idUser, resenya.VideojuegoId);

                if (nuevaResenyaId > 0)
                {
                        ValoracionCP valoracionCP = new ValoracionCP(new SessionCPNHibernate());
                        valoracionCP.New_(resenya.Valoracion, idUser, resenya.VideojuegoId);
                }
                else
                {
                    // Manejar el caso en que la reseña no se creó correctamente
                    ModelState.AddModelError("", "No se pudo crear la reseña.");
                    return RedirectToAction("Details", new { id = resenya.VideojuegoId });
                }

                SessionClose();
                return RedirectToAction("Details", new { id = resenya.VideojuegoId });
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante el proceso
                ModelState.AddModelError("", $"Error al crear la reseña: {ex.Message}");
                return RedirectToAction("Details", new { id = resenya.VideojuegoId });
            }
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
        public async Task<ActionResult> Create(VideojuegoViewModel videojuego)
        {
            string fileName = "", path = "";
            if ( videojuego.Imagen != null && videojuego.Imagen.Length > 0 )
            {
                fileName = Path.GetFileName(videojuego.Imagen.FileName).Trim();

                string directory = _webHost.WebRootPath + "/Images/";
                path = Path.Combine((directory), fileName);

                if ( !Directory.Exists(directory) )
                {
                    Directory.CreateDirectory(directory);
                }

                using ( var stream = System.IO.File.Create(path))
                {
                    await videojuego.Imagen.CopyToAsync(stream);
                }

                fileName = "/Images/" + fileName;
            }

            try
            {
                VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
                VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);
                videojuegoCEN.New_(
                    videojuego.Nombre,
                    videojuego.Descripcion,
                    0.0f,
                    videojuego.Genero,
                    videojuego.FechaLanzamiento,
                    fileName
                );
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

            IList<SelectListItem> listaGeneros = new List<SelectListItem>();
            listaGeneros.Add(new SelectListItem { Text = "Terror", Value = GenerosEnum.Terror.ToString() });
            listaGeneros.Add(new SelectListItem { Text = "Acción", Value = GenerosEnum.Accion.ToString() });
            listaGeneros.Add(new SelectListItem { Text = "Puzzles", Value = GenerosEnum.Puzzles.ToString() });
            listaGeneros.Add(new SelectListItem { Text = "Mundo Abierto", Value = GenerosEnum.Mundo_abierto.ToString() });
            ViewData["GenerosItems"] = listaGeneros;

            return View(videojuegoView);
        }

        // POST: VideojuegoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, VideojuegoViewModel videojuego)
        {
            string fileName = "", path = "";
            if (videojuego.Imagen != null && videojuego.Imagen.Length > 0)
            {
                fileName = Path.GetFileName(videojuego.Imagen.FileName).Trim();

                string directory = _webHost.WebRootPath + "/Images/";
                path = Path.Combine((directory), fileName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = System.IO.File.Create(path))
                {
                    await videojuego.Imagen.CopyToAsync(stream);
                }

                fileName = "/Images/" + fileName;
            }

            try
            {
                VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
                VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);
                videojuegoCEN.Modify(
                    videojuego.Id,
                    videojuego.Nombre,
                    videojuego.Descripcion,
                    0.0f,
                    videojuego.Genero,
                    videojuego.FechaLanzamiento,
                    fileName
                );
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
