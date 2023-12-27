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
        public async Task<ActionResult<List<CompanyDto>>> GetACompanyList()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(int id)
        {
            return await Mediator.Send(new Detail.Query(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompany(CompanyDto company)
        {
            return Ok(await Mediator.Send(new Create.Command{CompanyDto = company}));
        }

        [HttpPatch]
        public async Task<ActionResult> EditCompany(CompanyDto updatedCompany)
        {
            Company companyInDb = await _context.Companies
                .Include(c => c.Leader)
                .FirstAsync(c=>c.Id == updatedCompany.Id);

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, companyInDb, "IsLeaderInCompany");

            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            return Ok(await Mediator.Send(new Edit.Command{EditedCompany = updatedCompany}));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            Company companyInDb = await _context.Companies
                .Include(c => c.Leader)
                .FirstAsync(c => c.Id == id);

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, companyInDb, "IsLeaderInCompany");

            if (!authorizationResult.Succeeded)
            {
                return Forbid();
            }

            return Ok(await Mediator.Send(new Delete.Command(id)));
        }
    }
}
