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
        [HttpPost]
        public ActionResult InteraccionCambia(int idresenya, int idusuario, int operation, string contr)
        {
            SessionInitialize();
            InteraccionEN userInteraccion = null;

            InteraccionCP interaccionCP = new InteraccionCP(new SessionCPNHibernate());

            ResenyaRepository resenyaRepo = new ResenyaRepository(session);

            ResenyaCEN resenyaCEN = new ResenyaCEN(resenyaRepo);
            ResenyaEN resenya = resenyaCEN.GetByOID(idresenya);
            
            int idUserRes = resenya.Autor_resenya.Id;
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
            if(contr == "juego")
                return RedirectToAction("Details", "Videojuego", new { id = resenya.Videojuego.Id });
            else{
                return RedirectToAction("DetailsUsuario", "Registrado", new { id = idUserRes });
            }
        }
    }
}
