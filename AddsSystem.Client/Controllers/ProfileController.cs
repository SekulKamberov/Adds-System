namespace AddsSystem.Client.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.IO;
    using System.Linq;
    using System.Net.Mime;
    using Microsoft.AspNet.Identity;
    using AutoMapper.QueryableExtensions;
    using AddsSystem.Common.Constants;
    using AddsSystem.Services.Contracts;
    using AddsSystem.Models.ViewModels;
    using AddsSystem.Models.EntityModels;

    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly IPostService postsData;

        public ProfileController(IPostService posts)
        {
            postsData = posts;
        } 

        public ActionResult Index()
        {
            string userid = User.Identity.GetUserId();
            var userPosts = postsData.UserAllPosts(userid); 
            return View(userPosts);
        }

        [OutputCache(CacheProfile = "ShortLived")]
        public ActionResult All()
        {
            var profilePosts = postsData.AllPosts().ProjectTo<AllProfilesVM>().OrderByDescending(c => c.UserPostId).ToList();
            return View(profilePosts); 
        }

        public ActionResult ContentById(int Id)
        {
            string userid = User.Identity.GetUserId();
            var content = postsData.ContentId(Id, userid).ProjectTo<ContentIdVM>().FirstOrDefault();
            return PartialView(Partials.UserAdId, content);
        }

        public ActionResult ContentId(int Id)
        {
            string MyUserId = User.Identity.GetUserId();
            ViewBag.MyUserId = MyUserId;
            var content = postsData.Content(Id).ProjectTo<AllProfilesVM>().FirstOrDefault();         
            return PartialView(Partials.ContentAdId, content);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserPost UserPost)
        {
            if (UserPost == null)
            {
                throw new ArgumentNullException("It's need all info about user post");
            }
            var filesRequest = Request;
            var server = Server;
            string userid = User.Identity.GetUserId();
            postsData.CreateUserPost(UserPost, userid, server, filesRequest);
            return RedirectToAction(Views.Index);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {          
            var userpost = postsData.EditById(id).ProjectTo<EditByIdVM>().FirstOrDefault();
            return View(userpost);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserPost userpost)
        {
            string userid = User.Identity.GetUserId();
            var filesRequest = Request;
            var server = Server;
            postsData.EditToPost(userpost, userid, server, filesRequest);
            return RedirectToAction(Views.Index);
        }

        public FileResult DownLoad(string p, string d)
        {
            return File(Path.Combine(Server.MapPath(Infrastructure.FolderPath), p), MediaTypeNames.Application.Octet, d);
        }

        [HttpPost]
        public JsonResult DeleteFile(string id)
        {
            var server = Server;         
            return postsData.DeleteFileByStringId(id, server);
        }

        [Authorize]
        public ActionResult Delete(int id)  
        {
            var server = Server;
            postsData.Delete(id, server);
            return RedirectToAction(Views.Index);
        }
    }
}