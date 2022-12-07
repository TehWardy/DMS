using Xunit;

namespace DMS.Data.EF.AcceptanceTests
{
    [CollectionDefinition(nameof(DMSDbContextCollection))]
    public class DMSDbContextCollection : ICollectionFixture<TestDMSDbContextFactory> { }
}
