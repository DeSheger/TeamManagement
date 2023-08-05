using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Create
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
                Activity activity = request.Activity;

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

                return Unit.Value;
            }
        }
    }
}