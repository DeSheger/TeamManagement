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
    public class CompanyController : BaseController
    {
        private readonly DataContext _context;
        public CompanyController(DataContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetACompanyList()
        {
            var result = await _context.Companies
            .Include(x => x.Leader)
            .Include(x => x.Members).ToListAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var result = await _context.Companies
            .Include(x => x.Leader)
            .Include(x => x.Members).FirstOrDefaultAsync(c => c.Id == id);
            

            return result;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompany(Company company)
        {
            User leader = await _context.Users.FindAsync(company.Leader.Id);

            var existMembers = new List<User>(){};

            foreach(var member in company.Members)
            {
                existMembers.Add( _context.Users.Find(member.Id));
            }

            var result = new Company()
            {
                Name = company.Name,
                Description = company.Description,
                Leader = leader,
                Members = existMembers
            };

            _context.Companies.Add(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> EditCompany(Company updatedCompany)
        {
            var existCompany = await _context.Companies
                .Include(c => c.Members)
                .FirstOrDefaultAsync(c => c.Id == updatedCompany.Id);
            
            if(existCompany == null)
            {
                return NotFound();
            }

            var existLeader = await _context.Users.FindAsync(updatedCompany.Leader.Id);
            var existMembers = new List<User>(){};

            foreach(var member in updatedCompany.Members)
            {
                existMembers.Add( _context.Users.Find(member.Id));
            }

            existCompany.Name = updatedCompany.Name;
            existCompany.Description = updatedCompany.Description;
            existCompany.Leader = existLeader;
            existCompany.Members = existMembers;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var result = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(result);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
