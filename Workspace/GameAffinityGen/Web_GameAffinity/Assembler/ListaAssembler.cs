using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Assembler
{
    public class ListaAssembler
    {

        public ListaViewModel ConvertirENToViewModel(ListaEN en)
        {
            ListaViewModel list = new ListaViewModel();
            list.Id = en.Id;
            list.Nombre = en.Nombre;
            list.Descripcion = en.Descripcion;
            list.Por_defecto = en.Por_defecto;
            list.Autor_lista = en.Autor_lista;
            list.Videojuegos = en.Videojuegos;
            list.Imagen = FileHelper.ConvertToIFormFile(en.Img);
            return list;
        }

        //esto es para tratar listas de listas (conjuntos de listas)
        public IList<ListaViewModel> ConvertirListENToViewModel(IList<ListaEN> ens)
        {
            IList<ListaViewModel> lists = new List<ListaViewModel>();
            foreach (ListaEN en in ens)
            {
                lists.Add(ConvertirENToViewModel(en));
            }
            return lists;
        }
    }
}
