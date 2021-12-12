using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hashmemes.Models;
using hashmemes.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

/*
Controller made by Adnan Joraid 
This controller will allow users to create and join groups 
contains 
- POST for creating group 
- GET for getting groups content
- DELETE for delete a member from group 
- POST for adding member to group 
- POST for adding a meme post to the group 
*/
namespace hashmemes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {

        private readonly DataContext _context;
        public GroupsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] Group groupDetail)
        {
            /*
            Summary: Method receives groupDetail which contains group name and creator (currentMember)
            Arguments: Group object
            Return: Http Request
            */
            var doesGroupExist = _context.Groups.Where(x => x.GroupName.Equals(groupDetail.GroupName));

            if (doesGroupExist != null)
            {
                return BadRequest("Group already exist");
            }

            if (groupDetail.GroupName.Equals(null))
            {
                return BadRequest("Group name should not be null");
            }

            await _context.Groups.AddAsync(groupDetail);


            return Ok($"Group Created. Group Owner is {groupDetail.CurrentOwner}");
        }

        [HttpGet("{id}")]
        public IActionResult GetGroupContent([FromBody] string groupId)
        {
            /*
            Summary: Method receives group id to return the content
            Arguments: Group ID
            Return: Http Request with List<Posts> from Group class
            */
            if (groupId == null)
            {
                return BadRequest("Group ID cannot be null");
            }

            var currentPosts = _context.Groups.Include(x => x.Posts).Where(x => x.Id.Equals(new Guid(groupId)));
            if (currentPosts == null)
            {
                return BadRequest("No availabe posts");
            }


            return Ok(currentPosts);
        }


    }
}