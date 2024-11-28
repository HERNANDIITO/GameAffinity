using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;

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
            return View();
        }

        // GET: VideojuegoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideojuegoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: VideojuegoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VideojuegoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: VideojuegoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
