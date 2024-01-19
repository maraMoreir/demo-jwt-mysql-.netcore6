using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Demo.Jwt.MySql.Models;

namespace Demo.Jwt.MySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly List<User>? _users; // Simulação de um repositório de usuários


        // GET: api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _users.ToList();
        }

        // GET: api/user/1
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/user
        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            user.Id = _users.Max(u => u.Id) + 1;
            _users.Add(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT: api/user/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, User updatedUser)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;

            return NoContent();
        }

        // DELETE: api/user/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _users.Remove(user);

            return NoContent();
        }
    }
}
