using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class UserToDo
    {
        public class Query : IRequest<List<Activity>>
        {
            public readonly int UserId;
            public Query(int id)
            {
                UserId = id;
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
                .Include(u => u.ActivitiesToDo) 
                    .ThenInclude(a => a.Company)
                .Include(u => u.ActivitiesToDo) 
                    .ThenInclude(a => a.Group)
                .Include(u => u.ActivitiesToDo)
                    .ThenInclude(a => a.Author)
                .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
            
            var activitiesForMember = user.ActivitiesToDo.ToList();

            return activitiesForMember;
            }
        }
    }
}