using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;
using NHibernate;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;
using GameAffinityGen.Infraestructure.CP;

namespace Web_GameAffinity.Controllers
{
    public class ListaController : BasicController
    {
        private readonly IWebHostEnvironment _webHost;

        public ListaController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        // GET: ListaController
        public ActionResult Index()
        {
            SessionInitialize();
            ListaRepository listaRepository = new ListaRepository(session);
            ListaCEN listaCEN = new ListaCEN(listaRepository);

            IList<ListaEN> listEN = listaCEN.GetAll(0, -1);

            IEnumerable<ListaViewModel> listLists = new ListaAssembler().ConvertirListENToViewModel(listEN).ToList();
            SessionClose();

            return View(listLists);
        }



        // GET: ListaController/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new EmptyResult();
            }

            // Inicializamos la sesión
            SessionInitialize();

            // Repositorios y CEN necesarios
            ListaRepository listRepo = new ListaRepository(session);
            VideojuegoRepository videojuegoRepo = new VideojuegoRepository(session);

            ListaCEN listCEN = new ListaCEN(listRepo);
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepo);

            // Obtenemos la lista por ID
            ListaEN listEN = listCEN.GetByOID(id);
            if (listEN != null)
            {
                NHibernateUtil.Initialize(listEN.Videojuegos); // Inicializamos los videojuegos asociados a la lista
            }

            // Obtenemos todos los videojuegos de la base de datos
            IList<VideojuegoEN> todosLosVideojuegos = videojuegoCEN.GetAll(0, -1);

            // Convertimos la entidad a modelo de vista
            ListaViewModel listView = new ListaAssembler().ConvertirENToViewModel(listEN);

            // Añadimos todos los videojuegos al modelo de vista
            listView.TodosLosVideojuegos = todosLosVideojuegos;

            // Cerramos la sesión
            SessionClose();

            // Devolvemos la vista con el modelo actualizado
            return View(listView);
        }




        // GET: ListaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ListaViewModel list)
        {
            string fileName = await FileHelper.GetFileName(list.Imagen, _webHost.WebRootPath);

            try
            {
                ListaRepository listRepo = new ListaRepository();
                ListaCEN listCEN = new ListaCEN(listRepo);
                listCEN.New_(
                    list.Nombre,
                    list.Descripcion,
                    list.Por_defecto,
                    -1,
                    fileName
                );  //el -1 es el autor, si no es -1 el post no funciona no se por que
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ListaController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            ListaRepository listRepo = new ListaRepository(session);
            ListaCEN listCEN = new ListaCEN(listRepo);

            ListaEN listEN = listCEN.GetByOID(id);
            Console.WriteLine(listEN);
            ListaViewModel listView = new ListaAssembler().ConvertirENToViewModel(listEN);

            SessionClose();
            return View(listView);
        }

        // POST: ListaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ListaViewModel list)
        {
            string fileName = await FileHelper.GetFileName(list.Imagen, _webHost.WebRootPath);

            try
            {
                ListaRepository listRepo = new ListaRepository();
                ListaCEN listCEN = new ListaCEN(listRepo);
                listCEN.Modify(
                    list.Id,
                    list.Nombre,
                    list.Descripcion,
                    list.Por_defecto,
                    fileName
                );
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ListaController/Delete/5
        public ActionResult Delete(int id)
        {
            ListaRepository listRepo = new ListaRepository();
            ListaCEN listCEN = new ListaCEN(listRepo);
            listCEN.Destroy(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: ListaController/Delete/5
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




        // POST: ListaController/AnyadirVideojuego
        [HttpPost]
        public ActionResult AnyadirVideojuego(int listaId, int videojuegoId)
        {
            try
            {
                if (listaId <= 0 || videojuegoId <= 0)
                {
                    return BadRequest("IDs inválidos");
                }

                // Inicializamos la sesión
                SessionInitialize();

                // Repositorio y CEN
                ListaRepository listRepo = new ListaRepository(session);
                ListaCEN listCEN = new ListaCEN(listRepo);
                ListaCP listCP = new ListaCP(new SessionCPNHibernate());
                listCP.AnyadirJuego(listaId, new List<int> { }, videojuegoId);
                //listCEN.AnyadirVideojuego(listaId, new List<int> { }, videojuegoId);


                // Llamamos al método de negocio para añadir el videojuego
                //listCEN.AnyadirVideojuego(listaId, new List<int> { videojuegoId});

                ListaEN lista = listCEN.GetByOID(listaId);
                // Cerramos la sesión
                SessionClose();

                // Redirigir a los detalles de la lista tras añadir el videojuego
                return RedirectToAction("Details", new { id = listaId });
            }
            catch (Exception ex)
            {
                // Manejo de errores
                SessionClose();
                return View("Error", new { message = ex.Message });
            }
        }



    }
}
