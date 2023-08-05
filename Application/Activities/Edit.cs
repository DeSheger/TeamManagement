using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity;
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = request.Activity;

                var existActivity = await _context.Activities
                    .Include(a => a.Company)
                    .Include(a => a.Members)
                    .FirstOrDefaultAsync(a => a.Id == activity.Id);
                var existCompany = await _context.Companies.FindAsync(activity.Company.Id);
                var existAuthor = await _context.Users.FindAsync(activity.Author.Id);
                
                List<User> existUsers = new List<User>() { };

                foreach (var member in activity.Members)
                {
                    existUsers.Add(_context.Users.Find(member.Id));
                }

                existActivity.Title = activity.Title;
                existActivity.DateStart = activity.DateStart;
                existActivity.DateEnd = activity.DateEnd;
                existActivity.Description = activity.Description;
                existActivity.Author = existAuthor;
                existActivity.Company = existCompany;
                existActivity.Members = existUsers;

                if (activity.Group != null)
                {
                    Group existGroup = await _context.Groups.FindAsync(activity.Group.Id);
                    existActivity.Group = existGroup;
                }

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}