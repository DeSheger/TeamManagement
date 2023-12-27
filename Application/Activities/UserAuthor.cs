using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class UserAuthor
    {
        public class Query : IRequest<List<Activity>>
        {
            public readonly int AuthorId;
            public Query(int id)
            {
                AuthorId = id;
            }
        }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context) 
            {
                _context = context;
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users
                .Include(u => u.ActivitiesAuthor) 
                    .ThenInclude(a => a.Company)
                .Include(u => u.ActivitiesAuthor) 
                    .ThenInclude(a => a.Group)
                .FirstOrDefaultAsync(u => u.Id == request.AuthorId, cancellationToken);
            
            var activitiesByUser = user.ActivitiesAuthor.ToList();

            return activitiesByUser;
            }
        }
    }
}