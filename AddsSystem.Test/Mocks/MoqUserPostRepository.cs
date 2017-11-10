namespace AddsSystem.Test.Mocks
{
    using Moq;
    using System.Collections.Generic;
    using AddsSystem.Models.EntityModels;
    using AddsSystem.Services.Contracts;
    using System.Linq;

    public class MoqUserPostRepository : UserPostRepositoryMock, IUserPostRepositoryMock
    {
        protected override void ArrangeUserPostRepositoryMock()
        {
            var moqUserPostRepository = new Mock<IPostService>();
            moqUserPostRepository.Setup(r => r.CreateUserPost(null, null, null, null));
            moqUserPostRepository.Setup(z => z.AllPosts()).Returns(this.FakeUserPostCollection as IQueryable<UserPost>);

            this.postsData = moqUserPostRepository.Object;
        }
    }
}
