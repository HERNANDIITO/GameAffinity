using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Assembler
{
    public class InteraccionAssembler
    {
        public InteraccionViewModel ConvertirENToViewModel(InteraccionEN en)
        {
            InteraccionViewModel interaccion = new InteraccionViewModel();
            interaccion.Id = en.Id;
            interaccion.Liked = en.Liked;
            interaccion.Disliked = en.Disliked;
            interaccion.IdAutor = en.Autor.Id;
            interaccion.IdResenya = en.Id_resenya;
            return (interaccion);
        }

        public IList<InteraccionViewModel> ConvertirListaENtoViewModel(IList<InteraccionEN> ens)
        {
            IList<InteraccionViewModel> lista_interaccions = new List<InteraccionViewModel>();
            foreach (InteraccionEN en in ens)
            {
                lista_interaccions.Add(ConvertirENToViewModel(en));
            }
            return lista_interaccions;
        }
    }
}
