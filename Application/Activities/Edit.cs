using Domain;
using MediatR;
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

                return Unit.Value;
            }
        }
    }
}