namespace AddsSystem.Test.Mocks
{
    using System.Collections.Generic;
    using AddsSystem.DAL.Repositories;
    using AddsSystem.Models.EntityModels;
    using AddsSystem.Services.Contracts;

    public abstract class UserPostRepositoryMock : IUserPostRepositoryMock
    {
        public UserPostRepositoryMock()
        {
            this.PopulateFakeData();
            this.ArrangeUserPostRepositoryMock();
        }
                                            
        public IGenericRepository<UserPost> userData { get; protected set; }

        public IPostService postsData { get; protected set; }

        protected ICollection<UserPost> FakeUserPostCollection { get; private set; }

        private void PopulateFakeData()
        {
            this.FakeUserPostCollection = new List<UserPost>
            {
                new UserPost { UserPostId = 1, Title = "Pitbull", Info = "For fight", UserId = "1Pitbull" },
                new UserPost { UserPostId = 2, Title = "Canaan Dog", Info = "Hunting dog", UserId = "2Canaan" },
                new UserPost { UserPostId = 3, Title = "Chinese Crested", Info = "Chinese sweet", UserId = "3Chinese" },
                new UserPost { UserPostId = 4, Title = "Chinook", Info = "Chinook very sweet", UserId = "4Chinook" },
            };
        }

        protected abstract void ArrangeUserPostRepositoryMock();
    }
}
