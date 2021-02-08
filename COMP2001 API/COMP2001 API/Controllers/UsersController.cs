using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using COMP2001_API.Models;

namespace COMP2001_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly COMP2001_JKhanContext _context;

        public UsersController(COMP2001_JKhanContext context)
        {
            _context = context;
        }



        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet]
        public IActionResult Validate(User user, int id)
        {
            bool boolResult = getValidation(user, id);

            Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
            dictionary.Add("verfied", boolResult);

            JsonResult result = new JsonResult(dictionary);

            return Ok(result);
        }

        private bool getValidation(User user, int id)
        {
            bool tempResult = _context.Validate(user, id);
            return tempResult;
        }

        public IActionResult Register(User user)
        {
            string ResponseMessage = "";

            register(user, out ResponseMessage);

            Dictionary<string, string> values = new Dictionary<string, string>();

            if (ResponseMessage == "208")
            {
                values.Add("Call successful, but user id already exists", ResponseMessage);
                JsonResult result = new JsonResult(values);

                return StatusCode(208);
            }
            else if (ResponseMessage == "404")
            {
                values.Add("Bad request", ResponseMessage);
                JsonResult result = new JsonResult(values);

                return NoContent();
            }
            else
            {
                values.Add("UserID", ResponseMessage);
                JsonResult result = new JsonResult(values);

                return Ok(result);
            }

        }

        private void register(User user, out string message)
        {
            _context.Register(user, out message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            _context.Update(user, id);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _context.Delete(id);

            return NoContent();
        }

        
        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
