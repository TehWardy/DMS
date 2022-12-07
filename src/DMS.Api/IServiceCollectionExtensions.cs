using DMS.Api.EDM;
using DMS.Data.EF;
using DMS.Data.EF.Interfaces;
using EventLibrary;
using Microsoft.AspNetCore.OData;

namespace DMS.Api
{
    public static partial class IServiceCollectionExtensions
    {
        static EventHub DMSEventHub = new EventHub();

        public static void AddDMS(this IServiceCollection services, string atPath)
        {
            services.AddDbContextPool<DMSDbContext>(opt => { });
            services.AddDbContextFactory<DMSDbContext>();
            services.AddTransient<IDMSDbContextFactory, DMSDbContextFactory>();

            services.AddSecurityServices();
            services.AddMasterdataServices();
            services.AddTransactionServices();
            services.AddImportServices();
            services.AddDMSApiLayer(atPath);
            services.AddEventing();
        }

        static void AddEventing(this IServiceCollection services)
            => services.AddSingleton<IEventHub>(DMSEventHub);

        public static void AddDMSApiLayer(this IServiceCollection services, string atPath)
        {
            services.AddControllers()
                .AddOData(opt =>
                {
                    opt.Expand().Count().Filter().Select().OrderBy().SetMaxTop(1000);
                    opt.AddRouteComponents(atPath, new DMSModelBuilder().Build().EDMModel);
                });
        }
    }
}