namespace AddsSystem.Models.ViewModels
{
    using System.Collections.Generic;
    using AutoMapper;
    using AddsSystem.Models.EntityModels;
    using System.ComponentModel.DataAnnotations;

    public class AllProfilesVM
    {
        public string UserId { get; set; }

        public int UserPostId { get; set; }

        [Required(ErrorMessage = "Please Enter Your Title")]
        [Display(Name = "Title")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter your Summary")]
        [Display(Name = "Info")]
        [MaxLength(500)]
        public string Info { get; set; }

        public PostImage PostImage { get; set; }

        public virtual ICollection<PostImage> PostImages { get; set; }
    }
}
