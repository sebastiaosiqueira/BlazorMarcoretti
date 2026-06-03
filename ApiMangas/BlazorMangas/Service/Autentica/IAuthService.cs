using BlazorMangas.Models;

namespace BlazorMangas.Service.Autentica
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
    }
}
