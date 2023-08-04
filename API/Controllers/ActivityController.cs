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
            var result = await _context.Activities
            .Include(x => x.Author)
            .Include(x => x.Company)
            .Include(x => x.Group)
            .Include(x => x.Members).ToListAsync();

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(int id)
        {
            var result = await _context.Activities
            .Include(x => x.Author)
            .Include(x => x.Company)
            .Include(x => x.Group)
            .Include(x => x.Members).FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        [HttpPost]
        public async Task<ActionResult> CreateActivity(Activity activity)
        {
            User author = await _context.Users.FindAsync(activity.Author.Id);
            Company company = await _context.Companies.FindAsync(activity.Company.Id);
            Group group = await _context.Groups.FindAsync(activity.Group.Id);

            var result = new Activity()
            {
                Title = activity.Title,
                DateStart = activity.DateStart,
                DateEnd = activity.DateEnd,
                Description = activity.Description,
                Company = company,
                Author = author,
                Group = group,
                Members = activity.Members
            };

            _context.Activities.Add(result);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch]
        public async Task<ActionResult> EditActivity(Activity activity)
        {
            var existActivity = await _context.Activities.FindAsync(activity.Id);
            var existGroup = await _context.Groups.FindAsync(activity.Group.Id);
            var existCompany = await _context.Companies.FindAsync(activity.Company.Id);
            var existAuthor = await _context.Users.FindAsync(activity.Author.Id);

            existActivity.Title = activity.Title;
            existActivity.DateStart = activity.DateStart;
            existActivity.DateEnd = activity.DateEnd;
            existActivity.Description = activity.Description;
            existActivity.Author = existAuthor;
            existActivity.Company = existCompany;
            existActivity.Group = existGroup;
            existActivity.Members = activity.Members;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(int id)
        {
            var result = await _context.Activities.FindAsync(id);
            _context.Activities.Remove(result);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

//[HttpPost]