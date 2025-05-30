﻿using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;
using GameAffinityGen.ApplicationCore.Enumerated.GameAffinity;
using System.Collections.Specialized;
using NHibernate;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;
using GameAffinityGen.Infraestructure.CP;

namespace Web_GameAffinity.Controllers
{
    public class VideojuegoController : BasicController
    {

        private readonly IWebHostEnvironment _webHost;

        public VideojuegoController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        // GET: VideojuegoController
        public ActionResult Index()
        {
            var user = HttpContext.Session.Get<ConfiguracionPerfilViewModel>("user");


            if (user != null)
            {
                ModeradorRepository repo = new ModeradorRepository();
                ModeradorCEN cen = new ModeradorCEN(repo);
                ModeradorEN esModerador = cen.GetByOID(user.id);

                if (esModerador == null)
                {
                    return RedirectToAction("IndexRegistrado", "Videojuego");
                }
            }

            SessionInitialize();
            VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);

            IList<VideojuegoEN> listEN = videojuegoCEN.GetAll(0, -1);

            IEnumerable<VideojuegoViewModel> listaVideojuegos = new VideojuegoAssembler().ConvertirListaENtoViewModel(listEN).ToList();
            SessionClose();

            return View(listaVideojuegos);
        }

        //Vista videojuego para registrados
        public ActionResult IndexRegistrado()
        {
            var user = HttpContext.Session.Get<ConfiguracionPerfilViewModel>("user");

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

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
            SessionInitialize();
            VideojuegoRepository videojuegoRepository = new VideojuegoRepository(session);
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);
            IList<ResenyaViewModel> listaResenyas = null;

            VideojuegoEN videojuegoEn = videojuegoCEN.GetByoID(id);
            if (videojuegoEn == null)
            {
                return NotFound();
            }
            VideojuegoViewModel videojuegoView = new VideojuegoAssembler().ConvertirENToViewModel(videojuegoEn);

            if (videojuegoEn.Resenyas != null)
            {
                NHibernateUtil.Initialize(videojuegoEn.Resenyas);
                listaResenyas = new ResenyaAssembler().ConvertirListaENtoViewModel(videojuegoEn.Resenyas).ToList();
            }

            listaResenyas = listaResenyas.OrderByDescending(r => (r.Likes_contador - r.Dislikes_contador)).ToList();

            if (videojuegoEn.Valoracion != null)
            {
                NHibernateUtil.Initialize(videojuegoEn.Valoracion);
            }

            if (videojuegoEn.Individuos != null)
            {
                NHibernateUtil.Initialize(videojuegoEn.Individuos);
            }

            if (videojuegoEn.Empresas != null)
            {
                NHibernateUtil.Initialize(videojuegoEn.Empresas);
            }

            // Asignar la nota de valoración a las reseñas correspondientes
            if (listaResenyas != null && videojuegoEn.Valoracion != null)
            {
                foreach (var resenya in listaResenyas)
                {
                    var valoracion = videojuegoEn.Valoracion.FirstOrDefault(v => v.Autor_valoracion.Id == resenya.IdAutor);
                    if (valoracion != null)
                    {
                        resenya.Valoracion = valoracion.Nota;
                    }
                }
            }

            ListasDeUsuarioViewModel listas_de_usuario = new ListasDeUsuarioViewModel();

            if(HttpContext.Session.Get<ConfiguracionPerfilViewModel>("user") != null)
            {
                int idUser = HttpContext.Session.Get<ConfiguracionPerfilViewModel>("user").id;
                RegistradoRepository registradorepo = new RegistradoRepository(session);
                RegistradoCEN registradoCEN = new RegistradoCEN(registradorepo);
                RegistradoEN registradoEN = registradoCEN.GetByOID(idUser);
                listas_de_usuario.IdUsuario = idUser;
                NHibernateUtil.Initialize(registradoEN.Listas);
                //listas_de_usuario.ListasDeUsuario = new ListaAssembler().ConvertirListENToViewModel(registradoEN.Listas);
                listas_de_usuario.ListasDeUsuario = registradoEN.Listas;
                listas_de_usuario.IdVideojuegoAnyadir = id;
                foreach (var lista in listas_de_usuario.ListasDeUsuario)
                {
                    NHibernateUtil.Initialize(lista.Videojuegos);
                }
            }

            VideojuegoDetailsViewModel vistaJuego = new VideojuegoDetailsViewModel
            {
                Videojuego = videojuegoView,
                Resenyas = listaResenyas,
                Valoraciones = videojuegoEn.Valoracion,
                ListasDeUsuario = listas_de_usuario,
                Individuos = (IList<IndividuoEN>)videojuegoEn.Individuos,
                Empresas = videojuegoEn.Empresas
            };

            SessionClose();
            return View(vistaJuego);
        }


        // GET: VideojuegoController/Create
        public ActionResult Create()
        {
            //Obtener enums
            IList<SelectListItem> listaGeneros = new List<SelectListItem>();
            listaGeneros.Add(new SelectListItem { Text = "Terror", Value = GenerosEnum.Terror.ToString() });
            listaGeneros.Add(new SelectListItem { Text = "Acción", Value = GenerosEnum.Accion.ToString() });
            listaGeneros.Add(new SelectListItem { Text = "Puzzles", Value = GenerosEnum.Puzzles.ToString() });
            listaGeneros.Add(new SelectListItem { Text = "Mundo Abierto", Value = GenerosEnum.Mundo_abierto.ToString() });
            ViewData["GenerosItems"] = listaGeneros;

            return View();

        }

        // POST: VideojuegoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VideojuegoViewModel videojuego)
        {
            string fileName = "", path = "";
            if (videojuego.Imagen != null && videojuego.Imagen.Length > 0)
            {
                fileName = Path.GetFileName(videojuego.Imagen.FileName).Trim();

                string directory = _webHost.WebRootPath + "/Images/";
                path = Path.Combine((directory), fileName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = System.IO.File.Create(path))
                {
                    await videojuego.Imagen.CopyToAsync(stream);
                }

                fileName = "/Images/" + fileName;
            }

            try
            {
                VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
                VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);
                videojuegoCEN.New_(
                    videojuego.Nombre,
                    videojuego.Descripcion,
                    0.0f,
                    videojuego.Genero,
                    videojuego.FechaLanzamiento,
                    fileName
                );
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
            SessionInitialize();
            VideojuegoRepository videojuegoRepository = new VideojuegoRepository(session);
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);

            VideojuegoEN videojuegoEn = videojuegoCEN.GetByoID(id);
            VideojuegoViewModel videojuegoView = new VideojuegoAssembler().ConvertirENToViewModel(videojuegoEn);
            SessionClose();

            IList<SelectListItem> listaGeneros = new List<SelectListItem>();
            listaGeneros.Add(new SelectListItem { Text = "Terror", Value = GenerosEnum.Terror.ToString() });
            listaGeneros.Add(new SelectListItem { Text = "Acción", Value = GenerosEnum.Accion.ToString() });
            listaGeneros.Add(new SelectListItem { Text = "Puzzles", Value = GenerosEnum.Puzzles.ToString() });
            listaGeneros.Add(new SelectListItem { Text = "Mundo Abierto", Value = GenerosEnum.Mundo_abierto.ToString() });
            ViewData["GenerosItems"] = listaGeneros;

            return View(videojuegoView);
        }

        // POST: VideojuegoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, VideojuegoViewModel videojuego)
        {
            string fileName = await FileHelper.GetFileName(videojuego.Imagen, _webHost.WebRootPath);

            try
            {
                VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
                VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);
                videojuegoCEN.Modify(
                    videojuego.Id,
                    videojuego.Nombre,
                    videojuego.Descripcion,
                    0.0f,
                    videojuego.Genero,
                    videojuego.FechaLanzamiento,
                    fileName
                );
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
            VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);
            videojuegoCEN.Destroy(id);
            return RedirectToAction(nameof(Index));
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

        public ActionResult ResenyaPartial(int id)
        {
            ResenyaRepository repo = new ResenyaRepository();
            ResenyaCEN cen = new ResenyaCEN(repo);
            ResenyaEN en = cen.GetByOID(id);
            return View(en);
        }
    }
}
