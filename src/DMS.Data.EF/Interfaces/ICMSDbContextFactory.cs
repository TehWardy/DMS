namespace DMS.Data.EF.Interfaces
{
    public interface IDMSDbContextFactory
    {
        DMSDbContext CreateDbContext();
    }
}