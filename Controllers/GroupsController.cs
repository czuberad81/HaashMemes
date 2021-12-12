using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hashmemes.Persistence;
using Microsoft.AspNetCore.Mvc;
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


    }
}