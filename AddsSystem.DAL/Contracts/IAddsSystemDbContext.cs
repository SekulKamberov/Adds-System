namespace AddsSystem.DAL.Contracts
{
    using global::AddsSystem.Models.EntityModels;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IAddsSystemDbContext
    {
        IDbSet<PostImage> PostImages { get; set; }

        IDbSet<UserPost> UserPosts { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
