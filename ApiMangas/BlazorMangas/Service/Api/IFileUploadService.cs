namespace BlazorMangas.Service.Api;

public interface IFileUploadService
{
    Task<HttpResponseMessage> UploadFileAsync(
             string endpoint, MultipartFormDataContent content);
}
