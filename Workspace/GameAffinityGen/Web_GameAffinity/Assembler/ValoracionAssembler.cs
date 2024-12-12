using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Assembler
{
    public class ValoracionAssembler
    {
        public ValoracionViewModel ConvertirENToViewModel(ValoracionEN en)
        {
            ValoracionViewModel valoracion = new ValoracionViewModel();
            valoracion.Id = en.Id;
            valoracion.Autor_valoracion = en.Autor_valoracion;
            valoracion.Videojuego_valorado = en.Videojuego_valorado;
            valoracion.Nota = valoracion.Nota;
            return valoracion;

        }

        public IList<ValoracionViewModel> ConvertirListaENtoViewModel(IList<ValoracionEN> ens)
        {
            IList<ValoracionViewModel> lista_valoracions = new List<ValoracionViewModel>();
            foreach (ValoracionEN en in ens)
            {
                lista_valoracions.Add(ConvertirENToViewModel(en));
            }
            return lista_valoracions;
        }
    }
}
