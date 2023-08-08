using Domain;
using MediatR;
using Persistence;

namespace Application.Companies
{
    public class Create
    {
        public class Command : IRequest
        {
            public Company Company;
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
                Company company = request.Company;

                User leader = await _context.Users.FindAsync(company.Leader.Id);

                var existMembers = new List<User>() { };

                foreach (var member in company.Members)
                {
                    existMembers.Add(_context.Users.Find(member.Id));
                }

                var result = new Company()
                {
                    Name = company.Name,
                    Description = company.Description,
                    Leader = leader,
                    Members = existMembers
                };

                _context.Companies.Add(result);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}