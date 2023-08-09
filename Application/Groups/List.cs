using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Groups
{
    public class List
    {
        public class Query : IRequest<List<Group>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Group>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<Group>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Groups
                    .Include(x => x.Company)
                    .Include(x => x.Leader)
                    .Include(x => x.Members).ToListAsync();
                    
                return result;
            }
        }
    }
}