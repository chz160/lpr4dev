using System;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Lpr4dev.Data;

namespace Lpr4dev.Tests.DBMigrations.Helpers
{
    public class SqliteInMemory : IDisposable
    {
        private readonly DbConnection _connection;

        public SqliteInMemory()
        {
            this.ContextOptions = new DbContextOptionsBuilder<Lpr4devDbContext>()
                .UseSqlite($"Data Source=file:cachedb{Guid.NewGuid()}?mode=memory&cache=shared")
                .Options;
            _connection = RelationalOptionsExtension.Extract(ContextOptions).Connection;
            using var context = new Lpr4devDbContext(ContextOptions);
            context.Database.Migrate();
        }

        protected internal DbContextOptions<Lpr4devDbContext> ContextOptions { get; }

  

        public void Dispose() => _connection.Dispose();
    }
}