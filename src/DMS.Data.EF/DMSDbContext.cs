using DMS.Data.EF.Interfaces;
using DMS.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DMS.Data.EF
{
    public partial class DMSDbContext : DbContext
    {
        public IDMSAuthInfo AuthInfo { get; }

        readonly IDMSModelBuildProvider modelBuildProvider;
        readonly IConfiguration configuration;

        public DMSDbContext(IConfiguration configuration, IDMSAuthInfo authInfo, IDMSModelBuildProvider modelBuildProvider)
        { 
            this.configuration = configuration;
            AuthInfo = authInfo;
            this.modelBuildProvider = modelBuildProvider;  
        }

        public void Migrate() 
            => modelBuildProvider.MigrateDatabase(Database);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuildProvider.Create(modelBuilder);
            ApplyFilters(modelBuilder);
            SeedDatabase(modelBuilder);
        }

        void ApplyFilters(ModelBuilder modelBuilder)
        {
            
        }

        void SeedDatabase(ModelBuilder modelBuilder)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = configuration.GetConnectionString("DMS");
            modelBuildProvider.Configure(configuration, optionsBuilder);

            optionsBuilder.LogTo((message) => {
                if (message.Contains("Executing") || message.Contains("transaction"))
                    System.Diagnostics.Debug.WriteLine(message);
            });
        }
    }
}