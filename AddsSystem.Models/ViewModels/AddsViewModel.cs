namespace AddsSystem.Models.ViewModels
{
    using System.Collections.Generic;
    using AddsSystem.Models.EntityModels;
    using AutoMapper.Configuration;

    public class AddsViewModel //: IMapFrom<UserPost>, IHaveCustomMappings
    {
        //public static Expression<Func<UserPost, AddsViewModel>> FromAdd
        //{
        //    get
        //    {
        //        return add => new AddsViewModel
        //        {
        //            Id = add.UserPostId,
        //            UserId = add.UserId,
        //            Title = add.Title,
        //            Info = add.Info,
        //            Images = add.PostImages,
        //        };
        //    }
        //}

        public int Id { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string Info { get; set; }

        public ICollection<PostImage> Images { get; set; }

        //public void CreateMappings(IConfiguration config)
        //{
        //    config.CreateMap<UserPost, AddsViewModel>()
        //        .ForMember(s => s.TotalUsers, opts => opts.MapFrom(s => s.Users.Count()));
        //}
    }
}