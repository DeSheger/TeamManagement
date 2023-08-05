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
                List<User> existUsers = new List<User>() { };

                foreach (var member in activity.Members)
                {
                    existUsers.Add(_context.Users.Find(member.Id));
                }

                var result = new Activity()
                {
                    Title = activity.Title,
                    DateStart = activity.DateStart,
                    DateEnd = activity.DateEnd,
                    Description = activity.Description,
                    Company = company,
                    Author = author,
                    Members = existUsers
                };

                if (activity.Group != null)
                {
                    Group existGroup = await _context.Groups.FindAsync(activity.Group.Id);
                    result.Group = existGroup;
                }

                _context.Activities.Add(result);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}