using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Controllers
{
    public class IndividuoController : BasicController
    {
        // GET: IndividuoController
        public ActionResult Index()
        {
            SessionInitialize();
            IndividuoRepository individuoRepository = new IndividuoRepository();
            IndividuoCEN individuoCEN = new IndividuoCEN(individuoRepository);

            IList<IndividuoEN> listaEN = individuoCEN.GetAll(0, -1);

            IEnumerable<IndividuoViewModel> lista_individuos = new IndividuoAssembler().ConvertirListaENtoViewModel(listaEN).ToList();
            SessionClose();

            return View(lista_individuos);
        }

        // GET: IndividuoController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            IndividuoRepository individuoRepository = new IndividuoRepository(session);
            IndividuoCEN IndividuoCEN = new IndividuoCEN(individuoRepository);

            IndividuoEN individuoEn = IndividuoCEN.GetByOID(id);
            IndividuoViewModel individuoView = new IndividuoAssembler().ConvertirENToViewModel(individuoEn);

            SessionClose();
            return View(individuoView);
        }

        // GET: IndividuoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndividuoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IndividuoViewModel individuo)
        {
            try
            {
                IndividuoRepository individuoRepository = new IndividuoRepository();
                IndividuoCEN individuoCEN = new IndividuoCEN(individuoRepository);
                individuoCEN.New_(individuo.Nombre, individuo.Apellido, individuo.FechaNac, individuo.Nacionalidad, individuo.Rol, individuo.Biografia, individuo.Imagen);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndividuoController/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();
            IndividuoRepository individuoRepository = new IndividuoRepository(session);
            IndividuoCEN individuoCEN = new IndividuoCEN(individuoRepository);

            IndividuoEN individuoEn = individuoCEN.GetByOID(id);
            IndividuoViewModel individuoView = new IndividuoAssembler().ConvertirENToViewModel(individuoEn);

            SessionClose();
            return View(individuoView);
        }

        // POST: IndividuoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IndividuoViewModel individuo)
        {
            try
            {
                IndividuoRepository individuoRepository = new IndividuoRepository();
                IndividuoCEN individuoCEN = new IndividuoCEN(individuoRepository);
                individuoCEN.Modify(
                    id, 
                    individuo.Nombre, 
                    individuo.Apellido, 
                    individuo.FechaNac, 
                    individuo.Nacionalidad, 
                    individuo.Rol, 
                    individuo.Biografia,
                    individuo.Imagen
                    );
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndividuoController/Delete/5
        public ActionResult Delete(int id)
        {
            IndividuoRepository individuoRepository = new IndividuoRepository();
            IndividuoCEN individuoCEN = new IndividuoCEN(individuoRepository);
            individuoCEN.Destroy(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: IndividuoController/Delete/5
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
