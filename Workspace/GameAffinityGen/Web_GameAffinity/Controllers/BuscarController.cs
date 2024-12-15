using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using Microsoft.AspNetCore.Mvc;
using Web_GameAffinity.Models;
// Using nuestro
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;

namespace Web_GameAffinity.Controllers
{
    public class BuscarController : Controller
    {
        public IActionResult Buscar()
        {
            VideojuegoRepository videojuegoRepository = new VideojuegoRepository();
            EmpresaRepository empresaRepository = new EmpresaRepository();
            IndividuoRepository individuoRepository = new IndividuoRepository();

            VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepository);
            EmpresaCEN empresaCEN = new EmpresaCEN(empresaRepository);
            IndividuoCEN individuoCEN = new IndividuoCEN(individuoRepository);

            var viewModel = new BuscarViewModel
            {
                Videojuegos = videojuegoCEN.GetAll(0, -1),
                Empresas = empresaCEN.GetAll(0, -1),
                Personas = individuoCEN.GetAll(0, -1)
            };

            return View(viewModel);
        }
    }
}
