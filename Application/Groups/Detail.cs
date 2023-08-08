using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Groups
{
    public class Detail
    {
        public class Query : IRequest<Group>
        {
            public readonly int UserId;
            public Query(int Id)
            {
                UserId = Id;
            }
        }

        public class Handler : IRequestHandler<Query, Group>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Group> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _context.Groups.FindAsync(request.UserId);

                return result;
            }
        }
    }
}