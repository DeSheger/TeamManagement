using Domain;
using MediatR;
using Persistence;

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

                User existLeader = await _context.Users.FindAsync(group.Leader.Id);
                Company existCompany = await _context.Companies.FindAsync(group.Company.Id);

                var existMembers = new List<User>() { };

                // Check: Is Group Member is in Group Comapny?
                foreach (var CompanyMember in existCompany.Members)
                {
                    foreach(var GroupMember in group.Members)
                    {
                        if(GroupMember.Id == CompanyMember.Id)
                            existMembers.Add(await _context.Users.FindAsync(GroupMember.Id));
                    }
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