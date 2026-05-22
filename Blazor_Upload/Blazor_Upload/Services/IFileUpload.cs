
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor_Upload.Services
{
    public interface IFileUpload
    {
        Task UploadAsync(IBrowserFile arquivo);
    }
}
