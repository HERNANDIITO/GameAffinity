using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.CP;
using GameAffinityGen.Infraestructure.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using System.Reflection;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Controllers
{
    public class InteraccionController : BasicController
    {
        // GET: InteraccionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InteraccionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InteraccionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InteraccionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InteraccionViewModel interaccionNueva)
        {
            try
            {
                InteraccionCP interaccionCP = new InteraccionCP(new SessionCPNHibernate());
                interaccionCP.New_(interaccionNueva.IdAutor, interaccionNueva.Disliked, interaccionNueva.Liked, interaccionNueva.IdResenya, interaccionNueva.IdResenya);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: InteraccionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLike(int id, int idrenseya)
        {
            try
            {
                // se ha pulsado dislike cuando habia un like
                InteraccionCP interaccionCP = new InteraccionCP(new SessionCPNHibernate());
                interaccionCP.Modify(id, true, false, idrenseya);
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDislike(int id, int idrenseya)
        {
            try
            {
                InteraccionCP interaccionCP = new InteraccionCP(new SessionCPNHibernate());
                interaccionCP.Modify(id, false, true, idrenseya);
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: InteraccionController/Delete/5
        public ActionResult Delete(int id, int idresenya)
        {
            InteraccionCP interaccionCP = new InteraccionCP(new SessionCPNHibernate());
            interaccionCP.Destroy(id);
            return View();
        }

        [HttpPost]
        public ActionResult InteraccionCambia(int idresenya, int idusuario, int operation)
        {
            SessionInitialize();
            InteraccionEN userInteraccion = null;

            InteraccionCP interaccionCP = new InteraccionCP(new SessionCPNHibernate());

            ResenyaRepository resenyaRepo = new ResenyaRepository(session);

            ResenyaCEN resenyaCEN = new ResenyaCEN(resenyaRepo);
            ResenyaEN resenya = resenyaCEN.GetByOID(idresenya);

            if (idusuario > 0)
            {
                // bucamos la interaccion del usuario
                try
                {
                    NHibernateUtil.Initialize(resenya.Interacciones);
                    userInteraccion = resenya.Interacciones?.FirstOrDefault<InteraccionEN>(r => r.Id_resenya == resenya.Id && r.Autor.Id == idusuario);
                } catch
                {
                    userInteraccion = null;
                }

                if (userInteraccion != null) // existe
                {
                    // hacer edit y delete
                    // 0 es like y 1 es dislike
                    if (operation == 0 && userInteraccion.Liked)
                    {
                        // delete like
                        interaccionCP.Destroy(userInteraccion.Id);
                    }
                    else if (operation == 1 && userInteraccion.Disliked) {
                        // delete dislike
                        interaccionCP.Destroy(userInteraccion.Id);
                    } 
                    else if (operation == 0 && !userInteraccion.Liked)
                    {
                        // edit like
                        interaccionCP.Modify(userInteraccion.Id, false, true, idresenya);
                    }
                    else if (operation == 1 && !userInteraccion.Disliked)
                    {
                        // edit dislike
                        interaccionCP.Modify(userInteraccion.Id, true, false, idresenya);
                    }
                }
                else // no existe
                {
                    //hacer create
                    // 0 es like y 1 es dislike
                    if (operation == 0)
                    {
                        interaccionCP.New_(idusuario, false, true, idresenya, idresenya);

                    }
                    else if (operation == 1)
                    {
                        interaccionCP.New_(idusuario, true, false, idresenya, idresenya);
                    }
                }
            } 
            else
            {
                SessionClose();
                return RedirectToAction("Login", "Registrado");
            }
            SessionClose();
            return RedirectToAction("Details", "Videojuego", new { id = resenya.Videojuego.Id  });
        }

        //public ActionResult InteraccionesResenyas(ResenyaViewModel resenya, int IdUsuario)
        //{
        //    SessionInitialize();
        //    InteraccionRepository repo = new InteraccionRepository();
        //    InteraccionCEN interaccionCEN = new InteraccionCEN(repo);

        //    IList < InteraccionEN > todasLasInteracciones = interaccionCEN.GetAll( 0, -1 );

        //    // obtenemos la interaccion del autor si existe
        //    InteraccionEN userInteraccion = null;
        //    if (IdUsuario != -1)
        //    {
        //        userInteraccion = todasLasInteracciones.FirstOrDefault<InteraccionEN>(r => r.Id_resenya == resenya.Id && r.Autor.Id == resenya.IdAutor);
        //    }
        //    else //usuario no registrado
        //    { 
        //        // llevar a login
        //    }

        //    // existe una interaccion con el usuario registrado
        //    if (userInteraccion != null)
        //    {
        //        ViewData["did_like"] = userInteraccion.Liked;
        //        ViewData["did_dislike"] = userInteraccion.Disliked;

        //        if (userInteraccion.Liked) // si le ha dado like
        //        {
        //            ViewData["like_button"] = "Delete";
        //            ViewData["dislike_button"] = "Edit";
        //        }
        //        else // si le ha dado dislike
        //        {
        //            ViewData["like_button"] = "Edit";
        //            ViewData["dislike_button"] = "Delete";
        //        }
        //    }
        //    else // no existe interaccion con el usuario registrado
        //    {
        //        ViewData["like_button"] = "Create";
        //        ViewData["dislike_button"] = "Create";
        //    }

            
        //    //InteraccionViewModel interaccionView = new InteraccionAssembler().ConvertirENToViewModel(interaccionEN);

        //    ViewData["likes"] = resenya.Likes_contador;
        //    ViewData["dislikes"] = resenya.Dislikes_contador;
        //    SessionClose();
        //    return PartialView("interaccionesResenyas");
        //}
    }
}
