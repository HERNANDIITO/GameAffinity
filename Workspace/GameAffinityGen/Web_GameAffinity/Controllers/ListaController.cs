using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;

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
            SessionInitialize();
            ListaRepository listRepo = new ListaRepository(session);
            ListaCEN listCEN = new ListaCEN(listRepo);

            ListaEN listEN = listCEN.GetByOID(id);
            Console.WriteLine(listEN);
            ListaViewModel listView = new ListaAssembler().ConvertirENToViewModel(listEN);

            SessionClose();
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
            string fileName = "", path = "";
            if (list.Imagen != null && list.Imagen.Length > 0)
            {
                fileName = Path.GetFileName(list.Imagen.FileName).Trim();

                string directory = _webHost.WebRootPath + "/Images/";
                path = Path.Combine((directory), fileName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = System.IO.File.Create(path))
                {
                    await list.Imagen.CopyToAsync(stream);
                }

                fileName = "/Images/" + fileName;
            }
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
            string fileName = "", path = "";
            if (list.Imagen != null && list.Imagen.Length > 0)
            {
                fileName = Path.GetFileName(list.Imagen.FileName).Trim();

                string directory = _webHost.WebRootPath + "/Images/";
                path = Path.Combine((directory), fileName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = System.IO.File.Create(path))
                {
                    await list.Imagen.CopyToAsync(stream);
                }

                fileName = "/Images/" + fileName;
            }
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
    }
}
