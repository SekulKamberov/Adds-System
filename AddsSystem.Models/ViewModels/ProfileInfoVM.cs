namespace AddsSystem.Models.ViewModels
{
    using System.Collections.Generic;
    using AddsSystem.Models.EntityModels;

    public class ProfileInfoVM
    {
        public User UserInfo { get; set; }

        public UserPost UserPost { get; set; }

        public string ReturnUrl { get; set; }

        public IEnumerable<UserPost> AllUserPosts { get; set; }

        public IEnumerable<PostImage> PostImages { get; set; }
    }
}