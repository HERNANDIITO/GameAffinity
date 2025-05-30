﻿using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.Infraestructure.CP;
using GameAffinityGen.Infraestructure.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NHibernate;
using NHibernate.Engine;
using NuGet.Common;
using NuGet.LibraryModel;
using System;
using System.Reflection;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;


namespace Web_GameAffinity.Controllers
{
    public class RegistradoController : BasicController
    {

        private GenericSessionCP CPSession;
        private readonly IWebHostEnvironment _webHost;

        public RegistradoController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        // GET: RegistradoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistradoController/Login
        public ActionResult Login()
        {
            return View(new LoginRegistradoViewModel { email = string.Empty, password = string.Empty });
        }

        public ActionResult EscribirEmailReceptor()
        {
            return View();
        }

        // POST: RegistradoController/Login
        [HttpPost]
        public ActionResult Login(LoginRegistradoViewModel model)
        {
            SessionInitialize();
            string token = null;
            RegistradoRepository repo = new RegistradoRepository();
            RegistradoCEN cen = new RegistradoCEN(repo);
            RegistradoEN reg = cen.GetByEmail(model.email);

            if ( reg == null )
            {
                model.ShowErrorModal = true;
                SessionClose();
                return View(model);
            }

            token = cen.Login(reg.Id, model.password);
            if (token != null)
            {
                RegistradoEN user = cen.GetByOID(cen.CheckToken(token));
                PerfilViewModel userlogged = new RegistradoAssembler().ConvertirENToViewModel(user);
                HttpContext.Session.Set<PerfilViewModel>("user", userlogged);
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

        public ActionResult CambiarContrasena()
        {
            // Recuperar email y token de la sesión
            var email = HttpContext.Session.GetString("ResetEmail");
            var token = HttpContext.Session.GetString("ResetToken");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(token))
            {
                TempData["ErrorMessage"] = "La sesión ha expirado. Intenta nuevamente.";
                return RedirectToAction("Login", "Registrado");
            }

            ViewData["Email"] = email;
            ViewData["Token"] = token;

            return View();
        }

        [HttpPost]
        public ActionResult CambiarContrasena(NuevaContrasena nueva)
        {
            SessionInitialize();
            if (nueva.contrasena != nueva.repContrasena)
            {
                SessionClose();
                TempData["ErrorMessage"] = "Las contrasenas deben ser iguales.";
                return View();
            } else
            {
                RegistradoRepository repo = new RegistradoRepository();
                RegistradoCEN cen = new RegistradoCEN(repo);
                RegistradoEN user = cen.GetByEmail(nueva.email);
                String contrasenaantes = user.Contrasenya;
                if(user != null)
                {
                    cen.Cambiar_password(user.Id, nueva.contrasena);
                    SessionClose();
                }
                TempData["SuccessMessage"] = "Contrasena modificada con exito";
                return RedirectToAction("Login", "Registrado");
            }
        }


            [HttpPost]
        public ActionResult SerMentor()
        {
            SessionInitialize();
            RegistradoRepository repo = new RegistradoRepository();
            RegistradoCEN cen = new RegistradoCEN(repo);
            RegistradoEN user = cen.GetByOID(HttpContext.Session.Get<PerfilViewModel>("user").id);
            cen.Aceptar_mentoria(user.Id);
            SessionClose();
            return RedirectToAction("Index", "Home");
        }

        // GET: RegistradoController/Registro
        public ActionResult Registro()
        {
            return View(new RegistroRegistradoViewModel { 
                nombre = string.Empty,
                email = string.Empty,
                nick = string.Empty,
                password = string.Empty,
                ShowErrorModal = false
            });
        }

        // POST: RegistradoController/Registro
        [HttpPost]
        public async Task<ActionResult> Registro(RegistroRegistradoViewModel model)
        {
            string fileName = await FileHelper.GetFileName(model.Imagen, _webHost.WebRootPath);

            SessionInitialize();
            
            RegistradoRepository repo = new RegistradoRepository();
            RegistradoCEN cen = new RegistradoCEN(repo);
            RegistradoCP registradoCP = new RegistradoCP(new SessionCPNHibernate());

            RegistradoEN user = registradoCP.New_(
                model.nombre,
                model.email,
                model.nick,
                false,
                true,
                model.password,
                fileName
            );

            if (user != null)
            {
                PerfilViewModel userlogged = new RegistradoAssembler().ConvertirENToViewModel(user);
                HttpContext.Session.Set<PerfilViewModel>("user", userlogged);
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
            if (HttpContext.Session.Get<PerfilViewModel>("user") == null)
            {
                // Manejar el caso en que no hay un usuario registrado
                return RedirectToAction("Login", "Registrado");
            }

            // Recuperar la información del usuario desde el repositorio
            RegistradoRepository repo = new RegistradoRepository();
            RegistradoCEN cen = new RegistradoCEN(repo);

            // Usar el ID para obtener la información del usuario
            var usuario = cen.GetByOID(HttpContext.Session.Get<PerfilViewModel>("user").id);

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
                notificaciones = usuario.Notificaciones,
                Imagen = FileHelper.ConvertToIFormFile(usuario.Img)
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

            int juegosCompletados = 0;
            int juegosEmpezados = 0;
            

            //Forzar la carga
            if(registrado.Listas != null)
            {
                NHibernateUtil.Initialize(registrado.Listas);

                foreach (var lista in registrado.Listas)
                {
                    NHibernateUtil.Initialize(lista.Videojuegos);

                    if ( lista.Nombre == "Juegos empezados")
                    {
                        juegosEmpezados = lista.Videojuegos.Count;
                    }

                    if (lista.Nombre == "Juegos completados")
                    {
                        juegosCompletados = lista.Videojuegos.Count;
                    }
                }
            }

            // Obtener las reseñas del usuario
            IList<ResenyaViewModel> userResenyas = null;
            if (registrado.Resenya != null)
            {
                NHibernateUtil.Initialize(registrado.Resenya);
                userResenyas = new ResenyaAssembler().ConvertirListaENtoViewModel(registrado.Resenya).ToList();
            }

            foreach ( var resenya in userResenyas){
                resenya.NombreVideojuego = new VideojuegoCEN(new VideojuegoRepository(session)).GetByoID(resenya.VideojuegoId).Nombre;
                resenya.Valoracion = new ValoracionCEN(new ValoracionRepository(session)).DameValoracionesJuego(resenya.VideojuegoId).FirstOrDefault(j => j.Autor_valoracion.Id  == resenya.IdAutor).Nota;
            }

            userResenyas = userResenyas.OrderByDescending(r => (r.Likes_contador - r.Dislikes_contador)).ToList();

            var user = new RegistradoDetailsViewModel
            {
                Registrado = registrado,
                Listas = registrado.Listas,
                JuegosCompletados = juegosCompletados,
                JuegosEmpezados = juegosEmpezados,
                Resenyas = userResenyas
            };

            SessionClose();
            return View(user);
        }




        // GET: RegistradoController/DetailsUsuario/5
        public ActionResult DetailsUsuario(int id)


        {
            SessionInitialize();

            PerfilViewModel usuario = HttpContext.Session.Get<PerfilViewModel>("user");

            if(usuario == null)
            {
                return RedirectToAction("Login", "Registrado");
            }

            if (usuario.id == id)
            {
                return RedirectToAction("Details", "Registrado");
            }

            RegistradoRepository regRepository = new RegistradoRepository(session);
            RegistradoCEN regCEN = new RegistradoCEN(regRepository);
            RegistradoEN regEN = regCEN.GetByOID(id);

            Console.WriteLine("DETAILS USUARIO: " + id);
            
            if (regEN == null)
            {
                Console.WriteLine("regEN NULL");

                SessionClose();
                return RedirectToAction("Index", "Home");
            }

            ListaRepository listaRepo = new ListaRepository(session);

            int juegosCompletados = 0;
            int juegosEmpezados = 0;

            //Forzar la carga
            if (regEN.Listas != null)
            {
                NHibernateUtil.Initialize(regEN.Listas);

                foreach (var lista in regEN.Listas)
                {
                    NHibernateUtil.Initialize(lista.Videojuegos);

                    if (lista.Nombre == "Juegos empezados")
                    {
                        juegosEmpezados = lista.Videojuegos.Count;
                    }

                    if (lista.Nombre == "Juegos completados")
                    {
                        juegosCompletados = lista.Videojuegos.Count;
                    }
                }
            }

            // Obtener las reseñas del usuario
            IList<ResenyaViewModel> userResenyas = null;
            if (regEN.Resenya != null)
            {
                NHibernateUtil.Initialize(regEN.Resenya);
                userResenyas = new ResenyaAssembler().ConvertirListaENtoViewModel(regEN.Resenya).ToList();
            }

            VideojuegoRepository videojuegoRepository = new VideojuegoRepository(session);
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);

            ValoracionRepository valoracionRepository = new ValoracionRepository(session);
            ValoracionCEN valoracionCEN = new ValoracionCEN(valoracionRepository);

            foreach (var resenya in userResenyas)
            {
                VideojuegoEN videojuego = videojuegoCEN.GetByoID(resenya.VideojuegoId);
                IList<ValoracionEN> valoracionesJuego = valoracionCEN.DameValoracionesJuego(resenya.Id);
                ValoracionEN valoracion = valoracionesJuego.FirstOrDefault(j => j.Autor_valoracion.Id == resenya.IdAutor);

                resenya.NombreVideojuego = videojuego.Nombre;
                resenya.Valoracion = valoracion != null ? valoracion.Nota : 0;
                resenya.imageVideojuego = videojuego.Imagen;
            }
            
            PerfilViewModel loggedUser = HttpContext.Session.Get<PerfilViewModel>("user");

            bool following = false;
            if ( loggedUser != null )
            {
                Console.WriteLine("Logged user!");
                RegistradoEN loggedUserEN = regCEN.GetByOID(loggedUser.id);
                if ( loggedUserEN != null )
                {
                    Console.WriteLine("Logged found!");

                    NHibernateUtil.Initialize(loggedUserEN.Seguidos);
                    if ( loggedUserEN.Seguidos.Any( seguido => seguido.Id == regEN.Id ) )
                    {
                        Console.WriteLine("Siguiendo!");

                        following = true;
                    }
                }
            }

            //calculo de la afinidad
            // Obtener el usuario logueado desde la sesión
            int miID = 0;
            var userSession = HttpContext.Session.Get<PerfilViewModel>("user");
            if (userSession != null && userSession.id > 0)
            {
                miID = userSession.id;
            }

            RegistradoCP regCP = new RegistradoCP(new SessionCPNHibernate());
            int afinity = regCP.Consultar_afinidades(miID, id);
            userResenyas = userResenyas.OrderByDescending(r => (r.Likes_contador - r.Dislikes_contador)).ToList();

            var user = new RegistradoDetailsViewModel
            {
                Registrado = regEN,
                Listas = regEN.Listas,
                JuegosCompletados = juegosCompletados,
                JuegosEmpezados = juegosEmpezados,
                Resenyas = userResenyas,
                following = following,
                afinidad = afinity
            };

            SessionClose();
            return View(user);
        }
        
        [HttpPost]
        public ActionResult Seguir(int id)
        {
            SessionInitialize();

            RegistradoRepository regRepository = new RegistradoRepository(session);
            RegistradoCEN regCEN = new RegistradoCEN(regRepository);

            PerfilViewModel userViewModel = HttpContext.Session.Get<PerfilViewModel>("user");
            RegistradoEN usuarioQueSigue = regCEN.GetByOID(userViewModel.id);

            IList<int> ids = new List<int>();

            if ( usuarioQueSigue != null )
            {
                NHibernateUtil.Initialize(usuarioQueSigue.Seguidos);
                ids = usuarioQueSigue.Seguidos.Select(r => r.Id).ToList();
            } else
            {
                return View("Error", new { message = "Tu sesión no es válida." });
            }

            SessionClose();

            SessionInitialize();
            regRepository = new RegistradoRepository();
            regCEN = new RegistradoCEN(regRepository);

            RegistradoEN usuarioASeguir = regCEN.GetByOID(id);

            if ( usuarioASeguir != null && usuarioQueSigue != null )
            {
                ids.Add(usuarioASeguir.Id);

                regRepository.Seguir_perfiles(usuarioQueSigue.Id, [id]);
                SessionClose();

                return RedirectToAction("DetailsUsuario", new { id = id });
            } else
            {
                Console.WriteLine("ERROR");
                SessionClose();
                return View("Error", new { message = "No existe ese usuari o tu sesión no es válida." });
            }
        }

        [HttpPost]
        public ActionResult DejarDeSeguir(int id)
        {
            SessionInitialize();

            RegistradoRepository regRepository = new RegistradoRepository(session);
            RegistradoCEN regCEN = new RegistradoCEN(regRepository);

            PerfilViewModel userViewModel = HttpContext.Session.Get<PerfilViewModel>("user");
            RegistradoEN usuarioQueSigue = regCEN.GetByOID(userViewModel.id);

            IList<int> ids = new List<int>();

            if (usuarioQueSigue != null)
            {
                NHibernateUtil.Initialize(usuarioQueSigue.Seguidos);
                ids = usuarioQueSigue.Seguidos.Select(r => r.Id).ToList();
            }
            else
            {
                return View("Error", new { message = "Tu sesión no es válida." });
            }

            SessionClose();

            SessionInitialize();
            regRepository = new RegistradoRepository();
            regCEN = new RegistradoCEN(regRepository);

            RegistradoEN usuarioASeguir = regCEN.GetByOID(id);

            if (usuarioASeguir != null && usuarioQueSigue != null)
            {
                Console.WriteLine("usuarioASeguir: " + usuarioASeguir.Nombre);
                Console.WriteLine("usuarioQueSigue: " + usuarioQueSigue.Nombre);

                Console.WriteLine("ids antes: " + ids.Count);

                ids.Add(usuarioASeguir.Id);

                Console.WriteLine("ids despues: " + ids.Count);
                Console.WriteLine("id: " + id);

                regRepository.Dejar_de_seguir_perfiles(usuarioQueSigue.Id, [id]);
                SessionClose();

                return RedirectToAction("DetailsUsuario", new { id = id });
            }
            else
            {
                Console.WriteLine("ERROR");
                SessionClose();
                return View("Error", new { message = "No existe ese usuari o tu sesión no es válida." });
            }
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
            PerfilViewModel configView = new RegistradoAssembler().ConvertirENToViewModel(regEn);

            return View(configView);
        }


        // POST: RegistradoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ConfiguracionPerfilViewModel configView)
        {
            string fileName = "", path = "";
            if (configView.Imagen != null && configView.Imagen.Length > 0)
            {
                fileName = Path.GetFileName(configView.Imagen.FileName).Trim();

                string directory = _webHost.WebRootPath + "/Images/";
                path = Path.Combine((directory), fileName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = System.IO.File.Create(path))
                {
                    await configView.Imagen.CopyToAsync(stream);
                }

                fileName = "/Images/" + fileName;
            }
            try
            {
                RegistradoRepository regRepo = new RegistradoRepository();
                RegistradoCEN regCEN = new RegistradoCEN(regRepo);
                regCEN.Modify(
                    id,
                    configView.nombre,
                    configView.email,
                    configView.nick,
                    configView.mentor,
                    configView.notificaciones,
                    configView.password,
                    fileName
                );
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
