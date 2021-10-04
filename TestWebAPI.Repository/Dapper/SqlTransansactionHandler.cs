using TestWebAPI.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TestWebAPI.Repository.Dapper
{
    public class SqlTransansactionHandler : IDisposable
    {
        private readonly SqlConnection sqlConnection;
        private SqlTransaction transaction;
        private bool success = false;
        private readonly string conString;

        public SqlTransansactionHandler(AppSettings settings)
        {
            this.conString = settings.ConnectionStrings.DefaultConnection;
            this.sqlConnection = new SqlConnection(conString);
        }

        public async Task OpenTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            await this.sqlConnection.OpenAsync();
            this.transaction = this.sqlConnection.BeginTransaction(isolationLevel);
        }

        public Task<T> Execute<T>(SqlCommand<T> cmd)
        {
            this.ProtectTransaction();
            return cmd.RunCommand(this.sqlConnection, this.transaction);
        }

        public async Task Execute<T>(IEnumerable<SqlCommand<T>> cmds)
        {
            this.ProtectTransaction();
            foreach (var cmd in cmds)
            {
                await cmd.RunCommand(this.sqlConnection, this.transaction);
            }
        }
         
        public void Commit()
        {
            this.ProtectTransaction();
            this.transaction.Commit();
            this.sqlConnection.Close();
            this.success = true;
        }

        public void Dispose()
        {
            if (!this.success)
            {
                this.transaction?.Rollback();
            }

            this.sqlConnection?.Dispose();
        }

        private void ProtectTransaction()
        {
            if (this.transaction == null)
                throw new InvalidOperationException("OpenTransaction() has not been called. It must be called before execute");
        }
    }
}
