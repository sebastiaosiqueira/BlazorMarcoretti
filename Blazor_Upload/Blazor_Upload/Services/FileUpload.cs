

using Microsoft.AspNetCore.Components.Forms;

namespace Blazor_Upload.Services
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _env;

        public FileUpload(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task UploadAsync(IBrowserFile arquivoEntrada)
        {
            try
            {
                // 1. Garante que a pasta existe (Opcional, mas evita erros)
                var pastaUpload = Path.Combine(_env.WebRootPath,"wwwroot", "Uploads");
                if (!Directory.Exists(pastaUpload)) Directory.CreateDirectory(pastaUpload);

                var path = Path.Combine(pastaUpload, arquivoEntrada.Name);

                // 2. Abre o stream de leitura do arquivo. 
                // Importante: No Blazor, você deve definir um tamanho máximo permitido. 
                // Exemplo: 10MB (1024 * 1024 * 10)
                using var streamEntrada = arquivoEntrada.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024);

                // 3. Grava diretamente no disco (mais eficiente que usar MemoryStream)
                using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                await streamEntrada.CopyToAsync(fs);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
