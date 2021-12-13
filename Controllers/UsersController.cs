using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hashmemes.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace hashmemes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] User user)
        {
            if (user.Name == null)
            {
                return BadRequest("name is null");
            }
            else if (_context.Users.FirstOrDefault(x => x.UserName.Equals(user.UserName)) != null)
            {
                return BadRequest("User aleady exists");
            }
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserWithId(string id)
        {
            User currentUser = _context.Users.Find(new Guid(id));

            if (currentUser != null)
            {
                _context.RemoveRange(_context.Users.Where(x => x.Id.Equals(new Guid(id))).Include(x => x.UserName));
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }


    }
}
