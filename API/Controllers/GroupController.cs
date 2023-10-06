using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Groups;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class GroupController : BaseController
    {
        private readonly DataContext _context;
        private readonly IAuthorizationService _authorization;

        public GroupController(DataContext context, IAuthorizationService authorization)
        {
            _context = context;
            _authorization = authorization;
        }


        [HttpGet]
        public async Task<ActionResult<List<GroupDTO>>> GetGroupsList()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDTO>> GetGroup(int id)
        {
            return await Mediator.Send(new Detail.Query(id));
        }

        [HttpGet("companyGroups/{id}")]
        public async Task<ActionResult<List<GroupDTO>>> GetCompanyGroups(int id)
        {
            return await Mediator.Send(new CompanyGroups.Query(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateGroup(GroupDTO group)
        {
            return Ok(await Mediator.Send(new Create.Command{Group = group}));
        }

        [HttpPatch]
        public async Task<ActionResult> EditGroup(GroupDTO group)
        {
            Group groupInDb = await _context.Groups.Include(g=>g.Leader).FirstAsync(g => g.Id == group.Id);

            var isUserAuthenticated = await _authorization.AuthorizeAsync(User, groupInDb, "IsLeaderInGroup");

            if(!isUserAuthenticated.Succeeded)
            {
                return Forbid();
            }

            return Ok(await Mediator.Send(new Edit.Command{EditedGroup = group}));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGroup(int id)
        {
            Group groupInDb = await _context.Groups.Include(g => g.Leader).FirstAsync(g => g.Id == id);

            var isUserAuthenticated = await _authorization.AuthorizeAsync(User, groupInDb, "IsLeaderInGroup");

            if (!isUserAuthenticated.Succeeded)
            {
                return Forbid();
            }

            return Ok(await Mediator.Send(new Delete.Command(id)));
        }
    }
}

