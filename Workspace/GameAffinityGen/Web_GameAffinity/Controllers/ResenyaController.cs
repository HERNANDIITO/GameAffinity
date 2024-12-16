using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.CP;
using GameAffinityGen.Infraestructure.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
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

            // Obtener la valoración del usuario para el videojuego correspondiente
            ValoracionCEN valoracionCEN = new ValoracionCEN(new ValoracionRepository(session));
            IList<ValoracionEN> valoraciones = valoracionCEN.DameValoracionesUsu(resenyaView.IdAutor);
            foreach (ValoracionEN valoracion in valoraciones)
            {
                if (valoracion.Videojuego_valorado.Id == resenyaView.VideojuegoId)
                {
                    resenyaView.Valoracion = valoracion.Nota;
                    break;
                }
            }

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
                    resenya.VideojuegoId
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
        public ActionResult Edit(ResenyaViewModel resenya)
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
                return RedirectToAction("Details", "Videojuego", new { id = resenya.VideojuegoId });
            }
            catch
            {
                return View();
            }
        }

        //POST: ResenyaControler/PublicarResenya
        [HttpPost]
        public ActionResult PublicarResenya(ResenyaViewModel resenya)
        {
            try
            {
                SessionInitialize();
                int idUser = HttpContext.Session.Get<PerfilViewModel>("user").id;
                ResenyaRepository repo = new ResenyaRepository();
                ResenyaCEN resenyaCEN = new ResenyaCEN(repo);
                int nuevaResenyaId = resenyaCEN.New_(resenya.Titulo, resenya.Texto, 0, 0, idUser, resenya.VideojuegoId);

                if (nuevaResenyaId > 0)
                {
                    ValoracionCP valoracionCP = new ValoracionCP(new SessionCPNHibernate());
                    valoracionCP.New_(resenya.Valoracion, idUser, resenya.VideojuegoId);

                    // Añadir el juego a la lista "juegos valorados"
                    ListaRepository listaRepo = new ListaRepository(session);
                    ListaCEN listaCEN = new ListaCEN(listaRepo);
                    ListaEN listaValorados = listaCEN.GetAll(0, -1).FirstOrDefault(l => l.Nombre == "Juegos valorados" && l.Autor_lista.Id == idUser);
                    NHibernateUtil.Initialize(listaValorados);

                    if (listaValorados != null)
                    {
                        ListaCP listaCP = new ListaCP(new SessionCPNHibernate());
                        listaCP.AnyadirJuego(listaValorados.Id, new List<int> { }, resenya.VideojuegoId);
                    }

                    // Obtener el usuario registrado
                    RegistradoRepository registradoRepo = new RegistradoRepository(session);
                    RegistradoCEN registradoCEN = new RegistradoCEN(registradoRepo);
                    RegistradoEN registrado = registradoCEN.GetByOID(idUser);

                        if (listaValorados.Videojuegos.Count >= 3)
                        {
                            // Actualizar el estado de es_mentor a true
                            registradoCEN.Modify(registrado.Id, registrado.Nombre, registrado.Email, registrado.Nick, true, registrado.Notificaciones, registrado.Contrasenya, registrado.Img);
                        }
                    }

                else
                {
                    // Manejar el caso en que la reseña no se creó correctamente
                    ModelState.AddModelError("", "No se pudo crear la reseña.");
                return RedirectToAction("Details", "Videojuego", new { id = resenya.VideojuegoId });
                }

                SessionClose();
                return RedirectToAction("Details", "Videojuego", new { id = resenya.VideojuegoId });
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante el proceso
                ModelState.AddModelError("", $"Error al crear la reseña: {ex.Message}");
                return RedirectToAction("Details", "Videojuego", new { id = resenya.VideojuegoId });
            }
        }

        //POST: ResenyaControler/ActualizarResenya/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarResenya(ResenyaViewModel resenya)
        {
            try
            {
                SessionInitialize();
                ResenyaRepository repo = new ResenyaRepository();
                ResenyaCEN resenyaCEN = new ResenyaCEN(repo);

                // Modificar la reseña
                resenyaCEN.Modify(resenya.Id, resenya.Titulo, resenya.Texto, resenya.Likes_contador, resenya.Dislikes_contador);

                // Obtener las valoraciones del usuario
                ValoracionCP valoracionCP = new ValoracionCP(new SessionCPNHibernate());
                ValoracionCEN valoracionCEN = new ValoracionCEN(new ValoracionRepository(session));
                IList<ValoracionEN> valoraciones = valoracionCEN.DameValoracionesUsu(resenya.IdAutor);

                // Modificar la valoración correspondiente
                foreach (ValoracionEN valoracion in valoraciones)
                {
                    if (valoracion.Videojuego_valorado.Id == resenya.VideojuegoId)
                    {
                        valoracionCP.Modify(valoracion.Id, resenya.Valoracion);
                        break;
                    }
                }

                SessionClose();
                return RedirectToAction("Details", "Videojuego", new { id = resenya.VideojuegoId });
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante el proceso
                SessionClose();
                ModelState.AddModelError("", $"Error al actualizar la reseña: {ex.Message}");
                return RedirectToAction("Details", "Videojuego", new { id = resenya.VideojuegoId });
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
