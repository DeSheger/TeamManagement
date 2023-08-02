using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class UserController : BaseController
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsersList()
        {
            var result = await _context.Users
                .Include(u => u.CompaniesLeader)
                .Include(u => u.CompaniesMember)
                .ToListAsync();
            
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var result = await _context.Users
                .FindAsync(id);
            
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            var newUser = new User()
            {
                Name = user.Name,
                Surrname = user.Surrname,
            };

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch]
        public async Task<ActionResult> EditUser(User user)
        {
            var editedUser = await _context.Users.FindAsync(user.Id);

            editedUser.Name = user.Name;
            editedUser.Surrname = user.Surrname;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var result = await _context.Users.FindAsync(id);
            _context.Users.Remove(result);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}