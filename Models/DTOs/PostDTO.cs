using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaashMemes.Models.DTOs
{
    public class PostDTO
    {
        public Guid Id{get;set;}
        public string PostCaption { get; set; }
        public DateTime PostDate { get; set; }
        public List<string> comments { get; set; }
    }
}