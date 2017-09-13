namespace AddsSystem.Models.BindModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using EntityModels;

    public class CreateUserPostBM
    {
        [Required(ErrorMessage = "Please Enter Your Name")]
        [Display(Name = "Title")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter Summary")]
        [Display(Name = "Info")]
        [MaxLength(500)]
        public string Info { get; set; }

        // public PostImage PostImage { get; set; }

        public ICollection<PostImage> PostImages { get; set; }

        public string FileName { get; set; }

        public string Extension { get; set; }

        public string UserId { get; set; }

        // public int UserPostId { get; set; }
    }
}