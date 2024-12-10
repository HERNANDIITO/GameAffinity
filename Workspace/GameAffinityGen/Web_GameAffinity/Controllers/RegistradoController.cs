using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Controllers
{
    public class RegistradoController : BasicController
    {
        // Variable global estática para almacenar el ID
        private static int? globalRegistradoId;

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
            RegistradoRepository repo = new RegistradoRepository();
            RegistradoCEN cen = new RegistradoCEN(repo);
            if (cen.Login(model.email, model.password) != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                model.ShowErrorModal = true;
                return View(model);
            }
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
            RegistradoRepository repo = new RegistradoRepository();
            RegistradoCEN cen = new RegistradoCEN(repo);

            var nuevoId = cen.New_(model.nombre, model.email, model.nick, model.password);

            if (nuevoId != null)
            {
                // Asignar el ID a la variable global
                globalRegistradoId = nuevoId;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                model.ShowErrorModal = true;
                return View(model);
            }
        }

        // GET: RegistradoController/ConfiguracionPerfil
        public ActionResult ConfiguracionPerfil()
        {
            // Verificar si la variable global contiene un ID válido
            if (globalRegistradoId == null)
            {
                // Manejar el caso en que no hay un usuario registrado
                return RedirectToAction("Login", "Registrado");
            }

            // Recuperar la información del usuario desde el repositorio
            RegistradoRepository repo = new RegistradoRepository();
            RegistradoCEN cen = new RegistradoCEN(repo);

            // Usar el ID para obtener la información del usuario
            var usuario = cen.GetByOID(globalRegistradoId.Value);

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
        public ActionResult Details(int id)
        {
            return View();
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
            return View();
        }

        // POST: RegistradoController/Edit/5
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