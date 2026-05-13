using Microsoft.Data.SqlClient;
namespace ArticlesPlataform.Services
{
    public class ArticleManager
    {
       private readonly SqlConnection _sqlconection;

        public ArticleManager(SqlConnection sqlconection)
        {
            _sqlconection = sqlconection;
           
        }
        public async Task<bool> InsertNewArticle(newArticle newarticle)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT_NewArticle", _sqlconection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Title", newarticle.Title );
                cmd.Parameters.AddWithValue("SubTitle",newarticle.SubTitle );
                cmd.Parameters.AddWithValue("ArticleBody",newarticle.ArticleBody );
                cmd.Parameters.AddWithValue("Category",newarticle.Category );
                cmd.Parameters.AddWithValue("Authors",newArticle.AuthorsToString(newarticle.Authors) );
              
                if(await cmd.ExecuteNonQueryAsync() ==1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }

        public class newArticle
        {
            public string Title { get; set; } = string.Empty;
            public string SubTitle { get; set; } = string.Empty;
            public string ArticleBody { get; set; } = string.Empty;
            public int Category { get; set; }
            public List<string> Authors { get; set; } = new List<string>();
            public static string AuthorsToString(List<string> authors)
            {
                string result = "";
                if(authors.Count == 1)
                {
                    result = authors[0];
                    return result;
                    
                }
               for(int i = 0; i < authors.Count; i++)
                {
                    if(i != authors.Count - 1)
                    {
                        result += authors[i] + ";";
                    }
                    else
                    {
                        result += authors[i];
                       
                    }
                }
                return result;
            }
        }

    }
}
