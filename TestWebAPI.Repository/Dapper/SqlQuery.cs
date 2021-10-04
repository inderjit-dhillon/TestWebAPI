using System.Data;
using System.Threading.Tasks;

namespace TestWebAPI.Repository.Dapper
{
    public abstract class SqlQuery<T>
    {
        public abstract Task<T> RunQuery(IDbConnection dbConnection);
    }
}