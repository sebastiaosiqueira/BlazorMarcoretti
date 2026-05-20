using Blazor_Admin.Data.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;

namespace Blazor_Admin.Data.Services
{
    public class RoleService : IRoleService
    {
        private readonly SqlConnectionConfiguration _configuration;
        public RoleService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Role>> GetRoles()
        {
            List<Role> roles = new List<Role>();
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.ConnectionString))
                {
                    const string query = "Select * from dbo.AspNetRoles";
                    SqlCommand cmd = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.Text
                    };

                    con.Open();

                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        Role role = new Role
                        {
                            Id = rdr["Id"].ToString(),
                            Name = rdr["Name"].ToString(),
                            NormalizedName = rdr["NormalizedName"].ToString(),
                            ConcurrencyStamp = rdr["ConcurrencyStamp"].ToString()
                        };
                        roles.Add(role);

                    }
                    cmd.Dispose();

                }
                return roles;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
