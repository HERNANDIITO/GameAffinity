using GameAffinityGen.ApplicationCore.EN.GameAffinity;

namespace Web_GameAffinity.Models
{
    public class HomeViewModel
    {
        public IList<VideojuegoEN> UltimasNovedades { get; set; }
        public IList<VideojuegoEN> Popular { get; set; }
        public IList<VideojuegoEN> ProximosLanzamientos { get; set; }
        public IList<ResenyaEN> ResenyaDeMentores { get; set; }
        public IList<ResenyaEN> ResenyaSeguidos { get; set; }
        public IList<EmpresaEN> empresasDestacadas { get; set; }
        public IList<IndividuoEN> individuos { get; set; }
    }
}
