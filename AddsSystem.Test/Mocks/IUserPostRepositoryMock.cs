namespace AddsSystem.Test.Mocks
{
    using AddsSystem.DAL.Repositories;
    using AddsSystem.Models.EntityModels;
    using AddsSystem.Services.Contracts;

    public interface IUserPostRepositoryMock
    {
        IGenericRepository<UserPost> userData { get; }
        IPostService postsData { get; }
    }
}
