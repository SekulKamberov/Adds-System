namespace AddsSystem.Test.Mocks
{
    using AddsSystem.Models.EntityModels;
    using System.Data.Entity;

    public interface IUserPostDbContext
    {
        DbSet<UserPost> UserPost { get; set; }

        int SaveChanges();
    }
}
