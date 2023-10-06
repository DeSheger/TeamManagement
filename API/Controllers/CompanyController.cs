using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Companies;
using Application.DTOs;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly DataContext _context;

        public CompanyController(IAuthorizationService authorizationService, DataContext context) 
        {
            _authorizationService = authorizationService;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyDTO>>> GetACompanyList()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> GetCompany(int id)
        {
            return await Mediator.Send(new Detail.Query(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompany(CompanyDTO company)
        {
            return Ok(await Mediator.Send(new Create.Command{CompanyDTO = company}));
        }

        [HttpPatch]
        public async Task<ActionResult> EditCompany(CompanyDTO updatedCompany)
        {
            Company companyInDb = await _context.Companies
                .Include(c => c.Leader)
                .FirstAsync(c=>c.Id == updatedCompany.Id);

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, companyInDb, "IsLeader");

            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            return Ok(await Mediator.Send(new Edit.Command{EditedCompany = updatedCompany}));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            return Ok(await Mediator.Send(new Delete.Command(id)));
        }
    }
}
