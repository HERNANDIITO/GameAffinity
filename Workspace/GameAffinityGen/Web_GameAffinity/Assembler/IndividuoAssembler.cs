using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Assembler
{
    public class IndividuoAssembler
    {
        public IndividuoViewModel ConvertirENToViewModel( IndividuoEN en)
        {
            IndividuoViewModel individuo = new IndividuoViewModel();
            individuo.Id = en.Id;
            individuo.Nombre = en.Nombre;
            individuo.Apellido = en.Apellido;
            individuo.FechaNac = en.FechaNac;
            individuo.Rol = en.Rol;
            individuo.nombreNacionalidad = en.Nacionalidad.Nombre;
            individuo.idNacionalidad = en.Nacionalidad.Id;
            individuo.Biografia = en.Biografia;
            return( individuo );
        }
        public IList<IndividuoViewModel> ConvertirListaENtoViewModel(IList<IndividuoEN> ens)
        {
            IList<IndividuoViewModel> lista_individuos = new List<IndividuoViewModel>();
            foreach (IndividuoEN en in ens)
            {
                lista_individuos.Add(ConvertirENToViewModel(en));
            }
            return lista_individuos;
        }
    }
}
