namespace AddsSystem.Test.Mocks
{
    using AddsSystem.Models.EntityModels;
    using System.Data.Entity;

    public class FakeUserPostDbContext : IUserPostDbContext
    {
        public FakeUserPostDbContext()
        {
            this.UserPost = new FakeUserPostDbSet();
        }

        public DbSet<UserPost> UserPost { get; set; }
        public int SaveChanges()
        {
            return 0;
        }
    }
}
