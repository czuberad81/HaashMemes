using System;
using System.Collections.Generic;
using HaashMemes.Models;

namespace hashmemes.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string PostCaption { get; set; }
        public DateTime PostDate { get; set; }
        public List<Comment> CommentList { get; set; }



    }
}