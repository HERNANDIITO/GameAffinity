using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using Web_GameAffinity.Models;


namespace Web_GameAffinity.Controllers
{
    public class EmpresaController : BasicController
    {
        // GET: EmpresaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmpresaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpresaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpresaController/Create
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

        // GET: EmpresaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpresaController/Edit/5
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

        // GET: EmpresaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
        var model = new EmpresaViewModel
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
