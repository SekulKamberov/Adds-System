namespace AddsSystem.Models.ViewModels
{
    using AddsSystem.Models.EntityModels;
    using System.Collections.Generic;

    public class ContentIdVM
    {
        public int UserPostId { get; set; }

        public string Title { get; set; }

        public string Info { get; set; }

        public IEnumerable<PostImage> PostImages { get; set; }
    }
}
