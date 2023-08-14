using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class UserController : BaseController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public UserController(DataContext context, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost("login")]
        public async Task<ActionResult<SessionDTO>> Login(LoginDTO user)
        {
            var LoggedUser = await _userManager.Users
            .Where(x => x.Email == user.Email)
            .FirstOrDefaultAsync();

            if (LoggedUser == null)
            {
                return Unauthorized();
            }
            var result = await _userManager.CheckPasswordAsync(LoggedUser, user.Password);

            if(result)
            {
                SessionDTO Session = _mapper.Map<SessionDTO>(LoggedUser);

                return Session;

            } else return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<ActionResult> CreateUser(RegisterDTO user)
        {
            User NewUser = new ()
            {
                Name = user.Name,
                Surrname = user.Surrname,
                Email = user.Email
            };

            await _userManager.CreateAsync(NewUser, user.Password);

            await _context.Users.AddAsync(NewUser);
            await _context.SaveChangesAsync();

            return Ok();
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

        [HttpPatch]
        public async Task<ActionResult> EditUser(RegisterDTO user)
        {
            var EditUser = await _userManager.FindByIdAsync(user.Id.ToString());
            EditUser.Name = user.Name;
            EditUser.Email = user.Email;
            EditUser.Surrname = user.Surrname;

            var token = await _userManager.GeneratePasswordResetTokenAsync(EditUser);
            var result = await _userManager.ResetPasswordAsync(EditUser, token, user.Password);

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