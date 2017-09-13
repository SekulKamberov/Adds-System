namespace AddsSystem.Client.App_Start
{
    using AddsSystem.DAL;
    using AddsSystem.DAL.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AddsSystemDbContext, Configuration>());
            //AddsSystemDbContext.Create().Database.Initialize(true);
        }
    }
}