namespace AddsSystem.Models.ViewModels
{
    using AddsSystem.Models.EntityModels;
    using System.Collections.Generic;

    public class EditByIdVM
    {
        public int UserPostId { get; set; }

        public string Title { get; set; }

        public string Info { get; set; }

        public PostImage PostImage { get; set; }

        public virtual ICollection<PostImage> PostImages { get; set; }
    }
}
