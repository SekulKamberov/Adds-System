namespace AddsSystem.Services.Contracts
{
    using Models.EntityModels;
    using Models.ViewModels;
    using Models.BindModels;
    using System.Web.Mvc;
    using System.Web;
    using System.Collections.Generic;
    using System.Linq;

    public interface IPostService
    {
        IQueryable<UserPost> AllPosts();

        ProfileInfoVM UserAllPosts(string userid);

        IQueryable<UserPost> ContentId(int Id, string userid);

        IQueryable<UserPost> Content(int Id);

        //string UserCheck(string userid);

        void CreateUserPost(UserPost UserPost, string userid, HttpServerUtilityBase  server, HttpRequestBase filesRequest);

        IQueryable<UserPost> EditById(int id);

        void EditToPost(UserPost userpost, string userid, HttpServerUtilityBase server, HttpRequestBase filesRequest);

        //FileResult DownLoad(string p, string d);

        JsonResult DeleteFileByStringId(string id, HttpServerUtilityBase server);

        void Delete(int id, HttpServerUtilityBase server);

        //FileContentResult UserPhotos(HttpServerUtilityBase server);
    }
}
