using DMS.Data.EF.Interfaces;
using DMS.Objects;
using Microsoft.Extensions.Configuration;

namespace DMS.Data.EF
{
    // This Wrapper in case we want to take a different approach to the EF factory for our context instancing 
    // or just want a single place to call the ctor to avoid affecting a lot of files when the ctor changes.
    public class DMSDbContextFactory : IDMSDbContextFactory
    {
/*        readonly IDbContextFactory<DMSDbContext> externalFactory;

        public DMSDbContextFactory(IDbContextFactory<DMSDbContext> externalFactory)
            => this.externalFactory = externalFactory;

        public DMSDbContext CreateDbContext()
            => externalFactory.CreateDbContext();*/

        readonly IConfiguration configuration;
        readonly IDMSAuthInfo authInfo;
        readonly IDMSModelBuildProvider modelBuildProvider;

        public DMSDbContextFactory(IConfiguration configuration, IDMSAuthInfo authInfo, IDMSModelBuildProvider modelBuildProvider)
        {
            this.configuration = configuration;
            this.authInfo = authInfo;
            this.modelBuildProvider = modelBuildProvider;
        }

        public DMSDbContext CreateDbContext()
            => new(configuration, authInfo, modelBuildProvider);
    }
}