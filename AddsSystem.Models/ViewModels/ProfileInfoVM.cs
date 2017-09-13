namespace AddsSystem.Models.ViewModels
{
    using System.Collections.Generic;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using AddsSystem.Models.EntityModels;

    public class ProfileInfoVM
    {
        //public static Expression<Func<UserPost, ProfileInfoVM>> FromUserPost
        //{
        //    get
        //    {
        //        return UserPost => new ProfileInfoVM
        //        {
        //            UserInfo = UserPost.ApplicationUser,
        //            UserPost = UserPost,
        //            PostImages = UserPost.PostImages,

        //        };
        //    }
        //}

        public User UserInfo { get; set; }

        //public ApplicationUser User { get; set; }

        public UserPost UserPost { get; set; }

        public string ReturnUrl { get; set; }

        public IEnumerable<UserPost> AllUserPosts { get; set; }

        public IEnumerable<PostImage> PostImages { get; set; }

    }
}