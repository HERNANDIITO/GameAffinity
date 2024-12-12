using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web_GameAffinity
{
    public static class FileHelper
    {
        /// <summary>
        /// Convierte la ruta de un archivo a un objeto IFormFile.
        /// </summary>
        /// <param name="filePath">La ruta al archivo que se va a convertir.</param>
        /// <returns>Un objeto IFormFile representando el archivo.</returns>
        public static IFormFile ConvertToIFormFile(string filePath)
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

        /// <summary>
        /// Obtiene la ruta dado un IFormFile y el path del webhost.
        /// </summary>
        /// <param name="file">IFormFile del archivo que se quiere subir.</param>
        /// <param name="webHostPath">La ruta al archivo que se va a convertir.</param>
        /// <returns>La ruta del archivos ubdio al servidor en string</returns>
        public async static Task<string> GetFileName( IFormFile file, string webHostPath )
        {
            string fileName = "", path = "";
            if (file != null && file.Length > 0)
            {
                fileName = Path.GetFileName(file.FileName).Trim();

                string directory = webHostPath + "/Images/";
                path = Path.Combine((directory), fileName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using (var stream = System.IO.File.Create(path))
                {
                    await file.CopyToAsync(stream);
                }

                fileName = "/Images/" + fileName;
            }

            return fileName;
        }

        private static string GetContentType(string filePath)
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
    }
}
