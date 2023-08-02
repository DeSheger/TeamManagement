using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class GroupController : BaseController
    {
        private readonly DataContext _context;
        public GroupController(DataContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<Group>>> GetGroupsList()
        {
            var result = await _context.Groups
            .Include(x => x.Leader)
            .Include(x => x.Members).ToListAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(int id)
        {
            var result = await _context.Groups.FindAsync(id);

            return result;
        }

        [HttpPost]
        public async Task<ActionResult> CreateGroup(Group group)
        {
            User leader = await _context.Users.FindAsync(group.Leader.Id);
            Company company = await _context.Companies.FindAsync(group.Company.Id);

            var result = new Group()
            {
                Name = group.Name,
                Description = group.Description,
                Company = company,
                Leader = leader,
                Members = group.Members
            };

            _context.Groups.Add(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch]
        public async Task<ActionResult> EditGroup(Group group)
        {
            var existGroup = await _context.Groups.FindAsync(group.Id);
            var existCompany = await _context.Companies.FindAsync(group.Company.Id);
            var existLeader = await _context.Users.FindAsync(group.Leader.Id);

            existGroup.Name = group.Name;
            existGroup.Description = group.Description;
            existGroup.Company = existCompany;
            existGroup.Leader = existLeader;
            existGroup.Members = group.Members;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var result = await _context.Groups.FindAsync(id);
            _context.Groups.Remove(result);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

//[HttpPost]
