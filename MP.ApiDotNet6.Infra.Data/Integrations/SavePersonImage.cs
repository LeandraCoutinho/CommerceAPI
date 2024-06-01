using MP.ApiDotNet6.Domain.Integrations;
using System;
using System.IO;

namespace MP.ApiDotNet6.Infra.Data.Integrations
{
    public class SavePersonImage : ISavePersonImage
    {
        private readonly string _filePath;

        public SavePersonImage()
        {
            _filePath = @"C:/Users/leand/Documents/Imagens";
        }

        public string Save(string imageBase64)
        {
            // Extrair a extensão do arquivo (png ou jpeg)
            var fileExt = imageBase64.Substring(imageBase64.IndexOf("/") + 1,
                imageBase64.IndexOf(";") - imageBase64.IndexOf("/") - 1);

            // Extrair o código base64 da imagem
            var base64Code = imageBase64.Substring(imageBase64.IndexOf(",") + 1);
            var imgBytes = Convert.FromBase64String(base64Code);

            // Gerar um nome de arquivo único
            var fileName = Guid.NewGuid().ToString() + "." + fileExt;

            // Salvar o arquivo de imagem diretamente no diretório _filePath
            var filePath = Path.Combine(_filePath, fileName);
            using (var imageFile = new FileStream(filePath, FileMode.Create))
            {
                imageFile.Write(imgBytes, 0, imgBytes.Length);
                imageFile.Flush();
            }

            return filePath; // Retornar o caminho completo do arquivo salvo
        }
    }
}