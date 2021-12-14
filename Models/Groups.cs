using System;
using System.Collections.Generic;

namespace hashmemes.Models
{
    public class Group
    {
        public Guid Id { get; set; }
        public List<User> Members { get; set; }

        public string GroupName { get; set; }

        public List<Post> Posts { get; set; }



    }
}