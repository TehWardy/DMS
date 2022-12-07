using DMS.Data.EF;
using DMS.Data.EF.Interfaces;
using DMS.Objects;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DMS.AcceptanceTests
{
    public static class DMSWebApplicationFactoryExtensions
    {
        static readonly object multiThreadedLock = new();

        public static void EnsureDMSSetupForTesting(this WebApplicationFactory<Program> appFactory)
        {
            lock (multiThreadedLock)
            {
                using var scope = appFactory.Services.CreateScope();
                var scopedServices = scope.ServiceProvider;

                using var db = new DMSDbContext(
                    scopedServices.GetRequiredService<IConfiguration>(), 
                    scopedServices.GetRequiredService<IDMSAuthInfo>(),
                    scopedServices.GetRequiredService<IDMSModelBuildProvider>());
                db.Migrate();
                SeedTestData(db);
            }
        }

        static void SeedTestData(DMSDbContext db)
        {

        }
    }
}
