using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Companies
{
    public class List
    {
        public class Query : IRequest<List<Company>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Company>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<Company>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Companies
                    .Include(x => x.Leader)
                    .Include(x => x.Members).ToListAsync();

                return result;
            }
        }
    }
}
