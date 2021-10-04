using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Db { get; }
        Task<bool> Save();
        void Dispose();
    }
}
