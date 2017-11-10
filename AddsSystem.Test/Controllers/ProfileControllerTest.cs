namespace AddsSystem.Test.Controllers
{
    using System;
    using System.Web.Mvc;
    using AddsSystem.Services.Contracts;
    using AddsSystem.Client.Controllers;
    using AddsSystem.Models.EntityModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using AddsSystem.Test.Mocks;
    using DAL.Repositories;
    using Moq;
    using AddsSystem.DAL.Contracts;

    [TestClass]
    public class ProfileControllerTest 
    {
        private IGenericRepository<UserPost> profileData;
        private readonly IPostService postsData;
        private ProfileController controller;

        public ProfileControllerTest()
            : this(new MoqUserPostRepository())
        {
        }

        public ProfileControllerTest(IUserPostRepositoryMock userData)
        {
            this.profileData = userData.userData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new ProfileController(this.postsData);
        }

        [TestMethod]
        public void ShouldReturnAllUserPosts()
        {
            var model = (ICollection<UserPost>)this.GetModel(() => (Test.Mocks.IView)this.controller.All());
            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingUserPostShouldThrowArgumentNullExceptionIfUserPostIsNull()
        {
            var model = (UserPost)this.GetModel(() => (Test.Mocks.IView)this.controller.Create(null));
        }

        //Auto get view.Model
        private object GetModel(Func<Test.Mocks.IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
