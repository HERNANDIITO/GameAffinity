using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;
using NHibernate;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Controllers
{
    public class EmpresaController : BasicController
    {
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

        // GET: EmpresaController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            EmpresaRepository empresaRepository = new EmpresaRepository(session);
            EmpresaCEN empresaCEN = new EmpresaCEN(empresaRepository);

            EmpresaEN empresaEn = empresaCEN.GetByOID(id);
            EmpresaViewModel empresaView = new EmpresaAssembler().ConvertirENToViewModel(empresaEn);

            SessionClose();
            return View(empresaView);
        }

        // GET: EmpresaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpresaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaViewModel empresa)
        {
            try
            {
                EmpresaRepository empresaRepository = new EmpresaRepository();
                EmpresaCEN empresaCEN = new EmpresaCEN(empresaRepository);
                empresaCEN.New_(empresa.Nombre, empresa.Descripcion, empresa.Nota);

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
        public ActionResult Edit(int id, EmpresaViewModel empresa)
        {
            try
            {
                EmpresaRepository empresaRepository = new EmpresaRepository();
                EmpresaCEN empresaCEN = new EmpresaCEN(empresaRepository);
                empresaCEN.Modify(id, empresa.Nombre, empresa.Descripcion, empresa.Nota);

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
        public ActionResult DetailsEmpresa(int id)
        {
            SessionInitialize();

            EmpresaRepository empRepo = new EmpresaRepository(session);
            EmpresaCEN empCen = new EmpresaCEN(empRepo);

            // Obtienes la empresa por su ID
            EmpresaEN empresaEN = empCen.GetByOID(id);

            if (empresaEN.Videojuegos != null)
            {
                NHibernateUtil.Initialize(empresaEN.Videojuegos);
            }

            // Creas el modelo que pasas a la vista
            var model = new DetailsEmpresaViewModel
            {
                nombre = empresaEN.Nombre,
                descripcion = empresaEN.Descripcion,
                nota = empresaEN.Nota,
                videojuegos = empresaEN.Videojuegos
            };

            SessionClose();

            return View(model);
        }
    }


}
