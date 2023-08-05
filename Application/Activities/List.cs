
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>>
        {

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
                var result = await _context.Activities
                    .Include(x => x.Author)
                    .Include(x => x.Company)
                    .Include(x => x.Group)
                    .Include(x => x.Members).ToListAsync();

            return result;
            }
        }
    }
}