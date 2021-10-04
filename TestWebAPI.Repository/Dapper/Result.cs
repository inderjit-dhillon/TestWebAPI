
using TestWebAPI.Repository.Dapper;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI.Repository.Dapper
{
    public class Results<T> : SqlQuery<List<T>>
    {
        private readonly object param;
        private readonly string spName;

        public Results(string spName, object param = null)
        {
            this.param = param;
            this.spName = spName;
        }

        public override async Task<List<T>> RunQuery(IDbConnection dbConnection)
        {
            var results = await dbConnection.QueryAsync<T>(
               this.spName,
                param: this.param,
                commandType: CommandType.StoredProcedure
            );

            return results.AsList();
        }

    }
    public class Result<T> : SqlQuery<T>
    {
        private readonly object param;
        private readonly string spName;

        public Result(string spName, object param = null)
        {
            this.param = param;
            this.spName = spName;
        }

        public override async Task<T> RunQuery(IDbConnection dbConnection)
        {
            return await dbConnection.QueryFirstOrDefaultAsync<T>(
               this.spName,
                param: this.param,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
