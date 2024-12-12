using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using NHibernate.Engine;
using NuGet.Common;
using System.Reflection;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;


namespace Web_GameAffinity.Controllers
{
    public class RegistradoController : Controller
    {

        private GenericSessionCP CPSession;


        // GET: RegistradoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistradoController/Login
        public ActionResult Login()
        {
            return View(new LoginRegistradoViewModel { email = string.Empty, password = string.Empty, ShowErrorModal = false });
        }

        // POST: RegistradoController/Login
        [HttpPost]
        public ActionResult Login(LoginRegistradoViewModel model)
        {
            string token = null;
            RegistradoRepository repo = new RegistradoRepository();
            RegistradoCEN cen = new RegistradoCEN(repo);
            RegistradoEN reg = cen.GetByEmail(model.email);
            token = cen.Login(reg.Id, model.password);
            if (token != null)
            {
                HttpContext.Session.SetString("token", token);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model.ShowErrorModal = true;
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            return RedirectToAction("Index", "Home");
        }



        // GET: RegistradoController/Registro
        public ActionResult Registro()
        {
            return View(new RegistroRegistradoViewModel { nombre = string.Empty, email = string.Empty, nick = string.Empty, password = string.Empty, ShowErrorModal = false });
        }

        // POST: RegistradoController/Registro
        [HttpPost]
        public ActionResult Registro(RegistroRegistradoViewModel model)
        {
            int NuevoUser = 0;
            RegistradoRepository repo = new RegistradoRepository();
            RegistradoCEN cen = new RegistradoCEN(repo);
            NuevoUser = cen.New_(model.nombre, model.email, model.nick, false, true, model.password, "");

            if (NuevoUser != 0)
            {
                HttpContext.Session.SetString("token", cen.GetToken(NuevoUser));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model.ShowErrorModal = true;
                return View(model);
            }
        }


        // GET: RegistradoController/Details/5
        public ActionResult Details()
        {
            var token = HttpContext.Session.GetString("token");
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Registrado");
            }

            RegistradoRepository repo = new RegistradoRepository();
            RegistradoCEN cen = new RegistradoCEN(repo);
            int userId = cen.CheckToken(token);

            if (userId == -1)
            {
                return RedirectToAction("Login", "Registrado");
            }

            var user = cen.GetByOID(userId);
            return View(user);
        }

        // GET: RegistradoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistradoController/Create
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

        // GET: RegistradoController/Edit/5
        public ActionResult Edit(int id)
        {
            RegistradoRepository regRepo = new RegistradoRepository();
            RegistradoCEN regCen = new RegistradoCEN(regRepo);
            RegistradoEN regEn = regCen.GetByOID(id);
            ConfiguracionPerfilViewModel configView = new RegistradoAssembler().ConvertirENToViewModel(regEn);

            return View(configView);
        }


        // POST: RegistradoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ConfiguracionPerfilViewModel configView)
        {
            try
            {
                RegistradoRepository regRepo = new RegistradoRepository();
                RegistradoCEN regCEN = new RegistradoCEN(regRepo);
                regCEN.Modify(id, configView.nombre, configView.email, configView.nick, configView.mentor, configView.notificaciones, configView.password, "");
                configView.ShowSaveModal = true;

                return View(configView);
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistradoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistradoController/Delete/5
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