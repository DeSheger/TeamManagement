using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Groups;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class GroupController : BaseController
    {
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

        [HttpPost]
        public async Task<ActionResult> CreateGroup(GroupDTO group)
        {
            return Ok(await Mediator.Send(new Create.Command{Group = group}));
        }

        [HttpPatch]
        public async Task<ActionResult> EditGroup(Group group)
        {
            return Ok(await Mediator.Send(new Edit.Command{EditedGroup = group}));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGroup(int id)
        {
            return Ok(await Mediator.Send(new Delete.Command(id)));
        }
    }
}

