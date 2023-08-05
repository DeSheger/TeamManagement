using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class Detail
    {
        public class Query : IRequest<Activity>
        {
            public readonly int UserId;
            public Query(int Id)
            {
                UserId = Id;
            }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Activities
                    .Include(x => x.Author)
                    .Include(x => x.Company)
                    .Include(x => x.Group)
                    .Include(x => x.Members).FirstOrDefaultAsync(c => c.Id == request.UserId);

                return result;
            }
        }
    }
}