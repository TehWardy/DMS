namespace DMS.Data.EF.AcceptanceTests
{
    public static class DatabaseSetup
    {
        static readonly object multiThreadedLock = new();

        public static DMSDbContext EnsureDMSSetupForTesting(DMSDbContext db)
        {
            lock (multiThreadedLock)
            {
                db.Migrate();
                SeedTestData(db);
            }

            return db;
        }

        static void SeedTestData(DMSDbContext db)
        {

        }
    }
}
