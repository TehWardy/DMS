using DMS.Data.EF.Interfaces;
using DMS.Objects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace DMS.Data.EF.AcceptanceTests
{
    internal static class ServiceProviderSetup
    {
        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();
            RegisterServices(services);
            return services.BuildServiceProvider();
        }

        static void RegisterServices(IServiceCollection services)
        {
            //configuration
            var configRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddTransient<IConfiguration>(provider => configRoot);

            // context setup
            services.AddDbContextPool<DMSDbContext>(opt => { });
            services.AddDbContextFactory<DMSDbContext>();
            services.AddTransient<IDMSDbContextFactory, DMSDbContextFactory>();
            services.AddTransient<IDMSAuthInfo>(provider => new TestDMSAuthInfo());

            switch (configRoot.GetSection("Settings")["DbType"])
            {
                case "sqlite":
                    services.AddTransient<IDMSModelBuildProvider, DMSSQLiteModelBuildProvider>();
                    break;
                default:
                    services.AddTransient<IDMSModelBuildProvider, DMSMSSQLModelBuildProvider>();
                    break;
            }
        }
    }

    public class TestDMSAuthInfo : IDMSAuthInfo
    {
        public string SSOUserId { get; set; } = "Guest";
    }
}