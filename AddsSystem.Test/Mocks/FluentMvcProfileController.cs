namespace AddsSystem.Test.Mocks
{
    using AddsSystem.Client.Controllers;
    using AddsSystem.Models.EntityModels;
    using AddsSystem.Models.ViewModels;
    using AddsSystem.Services.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Net;
    using TestStack.FluentMVCTesting;

    [TestClass]
    public class FluentMvcProfileController
    {
        private readonly IPostService postsData;
        private ProfileController controller;

        public FluentMvcProfileController(IPostService posts)
        {
            postsData = posts;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new ProfileController(this.postsData);
        }

        [TestMethod]
        public void IndexShouldPass()
        {
            controller.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView()
                .WithModel<List<ProfileInfoVM>>();
        }

        [TestMethod]
        public void DetailsNullParameterBadRequest()
        {
            controller.WithCallTo(c => c.ContentId(0))
                .ShouldGiveHttpStatus(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void DetailsInvalidIdNotFound()
        {
            controller.WithCallTo(c => c.ContentId(-1))
                .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void CreateGetMethod()
        {
            controller.WithCallTo(c => c.Create())
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void CreatePostMethod()
        {
            controller.WithCallTo(c => c.Create(new UserPost()
            {
                Title = "Simple Bug",
                Info = "Blia blia blia",
                UserId = "Somestringuserid"
            }))
                .ShouldRedirectTo(c => c.Index());
        }
    }
}
