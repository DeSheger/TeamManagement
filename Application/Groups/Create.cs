using Domain;
using MediatR;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Groups
{
    public class Create
    {
        public class Command : IRequest
        {
            public Group Group;
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
                Group group = request.Group;

                User existLeader = new ();
                Company existCompany = await _context.Companies
                    .Include(c => c.Members)
                    .FirstOrDefaultAsync(c => c.Id == group.Company.Id);

                var existMembers = new List<User>() { };

                // Check: Is Group Member is in Comapny?
                foreach (var CompanyMember in existCompany.Members)
                {
                    foreach(var GroupMember in group.Members)
                    {
                        if(GroupMember.Id == CompanyMember.Id)
                            existMembers.Add(await _context.Users.FindAsync(GroupMember.Id));
                    }
                    if(CompanyMember.Id == group.Leader.Id) //CHECK: IS LEADER IN COMPANY MEMBERS?
                        existLeader = await _context.Users.FindAsync(CompanyMember.Id);
                }

                var result = new Group()
                {
                    Name = group.Name,
                    Description = group.Description,
                    Company = existCompany,
                    Leader = existLeader,
                    Members = existMembers
                };

                _context.Groups.Add(result);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}