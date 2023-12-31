using API.Services;
using Application.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Microsoft.AspNetCore.Authorization;
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
        private readonly TokenService _tokenService;
        public UserController(DataContext context, 
        IMapper mapper, UserManager<User> userManager, TokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<SessionDto>> Login(LoginDto user)
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
                SessionDto Session = _mapper.Map<SessionDto>(LoggedUser);
                Session.Token = _tokenService.CreateToken(LoggedUser);

                return Session;

            } else return Unauthorized();
        }
        
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> CreateUser(RegisterDto user)
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
        public async Task<ActionResult<List<UserDto>>> GetUsersList()
        {
            var user = await _context.Users
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var User = await _context.Users
                .FindAsync(id);

            var UserDTO = _mapper.Map<UserDto>(User);

            return UserDTO;
        }

        [HttpPatch]
        public async Task<ActionResult> EditUser(RegisterDto user)
        {
            var EditUser = await _context.Users.FindAsync(user.Id);
            EditUser.Name = user.Name;
            EditUser.Email = user.Email;
            EditUser.Surrname = user.Surrname;

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