using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

//class is handled by haashim 
namespace hashmemes.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public List<Post> Posts { get; set; }


    }
}
