using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Assembler
{
    public class EmpresaAssembler
    {
        public EmpresaViewModel ConvertirENToViewModel(EmpresaEN en)
        {
            EmpresaViewModel empresa = new EmpresaViewModel();
            empresa.Id = en.Id;
            empresa.Nombre = en.Nombre;
            empresa.Descripcion = en.Descripcion;
            empresa.Nota = en.Nota;
            //empresa.Videojuegos = en.Videojuegos;
            //empresa.Individuos = en.Individuos;
            return (empresa);
        }

        public DetailsEmpresaViewModel ConvertirENToDetailsViewModel(EmpresaEN en)
        {
            DetailsEmpresaViewModel empresa = new DetailsEmpresaViewModel();
            empresa.Id = en.Id;
            empresa.Nombre = en.Nombre;
            empresa.Descripcion = en.Descripcion;
            empresa.Nota = en.Nota;
            empresa.Videojuegos = en.Videojuegos;
            empresa.Individuos = en.Individuos;
            empresa.Imagen = FileHelper.ConvertToIFormFile(en.Img);
            //empresa.Individuos = en.Individuos;
            return empresa;
        }

        public IList<EmpresaViewModel> ConvertirListaENtoViewModel(IList<EmpresaEN> ens)
        {
            IList<EmpresaViewModel> lista_empresas = new List<EmpresaViewModel>();
            foreach (EmpresaEN en in ens)
            {
                lista_empresas.Add(ConvertirENToViewModel(en));
            }
            return lista_empresas;
        }
    }
}
