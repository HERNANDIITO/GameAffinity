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
    public class RegistradoController : BasicController
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
            SessionInitialize();
            string token = null;
            RegistradoRepository repo = new RegistradoRepository();
            RegistradoCEN cen = new RegistradoCEN(repo);
            token = cen.Login(model.email, model.password);
            if (token != null)
            {
                RegistradoEN user = cen.GetByOID(cen.CheckToken(token));
                ConfiguracionPerfilViewModel userlogged = new RegistradoAssembler().ConvertirENToViewModel(user);
                HttpContext.Session.Set<ConfiguracionPerfilViewModel>("user", userlogged);
                SessionClose();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model.ShowErrorModal = true;
                SessionClose();
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
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
            SessionInitialize();
            int NuevoUser = 0;
            RegistradoRepository repo = new RegistradoRepository();
            RegistradoCEN cen = new RegistradoCEN(repo);
            NuevoUser = cen.New_(model.nombre, model.email, model.nick, model.password);

            if (NuevoUser != 0)
            {
                RegistradoEN user = cen.GetByOID(NuevoUser);
                ConfiguracionPerfilViewModel userlogged = new RegistradoAssembler().ConvertirENToViewModel(user);
                HttpContext.Session.Set<ConfiguracionPerfilViewModel>("user", userlogged);
                SessionClose();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model.ShowErrorModal = true;
                SessionClose();
                return View(model);
            }
        }

        // GET: RegistradoController/ConfiguracionPerfil
        public ActionResult ConfiguracionPerfil()
        {
            // Verificar si la variable global contiene un ID válido
            if (HttpContext.Session.Get<ConfiguracionPerfilViewModel>("user") == null)
            {
                // Manejar el caso en que no hay un usuario registrado
                return RedirectToAction("Login", "Registrado");
            }

            // Recuperar la información del usuario desde el repositorio
            RegistradoRepository repo = new RegistradoRepository();
            RegistradoCEN cen = new RegistradoCEN(repo);

            // Usar el ID para obtener la información del usuario
            var usuario = cen.GetByOID(HttpContext.Session.Get<ConfiguracionPerfilViewModel>("user").id);

            if (usuario == null)
            {
                // Manejar el caso en que no se encuentra el usuario
                return RedirectToAction("Login", "Registrado");
            }

            // Crear el modelo para la vista
            var viewModel = new ConfiguracionPerfilViewModel
            {
                nombre = usuario.Nombre,
                email = usuario.Email,
                nick = usuario.Nick,
                id = usuario.Id,
                password = usuario.Contrasenya,
                mentor = usuario.Es_mentor,
                notificaciones = usuario.Notificaciones
            };

            // Pasar el modelo a la vista
            return View(viewModel);
        }

        // GET: RegistradoController/Details/5
        public ActionResult Details()
        {
            SessionInitialize();
            ConfiguracionPerfilViewModel usuario = HttpContext.Session.Get<ConfiguracionPerfilViewModel>("user");
            if (usuario == null)
            {
                SessionClose();
                return RedirectToAction("Login", "Registrado");
            }

            RegistradoRepository repo = new RegistradoRepository(session);
            RegistradoCEN cen = new RegistradoCEN(repo);

            if (usuario.id == -1)
            {
                SessionClose();
                return RedirectToAction("Login", "Registrado");
            }

            RegistradoEN registrado = cen.GetByOID(usuario.id);
            ListaRepository listaRepo = new ListaRepository(session);

            //Forzar la carga
            if(registrado.Listas != null)
            {
                NHibernateUtil.Initialize(registrado.Listas);

                foreach (var lista in registrado.Listas)
                {
                    NHibernateUtil.Initialize(lista.Videojuegos);
                }
            }

            var user = new RegistradoDetailsViewModel
            {
                Registrado = registrado,
                Listas = registrado.Listas
            };

            SessionClose();
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

        public ActionResult Edit(int id, IFormCollection collection)
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
                regCEN.Modify(id, configView.nombre, configView.email, configView.nick, configView.mentor, configView.notificaciones, configView.password);
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
