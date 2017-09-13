namespace AddsSystem.Services
{
    using System;
    using System.IO;
    using System.Net;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Contracts;
    using DAL.Contracts;
    using DAL.Repositories;
    using Models.EntityModels;
    using Models.ViewModels;
    using System.Linq;
    using System.Web;
    using AddsSystem.Common.Constants;

    public class PostService : Controller, IPostService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<UserPost> userPosts;
        private readonly IGenericRepository<PostImage> postImages;
        private readonly IGenericRepository<User> applicationUser;

        public PostService (IUnitOfWork unitOfWork, IGenericRepository<UserPost> userPosts,
            IGenericRepository<PostImage> postImages, IGenericRepository<User> applicationUser)
        {
            this.unitOfWork = unitOfWork;
            this.userPosts = userPosts;
            this.postImages = postImages;
            this.applicationUser = applicationUser;
        }
     
        public IQueryable<UserPost> AllPosts()
        {
            var alladds = userPosts.Include(c => c.PostImages).OrderByDescending(c => c.UserId).AsQueryable();
            return alladds;
        }

        public ProfileInfoVM UserAllPosts(string userid)
        {   
            var userInfo = applicationUser.GetAll(s => s.Id == userid).First();
            var allUserPosts = userPosts.Include(c => c.PostImages).Where(s => s.UserId == userid).ToList();

            ProfileInfoVM profileInfo = new ProfileInfoVM();
            {
                profileInfo.UserInfo = userInfo;
                profileInfo.AllUserPosts = allUserPosts;
            }
            return profileInfo;
        }

        public IQueryable<UserPost> ContentId(int Id, string userid)
        {
            var model = userPosts.Include(c => c.PostImages).Where(s => s.UserId == userid).Where(s => s.UserPostId == Id);
            return model;
        }

        public IQueryable<UserPost> Content(int Id)
        {
            var model = userPosts.Include(c => c.PostImages).Where(s => s.UserPostId == Id);
            return model;
        }

        public void CreateUserPost(UserPost UserPost, string userid, HttpServerUtilityBase server, HttpRequestBase filesRequest)
        {
            List<PostImage> postImages = new List<PostImage>();
            for (int i = 0; i < filesRequest.Files.Count; i++)
            {
                var file = filesRequest.Files[i];
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    PostImage postImage = new PostImage()
                    {
                        FileName = fileName,
                        Extension = Path.GetExtension(fileName),
                        Id = Guid.NewGuid()
                    };
                    postImages.Add(postImage);
                    var path = Path.Combine(server.MapPath(Infrastructure.FolderPath), postImage.Id + postImage.Extension);
                    file.SaveAs(path);
                }
            }
            UserPost.UserId = userid;
            UserPost.PostImages = postImages;
            userPosts.Add(UserPost);         
            using (unitOfWork)
            {
                unitOfWork.Commit();
            }
        }

        public IQueryable<UserPost> EditById(int id)
        {
            var userpost = userPosts.Include(c => c.PostImages).Where(s => s.UserPostId == id);
            if (userpost == null)
            {
                throw new ArgumentException("Userpost is Null");
            }
            return userpost;
        }

        public void EditToPost(UserPost userpost, string userid, HttpServerUtilityBase server, HttpRequestBase filesRequest)
        {
                List<PostImage> postimages = new List<PostImage>();
                for (int i = 0; i < filesRequest.Files.Count; i++)
                {
                    var file = filesRequest.Files[i];
                    var fileName = Path.GetFileName(file.FileName);
                    if (fileName.Length > 1)
                    {
                        PostImage postImage = new PostImage()
                        {
                            FileName = fileName,
                            Extension = Path.GetExtension(fileName),
                            Id = Guid.NewGuid(),
                            UserPostId = userpost.UserPostId
                        };
                        var path = Path.Combine(server.MapPath(Infrastructure.FolderPath), postImage.Id + postImage.Extension);
                        file.SaveAs(path);
                        postImages.Add(postImage);
                        postimages.Add(postImage);
                    }
                }
                userpost.UserId = userid;
                userpost.PostImages = postimages;
                userPosts.Update(userpost);
                using (unitOfWork)
                {
                    unitOfWork.Commit();
                }
        }

        public JsonResult DeleteFileByStringId(string id, HttpServerUtilityBase server)
        {
            if (String.IsNullOrEmpty(id))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                Guid guid = new Guid(id);
                PostImage postImage = postImages.GetById(guid);

                if (postImage == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return Json(new { Result = "Error" });
                }

                postImages.Delete(postImage);

                using (unitOfWork)
                {
                    unitOfWork.Commit();
                }

                var path = Path.Combine(server.MapPath(Infrastructure.FolderPath), postImage.Id + postImage.Extension);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                return Json(new { Result = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        public void Delete(int id, HttpServerUtilityBase server)
        {
            try
            {
                UserPost userpost = userPosts.GetById(id);
                if (userpost == null)
                {
                    throw new ArgumentNullException("Please choose a post to delete");
                }
                foreach (var item in userpost.PostImages)
                {
                    String path = Path.Combine(server.MapPath(Infrastructure.FolderPath), item.Id + item.Extension);

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }
                userPosts.Delete(userpost);
                using (unitOfWork)
                {
                    unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("Please choose a post to delete, there is un exaption: ", ex);
            }
        }

    }
}