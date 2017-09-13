using System;
using System.Collections.Generic;
using System.Linq;
namespace AddsSystem.Models.EntityModels
{
    public class PostImage
    {
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public string Extension { get; set; }

        public int UserPostId { get; set; }

    }
}