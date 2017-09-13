namespace AddsSystem.Models.ViewModels
{
    using AddsSystem.Models.EntityModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserPostVM 
    {
        public int UserPostId { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        [Display(Name = "Title")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter Summary")]
        [Display(Name = "Info")]
        [MaxLength(500)]
        public string Info { get; set; }

        public PostImage PostImage { get; set; }

        public virtual ICollection<PostImage> PostImages { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual User MainUserId { get; set; }
    }
}