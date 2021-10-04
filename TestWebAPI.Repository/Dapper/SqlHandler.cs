using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TestWebAPI.Utility;

namespace TestWebAPI.Repository.Dapper
{
    public class SqlHandler
    {
        private readonly string connectionString;

        public SqlHandler(AppSettings settings)
        {
            connectionString = settings.ConnectionStrings.DefaultConnection;
        }

        public async Task<T> ExecuteQuery<T>(SqlQuery<T> query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var result = await query.RunQuery(connection);
                return result;
            }
        }

        public async Task<T> ExecuteCommand<T>(
            SqlCommand<T> command,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted
        )
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var transaction = connection.BeginTransaction(isolationLevel);
                var result = await command.RunCommand(connection, transaction);

                transaction.Commit();

                return result;
            }
        }

        public async Task ExecuteCommand<T>(IEnumerable<SqlCommand<T>> commands)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var transaction = connection.BeginTransaction();

                foreach (var cmd in commands)
                {
                    await cmd.RunCommand(connection, transaction);
                }

                transaction.Commit();
            }
        }
    }
}
