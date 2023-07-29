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
    public class ActivityController : BaseController
    {
        private readonly DataContext _context;
        public ActivityController(DataContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivitiesList()
        {
            return await _context.Activities.ToListAsync();
        }
    }
}