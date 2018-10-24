using System.Data;
using System.Data.SqlClient;

namespace Ckm.Convites.Repository
{
    public class BaseRepository
    {
        public IDbConnection con;

        public BaseRepository()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Convites;Integrated Security=True";
            con = new SqlConnection(connectionString);
        }
    }
}
