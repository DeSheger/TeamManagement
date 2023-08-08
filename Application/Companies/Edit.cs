using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Companies
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Company EditedCompany;
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
                Company updatedCompany = request.EditedCompany;

                var existCompany = await _context.Companies
               .Include(c => c.Members)
               .FirstOrDefaultAsync(c => c.Id == updatedCompany.Id);

                if (existCompany == null)
                {
                    return Unit.Value;
                }

                var existLeader = await _context.Users.FindAsync(updatedCompany.Leader.Id);
                var existMembers = new List<User>() { };

                foreach (var member in updatedCompany.Members)
                {
                    existMembers.Add(_context.Users.Find(member.Id));
                }

                existCompany.Name = updatedCompany.Name;
                existCompany.Description = updatedCompany.Description;
                existCompany.Leader = existLeader;
                existCompany.Members = existMembers;

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}