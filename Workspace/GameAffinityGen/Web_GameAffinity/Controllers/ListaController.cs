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
            return View();
        }

        // GET: ListaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaController/Create
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

        // GET: ListaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListaController/Edit/5
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

        // GET: ListaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
