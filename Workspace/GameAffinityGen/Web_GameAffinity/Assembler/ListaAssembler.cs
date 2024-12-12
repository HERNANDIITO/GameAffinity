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
            list.Imagen = ConvertToIFormFile(en.Img);
            return list;
        }

        public IFormFile ConvertToIFormFile(string filePath)
        {
            filePath = "./wwwroot/" + filePath;
            if (!File.Exists(filePath))
            {
                filePath = "wwwroot/Images/missing_img.jpg";
            }

            string contentType = GetContentType(filePath);

            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var fileName = Path.GetFileName(filePath);

            var formFile = new FormFile(stream, 0, stream.Length, "file", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType
            };

            return formFile;
        }

        private string GetContentType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                ".tiff" => "image/tiff",
                ".webp" => "image/webp",
                _ => "application/octet-stream" 
            };
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
