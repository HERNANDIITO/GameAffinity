using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_GameAffinity.Models;
// using nuestro
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using NHibernate;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Reflection;
using Web_GameAffinity.Assembler;

namespace Web_GameAffinity.Controllers
{
    public class HomeController : BasicController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SessionInitialize();

            VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);

            EmpresaRepository empRepository = new EmpresaRepository();
            EmpresaCEN empCEN = new EmpresaCEN(empRepository);

            IndividuoRepository indRepository = new IndividuoRepository();
            IndividuoCEN indCEN = new IndividuoCEN(indRepository);

            bool mostrar = false;

            PerfilViewModel loggedUser = HttpContext.Session.Get<PerfilViewModel>("user");

            RegistradoCEN registradoCEN;
            RegistradoRepository registradoRepo;

            registradoRepo = new RegistradoRepository(session);
            registradoCEN = new RegistradoCEN(registradoRepo);

            var viewModel = new HomeViewModel();
            IList<ResenyaEN> resenyaSeguidos = new List<ResenyaEN>();
            IList<ResenyaEN> resenyaMentores = new List<ResenyaEN>();

            IList<RegistradoEN> mentores = registradoCEN.GetMentores(true);
            int contador = 0;

            if (loggedUser != null) {

                RegistradoEN user = registradoCEN.GetByOID(loggedUser.id);
                if (user != null) {

                    NHibernateUtil.Initialize(user.Resenya);
                    // Contar las rese�as del usuario
                    if (user.Resenya != null && user.Resenya.Count >= 3 && !user.Es_mentor)
                    {
                        mostrar = true;
                    }

                   NHibernateUtil.Initialize(user.Seguidos);
                   contador = 0;

                    foreach (var seguido in user.Seguidos)
                    {
                        if (contador >= 10) { break; } else { contador++; }

                        NHibernateUtil.Initialize(seguido.Resenya);

                        Random rndElement = new Random();
                        int random = rndElement.Next(0, seguido.Resenya.Count() - 1);

                        resenyaSeguidos.Add(seguido.Resenya[random]);

                        contador++;
                    }

                    foreach (var mentor in mentores)
                    {
                        if ( !user.Seguidos.Any( usuario => usuario.Id == mentor.Id ) ) { continue; }
                        if (contador >= 10) { break; } else { contador++; }

                        NHibernateUtil.Initialize(mentor.Resenya);

                        Random rndElement = new Random();
                        int random = rndElement.Next(0, mentor.Resenya.Count() - 1);

                        resenyaMentores.Add(mentor.Resenya[random]);

                        contador++;
                    }
                }
            } else
            {
                SessionClose();
                foreach (var mentor in mentores)
                {
                    if (contador >= 10) { break; } else { contador++; }

                    NHibernateUtil.Initialize(mentor.Resenya);

                    Random rndElement = new Random();
                    int random = rndElement.Next(0, mentor.Resenya.Count() - 1);

                    resenyaMentores.Add(mentor.Resenya[random]);

                    contador++;
                }
            }

            IList<ResenyaViewModel> resenyaSeguidosVM = new ResenyaAssembler().ConvertirListaENtoViewModel(resenyaSeguidos);
            IList<ResenyaViewModel> resenyaMentoresVM = new ResenyaAssembler().ConvertirListaENtoViewModel(resenyaMentores);

            viewModel.UltimasNovedades = videojuegoCEN.GetRecienPublicados();
            viewModel.Popular = videojuegoCEN.GetPopular();
            viewModel.ProximosLanzamientos = videojuegoCEN.GetLanzamientosProximos();
            viewModel.empresasDestacadas = empCEN.GetAll(0, 2);
            viewModel.individuos = indCEN.GetAll(0, 2);
            viewModel.ResenyaSeguidos = resenyaSeguidosVM;
            viewModel.ResenyaDeMentores = resenyaMentoresVM;
            viewModel.mostrarModalMentor = mostrar;
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Buscar()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
