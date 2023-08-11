using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
using Application.Activities;
using Application.DTOs;

namespace API.Controllers
{
    public class ActivityController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<ActivityDTO>>> GetActivitiesList()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("activitiesForUser/{userId}")]
        public async Task<ActionResult<List<Activity>>> GetActivitiesForUser(int userId)
        {
            return await Mediator.Send(new UserToDo.Query(userId));
        }

        [HttpGet("activitiesByUser/{userId}")]
        public async Task<ActionResult<List<Activity>>> GetActivitiesByUser(int userId)
        {
            return await Mediator.Send(new UserAuthor.Query(userId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(int id)
        {
            return await Mediator.Send(new Detail.Query(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new Create.Command{Activity = activity}));
        }

        [HttpPatch]
        public async Task<ActionResult> EditActivity(Activity activity)
        {
            return Ok(await Mediator.Send(new Edit.Command{Activity = activity}));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(int id)
        {
            return Ok(await Mediator.Send(new Delete.Command(id)));
        }
    }
}

//[HttpPost]