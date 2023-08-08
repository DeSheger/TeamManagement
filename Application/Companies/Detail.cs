using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Companies
{
    public class Detail
    {
        public class Query : IRequest<Company>
        {
            public readonly int UserId;
            public Query(int Id)
            {
                UserId = Id;
            }
        }

        public class Handler : IRequestHandler<Query, Company>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Company> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Companies
                    .Include(x => x.Leader)
                    .Include(x => x.Members).FirstOrDefaultAsync(c => c.Id == request.UserId);

                return result;
            }
        }
    }
}