using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Controllers
{
    public class ResenyaController : BasicController
    {
        // GET: ResenyaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ResenyaController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            ResenyaRepository resenyaRepository = new ResenyaRepository(session);
            ResenyaCEN resenyaCEN = new ResenyaCEN(resenyaRepository);

            ResenyaEN resenyaEn = resenyaCEN.GetByOID(id);
            ResenyaViewModel resenyaView = new ResenyaAssembler().ConvertirENToViewModel(resenyaEn);

            SessionClose();
            return View(resenyaView);
        }

        // GET: ResenyaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResenyaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResenyaViewModel resenya)
        {
            try
            {
                ResenyaRepository resenyaRepository = new ResenyaRepository();
                ResenyaCEN resenyaCEN = new ResenyaCEN(resenyaRepository);
                resenyaCEN.New_(
                    resenya.Titulo,
                    resenya.Texto,
                    0,
                    0,
                    resenya.IdAutor,
                    resenya.IdVideojuego
                );
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResenyaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ResenyaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ResenyaViewModel resenya)
        {
            try
            {
                ResenyaRepository resenyaRepository = new ResenyaRepository();
                ResenyaCEN resenyaCEN = new ResenyaCEN(resenyaRepository);
                resenyaCEN.Modify(
                    resenya.Id,
                    resenya.Titulo,
                    resenya.Texto,
                    resenya.Likes_contador,
                    resenya.Dislikes_contador
                );
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResenyaController/Delete/5
        public ActionResult Delete(int id)
        {
            ResenyaRepository resenyaRepository = new ResenyaRepository();
            ResenyaCEN resenyaCEN = new ResenyaCEN(resenyaRepository);
            resenyaCEN.Destroy(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: ResenyaController/Delete/5
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
