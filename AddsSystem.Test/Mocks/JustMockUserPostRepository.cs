namespace AddsSystem.Test.Mocks
{
    using System.Linq;
    using AddsSystem.DAL.Repositories;
    using AddsSystem.Models.EntityModels;
    using Telerik.JustMock;

    public class JustMockUserPostRepository : UserPostRepositoryMock, IUserPostRepositoryMock
    {
        protected override void ArrangeUserPostRepositoryMock()
        {
            this.userData = Mock.Create<IGenericRepository<UserPost>>();
            Mock.Arrange(() => this.userData.Add(Arg.IsAny<UserPost>())).DoNothing();
            Mock.Arrange(() => this.userData.GetAll()).Returns(this.FakeUserPostCollection);
            Mock.Arrange(() => this.userData.GetById(Arg.AnyInt)).Returns(this.FakeUserPostCollection.First());
        }
    }   
}
