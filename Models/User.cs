using System;
using Microsoft.AspNetCore.Identity;

//class is handled by haashim 
namespace hashmemes.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public List<Post> Posts { get; set; }
        public List<UserGroup> UserGroup { get; set; }

    }
}