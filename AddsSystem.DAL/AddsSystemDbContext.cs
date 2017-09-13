namespace AddsSystem.DAL
{
    using Models.EntityModels;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using AddsSystem.DAL.Contracts;

    public class AddsSystemDbContext : IdentityDbContext<User>, IAddsSystemDbContext
    {
        public AddsSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static AddsSystemDbContext Create()
        {
            return new AddsSystemDbContext();
        }

        public IDbSet<UserPost> UserPosts { get; set; }

        public IDbSet<PostImage> PostImages { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
