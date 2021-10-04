using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Repository.Context;
using TestWebAPI.Repository.Interfaces;

namespace TestWebAPI.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public TestDbContext _dbContext;
        private bool _disposed = false;

        public UnitOfWork(TestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public async Task<bool> Save()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
