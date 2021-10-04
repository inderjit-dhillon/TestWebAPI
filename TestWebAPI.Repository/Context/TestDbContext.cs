using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TestWebAPI.Repository.Common;

#nullable disable

namespace TestWebAPI.Repository.Context
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }

    }
}
