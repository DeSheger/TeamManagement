using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Companies;
using Application.DTOs;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class CompanyController : BaseController
    {

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
        public async Task<ActionResult> EditCompany(Company updatedCompany)
        {
            return Ok(await Mediator.Send(new Edit.Command{EditedCompany = updatedCompany}));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            return Ok(await Mediator.Send(new Delete.Command(id)));
        }
    }
}
