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
            Summary: Method responsible for creating groups
            Arguments: Group object
            Return: Http Request
            */
            var doesGroupExist = _context.Groups.FirstOrDefault(x => x.GroupName.Contains(groupDetail.GroupName));

            if (doesGroupExist != null)
            {
                return BadRequest("Group already exist");
            }

            if (groupDetail.GroupName.Equals(null))
            {
                return BadRequest("Group name should not be null");
            }



            _context.Groups.Add(groupDetail);
            await _context.SaveChangesAsync();

            return Ok($"Group Created");
        }

        [HttpGet("{id}")]
        public IActionResult GetGroupContent([FromBody] string groupId)
        {
            /*
            Summary: Method that returns all group contents
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

        [HttpPost("addToGroup/{id}")]
        public async Task<IActionResult> AddUserToGroup([FromBody] User user, string id)
        {
            /*
            Summary: Method that adds a specific user to a group 
            Arguments: Group ID and User
            Return: Http Request with code
            */
            if (id == null || user == null)
            {
                return BadRequest();
            }
            if (user.UserName == null)
            {
                return BadRequest();
            }
            var doesGroupExist = _context.Groups.Where(x => x.Id.Equals(new Guid(id)));
            if (doesGroupExist == null)
            {
                return BadRequest("Group does not exist");
            }
            var doesUserExist = _context.Users.Where(x => x.Id.Equals((user.Id)));
            if (doesUserExist == null)
            {
                return BadRequest("user cannot be null");
            }
            var getGroup = await _context.Groups.SingleOrDefaultAsync(x => x.Id.Equals(new Guid(id)));
            var getUser = _context.Users.SingleOrDefault(x => x.Id.Equals(user.Id));
            getGroup.Members.Add(getUser);


            return Ok("User added to group");
        }

        [HttpGet]
        public IActionResult GetAllGroups()
        {
            /*
           Summary: Method that returns all group objects in database to be later displayed to user when they
           want to join a group.  
           Arguments: NONE
           Return: Http Request with the groups returned from database. 
           */
            return Ok(_context.Groups.Include(x => x.Members).Include(x => x.Posts).Include(x => x.Posts));
        }


    }
}