using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace DMS.Data.EF.Interfaces
{
    public interface IDMSModelBuildProvider
    {
        void Configure(IConfiguration configuration, DbContextOptionsBuilder optionsBuilder);
        void Create(ModelBuilder modelBuilder);
        void MigrateDatabase(DatabaseFacade database);
    }
}