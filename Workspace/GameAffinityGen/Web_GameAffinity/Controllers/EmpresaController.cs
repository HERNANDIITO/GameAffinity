using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;
using NHibernate;
using NHibernate.Proxy;

namespace Web_GameAffinity.Controllers
{
    public class EmpresaController : BasicController
    {

        private readonly IWebHostEnvironment _webHost;

        public EmpresaController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        // GET: EmpresaController
        public ActionResult Index()
        {
            SessionInitialize();
            EmpresaRepository empresaRepository = new EmpresaRepository();
            EmpresaCEN empresaCEN = new EmpresaCEN(empresaRepository);

            IList<EmpresaEN> listEN = empresaCEN.GetAll(0, -1);

            IEnumerable<EmpresaViewModel> listaEmpresas = new EmpresaAssembler().ConvertirListaENtoViewModel(listEN).ToList();
            SessionClose();

            return View(listaEmpresas);
        }

        // GET: EmpresaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpresaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmpresaViewModel empresa)
        {
            string fileName = await FileHelper.GetFileName(empresa.Imagen, _webHost.WebRootPath);

            try
            {
                EmpresaRepository repository = new EmpresaRepository();
                EmpresaCEN cen = new EmpresaCEN(repository);
                cen.New_(
                    empresa.Nombre,
                    empresa.Descripcion,
                    0,
                    fileName
                );
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpresaController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            EmpresaRepository empresaRepository = new EmpresaRepository(session);
            EmpresaCEN empresaCEN = new EmpresaCEN(empresaRepository);

            EmpresaEN empresaEn = empresaCEN.GetByOID(id);
            EmpresaViewModel empresaView = new EmpresaAssembler().ConvertirENToViewModel(empresaEn);

            SessionClose();
            return View(empresaView);
        }

        // POST: EmpresaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EmpresaViewModel empresa)
        {
            try
            {
                EmpresaRepository empresaRepository = new EmpresaRepository();
                EmpresaCEN empresaCEN = new EmpresaCEN(empresaRepository);

                string fileName = await FileHelper.GetFileName(empresa.Imagen, _webHost.WebRootPath);

                empresaCEN.Modify(
                    id,
                    empresa.Nombre,
                    empresa.Descripcion,
                    0.0f,
                    fileName
                );

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpresaController/Delete/5
        public ActionResult Delete(int id)
        {
            EmpresaRepository empresaRepository = new EmpresaRepository();
            EmpresaCEN empresaCEN = new EmpresaCEN(empresaRepository);
            empresaCEN.Destroy(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: EmpresaController/Delete/5
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

        //codigo silva
        public ActionResult Details(int id)
        {

            SessionInitialize();

            if (id == 0)
            {
                SessionClose();
                return new EmptyResult();
            }

            EmpresaRepository empRepo = new EmpresaRepository(session);
            EmpresaCEN empCen = new EmpresaCEN(empRepo);

            // Obtienes la empresa por su ID
            EmpresaEN empresaEN = empCen.GetByOID(id);
            System.Diagnostics.Debug.WriteLine(id);

            if (empresaEN.Videojuegos != null)
            {
                NHibernateUtil.Initialize(empresaEN.Videojuegos);
            }

            if (empresaEN.Individuos != null)
            {
                NHibernateUtil.Initialize(empresaEN.Individuos);
            }

            // Creas el modelo que pasas a la vista
            DetailsEmpresaViewModel model = new EmpresaAssembler().ConvertirENToDetailsViewModel(empresaEN);

            SessionClose();

            return View(model);
        }
    }


}
