using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class UserController : BaseController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUsersList()
        {
            var user = await _context.Users
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var User = await _context.Users
                .FindAsync(id);

            var UserDTO = _mapper.Map<UserDTO>(User);

            return UserDTO;
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