using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaashMemes.Models;
using HaashMemes.Models.DTOs;
using hashmemes.Models;
using hashmemes.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

/*
Controller made by Adam Czubernat
Controller handles all necessary functionality with posts including:
- POST adding post to user
*/
namespace HaashMemes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly DataContext _context;

        public PostController(DataContext context){
            _context = context;
        }

        /*
        Summary: adding post to specified user
        Arguements: Post object, string id
        Return: Http Request
        */
        [HttpPost("{id}/post")]
        public async Task<IActionResult> AddImage(string id,[FromBody] Post post)
        {
            if(post == null)
                return BadRequest("No post given");
            
            var user = await _context.Users.Include(x=>x.Posts).ThenInclude(x=>x.CommentList).SingleOrDefaultAsync(x=>x.Id.Equals(new Guid(id)));
        
            if(user == null){
                return BadRequest("User does not exist");
            }

            user.Posts.Add(post);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("{id}/comment")]
        public async Task<IActionResult> Post(string id,[FromBody] Comment comment)
        {
            if(comment == null)
                return BadRequest("No post given");
            
            var post = await _context.Posts.SingleOrDefaultAsync(x=>x.Id.Equals(new Guid(id)));

            if(post == null){
                return BadRequest("Post does not exist");
            }

            comment.CommentDate = DateTime.Now;
            post.CommentList.Add(comment);
            
            // var postTemp = new PostDTO{
            //     Id = post.Id,
            //     PostCaption = post.PostCaption,
            //     PostDate = post.PostDate,
            //     comments = post.CommentList.Select(x=>x.Text).OfType<string>().ToList()
            // };
            return Ok(post);
        }





    }
}