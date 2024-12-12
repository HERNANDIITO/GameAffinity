using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.CP;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;
using GameAffinityGen.ApplicationCore.Enumerated.GameAffinity;

namespace Web_GameAffinity.Controllers
{
    public class ValoracionController : BasicController
    {
        // GET: ValoracionController
        public ActionResult Index()
        {
            SessionInitialize();
            ValoracionRepository valoracionRepository = new ValoracionRepository();
            ValoracionCEN valoracionCEN = new ValoracionCEN(valoracionRepository);

            IList<ValoracionEN> listEN = valoracionCEN.GetAll(0, -1);

            IEnumerable<ValoracionViewModel> listaValoracions = new ValoracionAssembler().ConvertirListaENtoViewModel(listEN).ToList();
            SessionClose();

            return View(listaValoracions);
        }

        // GET: ValoracionController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ValoracionRepository valoracionRepository = new ValoracionRepository(session);
            ValoracionCEN valoracionCEN = new ValoracionCEN(valoracionRepository);

            ValoracionEN valoracionEn = valoracionCEN.GetByOID(id);
            ValoracionViewModel valoracionView = new ValoracionAssembler().ConvertirENToViewModel(valoracionEn);

            SessionClose();
            return View(valoracionView);
        }

        // GET: ValoracionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ValoracionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ValoracionViewModel valoracion)
        {
            try
            {
                SessionInitialize();
                ValoracionRepository valoracionRepository = new ValoracionRepository();
                ValoracionCP valoracionCP = new ValoracionCP(new SessionCPNHibernate());
                valoracionCP.New_( valoracion.Nota, valoracion.Autor_valoracion.Id, valoracion.Videojuego_valorado.Id);
                SessionClose();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ValoracionController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            ValoracionRepository valoracionRepository = new ValoracionRepository(session);
            ValoracionCEN valoracionCEN = new ValoracionCEN(valoracionRepository);

            ValoracionEN valoracionEn = valoracionCEN.GetByOID(id);
            ValoracionViewModel valoracionView = new ValoracionAssembler().ConvertirENToViewModel(valoracionEn);

            SessionClose();
            return View(valoracionView);
        }

        // POST: ValoracionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ValoracionViewModel valoracion)
        {
            try
            {
                ValoracionRepository valoracionRepository = new ValoracionRepository();
                ValoracionCP valoracionCP = new ValoracionCP(new SessionCPNHibernate());
                valoracionCP.Modify(id, valoracion.Nota);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ValoracionController/Delete/5
        public ActionResult Delete(int id)
        {
            ValoracionRepository valoracionRepository = new ValoracionRepository();
            ValoracionCP valoracionCP = new ValoracionCP(new SessionCPNHibernate());
            valoracionCP.Destroy(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: ValoracionController/Delete/5
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
