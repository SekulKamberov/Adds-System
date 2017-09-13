namespace AddsSystem.Models.BindModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using ViewModels;
    using EntityModels;
    using System.ComponentModel.DataAnnotations;

    public class UserPostBM
    {
        //public int UserPostId { get; set; }

        //public string Title { get; set; }

        //public string Info { get; set; }

        //public PostImageVM PostImage { get; set; }

        //public ICollection<PostImageVM> PostImages { get; set; }

        public int UserPostId { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        [Display(Name = "Title")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter Summary")]
        [Display(Name = "Info")]
        [MaxLength(500)]
        public string Info { get; set; }

        public virtual PostImageVM PostImage { get; set; }

        public virtual ICollection<PostImageVM> PostImages { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual User MainUserId { get; set; }
    }
}