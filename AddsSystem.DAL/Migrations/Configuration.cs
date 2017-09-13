namespace AddsSystem.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<AddsSystemDbContext>  //It was internal, not a production project, changed: public
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; 
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AddsSystemDbContext context)
        {
        }
    }
}

//Migracii:
//1-vo Pravq DBContext-a si
//2-vo enable-migrations na papka DAL
//3-ro pravq class DatabaseConfig.cs
//4-to v Global.asax v Application_Start() method-a pisha: DatabaseConfig.Initialize() i dr.
//v AccountController.cs Action: Register, v User osven UserName i Email slagam i drugite kum user profila,Line 169


