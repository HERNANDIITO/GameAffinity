using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.Enumerated.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web_GameAffinity.Assembler;
using Web_GameAffinity.Models;
using GameAffinityGen.ApplicationCore.Enumerated.GameAffinity;
using GameAffinityGen.Infraestructure.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;
using NHibernate;

namespace Web_GameAffinity.Controllers
{
    public class IndividuoController : BasicController
    {
        // GET: IndividuoController
        public ActionResult Index()
        {
            SessionInitialize();
            IndividuoRepository individuoRepository = new IndividuoRepository(session);
            IndividuoCEN individuoCEN = new IndividuoCEN(individuoRepository);

            IList<IndividuoEN> listaEN = individuoCEN.GetAll(0, -1);

            foreach (var individuoEN in listaEN)
            {
                NHibernateUtil.Initialize(individuoEN.Nacionalidad);
            }

            IEnumerable<IndividuoViewModel> lista_individuos = new IndividuoAssembler().ConvertirListaENtoViewModel(listaEN).ToList();
            SessionClose();

            return View(lista_individuos);
        }

        // GET: IndividuoController/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            IndividuoRepository individuoRepository = new IndividuoRepository(session);
            IndividuoCEN IndividuoCEN = new IndividuoCEN(individuoRepository);

            IndividuoEN individuoEn = IndividuoCEN.GetByOID(id);
            IndividuoViewModel individuoView = new IndividuoAssembler().ConvertirENToViewModel(individuoEn);

            SessionClose();
            return View(individuoView);
        }

        // GET: IndividuoController/Create
        public ActionResult Create()
        {
            IList<SelectListItem> listaRoles = new List<SelectListItem>();
            listaRoles.Add(new SelectListItem { Text = "Illustrador", Value = RolesEnum.Ilustrador.ToString() });
            listaRoles.Add(new SelectListItem { Text = "Director", Value = RolesEnum.Director.ToString() });
            listaRoles.Add(new SelectListItem { Text = "Múscio", Value = RolesEnum.Musico.ToString() });
            listaRoles.Add(new SelectListItem { Text = "Programador", Value = RolesEnum.Programador.ToString() });
            ViewData["RolesItems"] = listaRoles;

            PaisesRepository paisesRepository = new PaisesRepository();
            PaisesCEN paisesCEN = new PaisesCEN(paisesRepository);
            IList<PaisesEN> listaPaises = paisesCEN.ReadAll(0, -1);
            IList<SelectListItem> paisesItems = new List<SelectListItem>();

            foreach (PaisesEN paisesen in listaPaises)
            {
                paisesItems.Add(new SelectListItem { Text = paisesen.Nombre, Value = paisesen.Id.ToString() });
            }
            ViewData["paisesItems"] = paisesItems;
            return View();
        }

        // POST: IndividuoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IndividuoViewModel individuo)
        {
            try
            {
                IndividuoRepository individuoRepository = new IndividuoRepository();
                IndividuoCEN individuoCEN = new IndividuoCEN(individuoRepository);
                individuoCEN.New_(
                    individuo.Nombre,
                    individuo.Apellido,
                    individuo.FechaNac,
                    individuo.Rol,
                    individuo.Biografia,
                    "", //añadir imagen cuando este el campo de subir imagen
                    individuo.idNacionalidad
                    );
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndividuoController/Edit/5
        public ActionResult Edit(int id)
        {
            // obtener valores existentes para ponerlos en los campos
            SessionInitialize();
            IndividuoRepository individuoRepository = new IndividuoRepository(session);
            IndividuoCEN individuoCEN = new IndividuoCEN(individuoRepository);

            IndividuoEN individuoEn = individuoCEN.GetByOID(id);
            IndividuoViewModel individuoView = new IndividuoAssembler().ConvertirENToViewModel(individuoEn);


            // obtener roles
            IList<SelectListItem> listaRoles = new List<SelectListItem>();
            listaRoles.Add(new SelectListItem { Text = "Illustrador", Value = RolesEnum.Ilustrador.ToString() });
            listaRoles.Add(new SelectListItem { Text = "Director", Value = RolesEnum.Director.ToString() });
            listaRoles.Add(new SelectListItem { Text = "Músico", Value = RolesEnum.Musico.ToString() });
            listaRoles.Add(new SelectListItem { Text = "Programador", Value = RolesEnum.Programador.ToString() });
            ViewData["RolesItems"] = listaRoles;

            PaisesRepository paisesRepository = new PaisesRepository(session);
            PaisesCEN paisesCEN = new PaisesCEN(paisesRepository);
            IList<PaisesEN> listaPaises = paisesCEN.ReadAll(0, -1);
            IList<SelectListItem> paisesItems = new List<SelectListItem>();

            foreach (PaisesEN paisesen in listaPaises)
            {
                paisesItems.Add(new SelectListItem { Text = paisesen.Nombre, Value = paisesen.Id.ToString() });
            }
            ViewData["paisesItems"] = paisesItems;
            SessionClose();

            // retorno de valores a la vista
            return View(individuoView);
        }

        // POST: IndividuoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IndividuoViewModel individuo)
        {
            try
            {
                IndividuoRepository individuoRepository = new IndividuoRepository();
                IndividuoCEN individuoCEN = new IndividuoCEN(individuoRepository);
                individuoCEN.Modify(
                    id, 
                    individuo.Nombre, 
                    individuo.Apellido, 
                    individuo.FechaNac, 
                    individuo.Rol, 
                    individuo.Biografia,
                    ""//añadir imagen cuando este el campo de subir imagen   individuo.Imagen
                    );
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndividuoController/Delete/5
        public ActionResult Delete(int id)
        {
            IndividuoRepository individuoRepository = new IndividuoRepository();
            IndividuoCEN individuoCEN = new IndividuoCEN(individuoRepository);
            individuoCEN.Destroy(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: IndividuoController/Delete/5
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
