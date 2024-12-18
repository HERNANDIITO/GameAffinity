using GameAffinityGen.ApplicationCore.EN.GameAffinity;


namespace Web_GameAffinity.Models
{
    public class BuscarViewModel
    {
        public IList<VideojuegoEN> Videojuegos { get; set; }

        public IList<EmpresaEN> Empresas { get; set; }

        public IList<IndividuoEN> Personas { get; set; }
    }
}
