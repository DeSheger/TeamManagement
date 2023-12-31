using Domain;
using MediatR;
using Persistence;

namespace Application.Groups
{
    public class Delete
    {
        public class Command : IRequest
        {
            public readonly int Id;
            public Command(int id)
            {
                Id = id;
            }
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
                var result = await _context.Groups.FindAsync(request.Id);
                _context.Groups.Remove(result);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}