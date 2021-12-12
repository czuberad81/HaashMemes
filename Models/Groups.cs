using System;
using System.Collections.Generic;

namespace hashmemes.Models
{
    public class Group
    {
        public Guid Id { get; set; }
        public List<User> Members { get; set; }

        public User CurrentOwner { get; set; }

        public string GroupName { get; set; }

        public List<Post> Posts { get; set; }


        public bool IsCurrentOwner(string userName)
        {
            return userName.Equals(CurrentOwner.UserName);
        }
    }
}