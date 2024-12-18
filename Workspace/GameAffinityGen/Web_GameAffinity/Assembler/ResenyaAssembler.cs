using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using NHibernate;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Assembler
{
    public class ResenyaAssembler
    {
        public ResenyaViewModel ConvertirENToViewModel(ResenyaEN en)
        {
            ResenyaViewModel resenya = new ResenyaViewModel();
            if(en != null)
            {
                NHibernateUtil.Initialize(en.Autor_resenya);
                resenya.Id = en.Id;
                resenya.Titulo = en.Titulo;
                resenya.Texto = en.Texto;
                resenya.Likes_contador = en.Likes_contador;
                resenya.Dislikes_contador = en.Dislikes_contador;
                resenya.VideojuegoId = en.Videojuego.Id;
                resenya.IdAutor = en.Autor_resenya.Id;
                resenya.NombreAutor = en.Autor_resenya.Nick;
                resenya.Interacciones = new InteraccionAssembler().ConvertirListaENtoViewModel(en.Interacciones);
            }
            // añadir reseña
            return (resenya);
        }
        public IList<ResenyaViewModel> ConvertirListaENtoViewModel(IList<ResenyaEN> ens)
        {
            IList<ResenyaViewModel> lista_resenyas = new List<ResenyaViewModel>();
            foreach (ResenyaEN en in ens)
            {
                lista_resenyas.Add(ConvertirENToViewModel(en));
            }
            return lista_resenyas;
        }
    }
}
