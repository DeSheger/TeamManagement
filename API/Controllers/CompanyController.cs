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
            var result = await _context.Companies.ToListAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var result = _context.Companies.Where(company => company.Id == id).FirstOrDefault();

            return result;
        }

        //[HttpPost]
        //public async Task<ActionResult>
    }
}