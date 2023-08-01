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
            var result = await _context.Companies.Include(x => x.Leader).Include(x => x.Members).ToListAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var result = await _context.Companies.FindAsync(id);

            return result;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompany(Company company)
        {
            User leader = await _context.Users.FindAsync(company.Leader.Id);

            var result = new Company()
            {
                Name = company.Name,
                Description = company.Description,
                Leader = leader,
                Members = company.Members
            };

            _context.Companies.Add(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> EditCompany(Company company, int id)
        {
            var existCompany = await _context.Companies.FindAsync(id);
            var existLeader = await _context.Users.FindAsync(company.Leader.Id);

            existCompany.Name = company.Name;
            existCompany.Description = company.Description;
            existCompany.Leader = existLeader;
            existCompany.Members = company.Members;

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

//[HttpPost]
