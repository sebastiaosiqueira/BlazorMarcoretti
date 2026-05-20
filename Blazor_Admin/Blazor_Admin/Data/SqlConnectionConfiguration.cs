namespace Blazor_Admin.Data
{
    public class SqlConnectionConfiguration
    {
        public string ConnectionString {  get; set; }
        public SqlConnectionConfiguration(string stringConexao) { ConnectionString = stringConexao;  }
    }
}
