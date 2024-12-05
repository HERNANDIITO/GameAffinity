using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_GameAffinity.Models;
// using nuestro
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;

namespace Web_GameAffinity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);
            IList<VideojuegoEN> ultimasNovedades = videojuegoCEN.GetRecienPublicados();
            IList<VideojuegoEN> popular = videojuegoCEN.GetPopular();
            IList<VideojuegoEN> proximosLanzamientos = videojuegoCEN.GetLanzamientosProximos();

            return View(ultimasNovedades);
        }

        public IActionResult getUltimasNovedades()
        {
            VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);
            IList<VideojuegoEN> ultimasNovedades = videojuegoCEN.GetRecienPublicados();

            return View(ultimasNovedades);
        }

        public IActionResult getPopular()
        {
            VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);
            IList<VideojuegoEN> popular = videojuegoCEN.GetPopular();

            return View(popular);
        }
        public IActionResult getProximosLanzamientos()
        {
            VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);
            IList<VideojuegoEN> proximosLanzamientos = videojuegoCEN.GetLanzamientosProximos();

            return View(proximosLanzamientos);
        }

        public IActionResult Privacy()
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
