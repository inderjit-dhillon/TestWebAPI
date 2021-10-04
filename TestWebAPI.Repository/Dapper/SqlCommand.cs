using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TestWebAPI.Repository.Dapper
{
    public abstract class SqlCommand<T>
    {
        public abstract Task<T> RunCommand(IDbConnection dbConnection, SqlTransaction transaction);
    }
}
