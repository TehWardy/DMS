using DMS.Data.EF.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DMS.Data.EF.AcceptanceTests
{
    public class TestDMSDbContextFactory
    {
        static readonly IServiceProvider serviceProvider;
        readonly IDMSDbContextFactory contextFactory;

        static TestDMSDbContextFactory() 
            => serviceProvider = ServiceProviderSetup.GetServiceProvider();

        public TestDMSDbContextFactory() 
            => contextFactory = serviceProvider.GetRequiredService<IDMSDbContextFactory>();

        public DMSDbContext CreateDbContext() 
            => DatabaseSetup.EnsureDMSSetupForTesting(contextFactory.CreateDbContext());
    }
}
