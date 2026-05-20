using Blazor_Admin.Data.Models;

namespace Blazor_Admin.Data.Services
{

    public interface IRoleService
    {
        Task<List<Role>> GetRoles();
      
    }
}
